using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace YM_3._0
{
    public struct Hipperlink
    {
        public string name;
        public string ling;
    };

    public struct AllDataFromDB_YM
    {
        public int count;
        public Hipperlink user;
        public Hipperlink work;
    };

    public partial class Overview : Form
    {

        public Overview()
        {
            InitializeComponent();
            this.listUsers.Items.Clear();
            this.Fill_ListUser();
            this.listUsers.Show();
            this.listPosts.Hide();
        }

        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=YM;Integrated Security=True";

        private void Fill_ListUser()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from [User]", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        this.listUsers.Items.Add(reader.GetString(1));
                }
                else
                    this.listUsers.Items.Add("No users");
            }
        }

        private void Fill_ListPosts(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetListOfPost", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@uname",
                    Value = username
                };
                command.Parameters.Add(parameter);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        this.listPosts.Items.Add(reader.GetString(0));
                }
            }
        }

        private void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listUsers.SelectedIndex == -1) //if do not selected
                return;
            string user = this.listUsers.SelectedItem.ToString();
            ListPost_Reset(user);
        }

        private void ListPost_Reset(string user)
        {
            this.listPosts.Items.Clear();
            Fill_ListPosts(user);
            this.listPosts.Show();
        }

        private void listPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonAddWork_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddWorks works;
            int index = this.listUsers.SelectedIndex;
            if (index == -1)
                works = new AddWorks();
            else
                works = new AddWorks(index);
            works.Show();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("ExportDB", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Export(reader);
                }
            }
        }

        private void Export(SqlDataReader reader)
        {
            reader.Read();
            AllDataFromDB_YM prev, next;
            prev = ReadLine(reader);
            WriteFirstuser(prev);
            while (reader.Read())
            {
                next = ReadLine(reader);
                SetInfoInFile(prev, next);
                prev = next;
            }
            MessageBox.Show("file was created");
        }

        private AllDataFromDB_YM ReadLine(SqlDataReader reader)
        {
            AllDataFromDB_YM allData;
            allData.count = reader.GetInt32(0);
            allData.user.name = reader.GetString(1);
            allData.user.ling = reader.GetString(2);
            allData.work.name = reader.GetString(3);
            allData.work.ling = reader.GetString(4);
            return allData;
        }

        private void SetInfoInFile(AllDataFromDB_YM prev, AllDataFromDB_YM next)
        {
            var file = new StreamWriter("test1.txt",true);
            if(next.count != prev.count)
            {
                string count = "[BC]" + next.count.ToString();
                file.WriteLine(count);
            }
            if(next.user.ling != prev.user.ling)
            {
                string user = "[BC][" + next.user.name + "|" + next.user.ling + "]";
                file.WriteLine(user);
            }
            string work = "[" + next.work.name + "|" + next.work.ling + "]";
            file.WriteLine(work);
            file.Close();
        }

        private void WriteFirstuser(AllDataFromDB_YM first)
        {
            var file = new StreamWriter("test1.txt", true);
            string count = "[BC]" + first.count.ToString();
            file.WriteLine(count);
            string user = "[BC][" + first.user.name + "|" + first.user.ling + "]";
            file.WriteLine(user);
            string work = "[" + first.work.name + "|" + first.work.ling + "]";
            file.WriteLine(work);
            file.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("are you sure?", "delete all data", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
                DeleteAllData();
            ClearForm();
        }

        private void DeleteAllData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("[ClearDB]", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var res = command.ExecuteNonQuery();
                if (res != 0)
                    MessageBox.Show("database was clear");
            }
        }

        private void ClearForm()
        {
            this.listUsers.Items.Clear();
            Fill_ListUser();
            this.listPosts.Hide();
        }
    }
}
