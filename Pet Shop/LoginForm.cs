using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Pet_Shop
{
    public partial class LoginForm : Form

    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
        SqlDataReader dr;
        string title = "Pet Shop Management System";
        public LoginForm()
        {
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());

        }


        
        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string _name = "", _role = "";
                cn.Open();
                cm = new SqlCommand("SELECT name,role FROM Usertable WHERE name=@name and password=@password", cn);
                cm.Parameters.AddWithValue("@name", guna2TextBox1.Text);
                cm.Parameters.AddWithValue("@password", guna2TextBox2.Text);
                dr = cm.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    _name = dr["name"].ToString();
                    _role = dr["role"].ToString();
                    MessageBox.Show("Welcome  " + _name + " ! ", "ACCESS GRANTED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MainForm main = new MainForm();
                    main.lblUsername.Text = _name;
                    main.lblRole.Text = _role;
                    if (_role == "Administrator")
                    main.btnUser.Enabled = true;
                    this.Hide();
                    main.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username and password!", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                dr.Close();
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }

        }

        private void buttonForgetpass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact your BOSS!", "FORGET PASSWORD", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
