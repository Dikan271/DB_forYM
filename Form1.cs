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
    public partial class RegistUserForm : Form
    {
        public RegistUserForm()
        {
            InitializeComponent();
        }

        private void buttonCencel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddWorks works = new AddWorks();
            works.Show();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            string name = this.UsernameField.Text;
            string link = this.UserlinkField.Text;
            if (name == "" || link == "")
                return;
            else
                SetInDB(name, link);
            this.UsernameField.Clear();
            this.UserlinkField.Clear();
        }

        private void SetInDB(string name, string link)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=YM;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("NewUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = name
                };
                command.Parameters.Add(nameParam);
                SqlParameter linkParam = new SqlParameter
                {
                    ParameterName = "@link",
                    Value = link
                };
                command.Parameters.Add(linkParam);
                var res = command.ExecuteNonQuery();
            }
        }
    }
}
