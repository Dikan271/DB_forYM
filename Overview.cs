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

//TODO button DELETE

namespace YM_3._0
{
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
            this.buttonDelete.Hide();
        }

        private void ListPost_Reset(string user)
        {
            this.listPosts.Items.Clear();
            Fill_ListPosts(user);
            this.listPosts.Show();
        }

        private void listPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listPosts.SelectedIndex != -1)
                this.buttonDelete.Show();
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
            while (reader.Read())
            {

            }
        }
    }
}
