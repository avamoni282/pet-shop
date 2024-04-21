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
using System.Data.Common;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Pet_Shop
{

    public partial class UserModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
        string title = "Pet Shop Management Systeam";
        bool check = false;
        UserForm userForm;
        public UserModule(UserForm user)
        {
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());
            userForm = user;
            comboBox1.SelectedIndex = 1;
        }

        private void UserModule_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you want to register this user?", "User Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO Usertable (name,address,phone,role,dob,password)VALUES(@name,@address,@phone,@role,@dob,@password)", cn);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@role", comboBox1.Text);
                        cm.Parameters.AddWithValue("@dob", dtDob.Value);
                        cm.Parameters.AddWithValue("@password", txtPassword.Text);



                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("User has been successfully registered!", title);
                        Clear();
                        userForm.LoadUser();
                    }



                }



            }
            catch (Exception ex)

            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }



        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you want to update this record?", "Edit Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE Usertable SET name=@name, address=@address, phone=@phone, role=@role, dob=@dob, password=@password WHERE id=@id", cn);
                        cm.Parameters.AddWithValue("@id", lbluid.Text);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cm.Parameters.AddWithValue("@role", comboBox1.Text);
                        cm.Parameters.AddWithValue("@dob", dtDob.Value);
                        cm.Parameters.AddWithValue("@password", txtPassword.Text);



                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("User's data has been successfully updated!", title);
                        Clear();
                        userForm.LoadUser();
                        this.Dispose();
                    }



                }



            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }



        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtDob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void lbluid_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Employee")
            {
                this.Height = 453 - 26;
                lblpass.Visible = false;
                txtPassword.Visible = false;
            }
            else
            {
                this.Height = 453;
                lblpass.Visible = true;
                txtPassword.Visible = true;

            }

        }

        #region Method
        public void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            comboBox1.SelectedIndex = 0;
            dtDob.Value = DateTime.Now;

            buttonUpdate.Enabled = false;

        }

        //to check field and date of birth
        public void CheckField()
        {
            if (txtName.Text == "" | txtAddress.Text == "")
            {
                MessageBox.Show("Required data field!", "Warning");
                return;
            }



            if (checkAGe(dtDob.Value) < 18)
            {
                MessageBox.Show("User is child worker!. Under 18 year", "Warning");
                return;
            }
            check = true;
        }



        // to Calculate Age for under 18 
        private static int checkAGe(DateTime dateofBirth)
        {
            int age = DateTime.Now.Year - dateofBirth.Year;
            if (DateTime.Now.DayOfYear < dateofBirth.DayOfYear)
                age = age - 1;
            return age;
        }

        #endregion Method
    }

}