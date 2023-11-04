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

namespace Login_page
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-7M6R0TH\SQLEXPRESS03;Initial Catalog=LOginDB;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, userpassword;
            username = txtUser.Text;
            userpassword = txtPassword.Text;
            try
            {
                string query = "SELECT * FROM Login_new WHERE username='" + txtUser.Text + "'AND password='" + txtPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                if (dtable.Rows.Count > 0)
                {
                    username = txtUser.Text;
                    userpassword = txtPassword.Text;
                    SeconForm form2 = new SeconForm();
                    form2.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid details","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUser.Clear()
;                   txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Erro");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Are you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }
    }
}
