using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Data.SqlClient;

namespace UsersDomain
{
    //http://www.codeproject.com/Articles/9570/Querying-Microsoft-Active-Directory-Using-Microsof
    //http://msdn.microsoft.com/en-us/library/system.directoryservices.directorysearcher.findall.aspx

    /*
CREATE LOGIN "PNG\GazeevAP" FROM WINDOWS;
CREATE USER "PNG\GazeevAP";
EXEC sp_addrolemember 'db_datareader', "PNG\GazeevAP"
DROP USER "PNG\GazeevAP";
DROP LOGIN "PNG\GazeevAP";
    */

    public partial class Main : Form
    {
        private string _connectionString;

        sealed class DomainUser
        {
            public string Account { get; private set; }
            public string Name { get; private set; }
            public string Domain { get; private set; }

            public DomainUser(string domain, string account, string name)
            {
                Account = account;
                Name = name;
                Domain = domain;
            }
        }

        sealed class RoleDB
        {
            public string Role { get; private set; }
            public string Description { get; private set; }

            public RoleDB(string role, string desciption)
            {
                Role = role;
                Description = desciption;
            }
        }

        public Main()
        {
            InitializeComponent();

            _connectionString = Properties.Settings.Default.ConnectionString;

            dtgRoles.DataSource = GetRolesDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(IsExistInAD(txtUserName.Text).ToString());
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = SearchInAD(txtFilter.Text);

            dtgAllUsers.DataSource = bindingSource1;
        }

        private void btAllUser_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = GetAllADDomainUsers(txtDomainPath.Text);

            dtgAllUsers.DataSource = bindingSource1;
        }

        #region Function

        string ExtractUserName(string path)
        {
            string[] userPath = path.Split(new char[] { '\\' });
            return userPath[userPath.Length - 1];
        }

        bool IsExistInAD(string loginName)
        {
            string userName = ExtractUserName(loginName);
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(SAMAccountName={0})", userName);
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        List<DomainUser> SearchInAD(string filter)
        {
            List<DomainUser> findUsers = new List<DomainUser>();

            string userName = ExtractUserName(filter);
            DirectorySearcher search = new DirectorySearcher();
            search.Filter = String.Format("(SAMAccountName={0})", userName);
            search.PropertiesToLoad.Add("displayName");                             // name
            search.PropertiesToLoad.Add("samaccountname");                             // account
            search.PropertiesToLoad.Add("cn");
            SearchResult result;
            using (SearchResultCollection resultCol = search.FindAll())
            {
                for (int counter = 0; counter < resultCol.Count; counter++)
                {
                    result = resultCol[counter];
                    string domain = GetDoaminFromPath(result.Path);
                    if (result.Properties.Contains("samaccountname"))
                    {
                        if (result.Properties.Contains("displayName"))
                            findUsers.Add(new DomainUser(domain, (String)result.Properties["samaccountname"][0],
                                                         (String)result.Properties["displayName"][0]));
                        else
                            findUsers.Add(new DomainUser(domain, (String)result.Properties["samaccountname"][0], ""));
                    }
                }
                resultCol.Dispose();
            }
            return findUsers;
        }

        List<DomainUser> GetAllADDomainUsers(string domainpath)
        {
            List<DomainUser> allUsers = new List<DomainUser>();

            DirectoryEntry searchRoot = new DirectoryEntry(domainpath);
            DirectorySearcher search = new DirectorySearcher(searchRoot);
            search.Filter = "(&(objectClass=user)(objectCategory=person))";
            search.PropertiesToLoad.Add("displayName");                             // name
            search.PropertiesToLoad.Add("samaccountname");

            SearchResult result;
            using (SearchResultCollection resultCol = search.FindAll())
            {
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        result = resultCol[counter];
                        string domain = GetDoaminFromPath(result.Path);
                        if (result.Properties.Contains("samaccountname"))
                        {
                            if (result.Properties.Contains("displayName"))
                                allUsers.Add(new DomainUser(domain, (String)result.Properties["samaccountname"][0], (String)result.Properties["displayName"][0]));
                            else
                                allUsers.Add(new DomainUser(domain, (String)result.Properties["samaccountname"][0], ""));
                        }
                    }
                }
                resultCol.Dispose();
            }
            return allUsers;
        }

        string GetDoaminFromPath(string path)
        {
            foreach (var elem in path.Split(','))
            {
                if (elem.StartsWith("DC="))
                {
                    return elem.Substring(3);
                }
            }
            return "";
        }

        string GetFullUserName(DomainUser user)
        {
            return user.Domain + "\\" + user.Account;
        }

        List<RoleDB> GetRolesDB()
        {
            List<RoleDB> result = new List<RoleDB>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                SqlCommand comm = new SqlCommand(@"EXEC sp_helpdbfixedrole;", conn);
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new RoleDB(reader[0].ToString(), reader[1].ToString()));
                }
            }

            return result;
        }

        bool AddUser(DomainUser newUser, RoleDB role)
        {
            /*    
           CREATE LOGIN "PNG\GazeevAP" FROM WINDOWS;
           CREATE USER "PNG\GazeevAP";
           EXEC sp_addrolemember 'db_datareader', "PNG\GazeevAP"
           */
            string fullUserName = GetFullUserName(newUser);
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;

                comm.CommandText = "CREATE LOGIN \"" + fullUserName + "\" FROM WINDOWS;";
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Create login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                comm.CommandText = "CREATE USER \"" + fullUserName + "\";";
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Create user", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                comm.CommandText = "EXEC sp_addrolemember \"" + role.Role + "\", \"" + fullUserName + "\";";
                try
                {
                    comm.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Add user to the role", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        #endregion

        private void btGetRoles_Click(object sender, EventArgs e)
        {
         }

        private void btAddUser_Click(object sender, EventArgs e)
        {
            DataGridViewRow userCh = dtgAllUsers.CurrentRow;
            if (userCh == null)
            {
                throw new ApplicationException("You must choose user");
            }
            DomainUser user = new DomainUser(userCh.Cells["Domain"].Value.ToString(),
                                             userCh.Cells["Account"].Value.ToString(),
                                             userCh.Cells["Name"].Value.ToString());
            DataGridViewRow roleCh = dtgRoles.CurrentRow;
            if (roleCh == null)
            {
                throw new ApplicationException("You must choose role");
            }
            RoleDB role = new RoleDB(roleCh.Cells["Role"].Value.ToString(), roleCh.Cells["Description"].Value.ToString());

            if (!AddUser(user, role))
            {
                throw new ApplicationException("Can not add user to DB");
            }

            MessageBox.Show("User was successfully added", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
