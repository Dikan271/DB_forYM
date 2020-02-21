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

namespace YM_3._0
{
    public partial class AddWorks : Form
    {
        public AddWorks()
        {
            InitializeComponent();
            listUsers.Items.Clear();
            Fill_ListBox();
            listUsers.Show();
        }

        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=YM;Integrated Security=True";

        public AddWorks(int selectIndex)
        {
            InitializeComponent();
            this.listUsers.Items.Clear();
            this.Fill_ListBox();
            this.listUsers.Show();
            if(this.listUsers.Items.Count >= selectIndex)
                this.listUsers.SetSelected(selectIndex, true);
        }

        private void Fill_ListBox()
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

        private void buttonCencel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistUserForm regist = new RegistUserForm();
            regist.Show();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string link = this.linkField.Text;
            string title = this.titleField.Text;
            if (title == "")
                title = "noname";
            if (!IsValidNote())
                return;
            else
            {
                SetInDB(title, link);
                SetInLib();
            }
            this.titleField.Clear();
            this.linkField.Clear();
        }

        private Boolean IsValidNote()
        {
            return (this.linkField.Text != "" && this.listUsers.SelectedIndex != -1);
        }

        private void SetInDB(string title, string link)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("newPost", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@title",
                    Value = title
                };
                command.Parameters.Add(nameParam);
                SqlParameter linkParam = new SqlParameter
                {
                    ParameterName = "@link",
                    Value = link
                };
                command.Parameters.Add(linkParam);
                command.ExecuteNonQuery();
            }
        }

        private void SetInLib()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("setinlib", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@uname",
                    Value = this.listUsers.SelectedItem.ToString()
                };
                command.Parameters.Add(nameParam);
                SqlParameter linkParam = new SqlParameter
                {
                    ParameterName = "@urlpost",
                    Value = this.linkField.Text
                };
                command.Parameters.Add(linkParam);
                command.ExecuteNonQuery();
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            this.Hide();
            Overview overview = new Overview();
            overview.Show();
        }
    }
}
