using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop
{
    public partial class CustomerModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
        string title = "Pet Shop Management Systeam";
        bool check = false;
        CustomerForm customer;
        CashCustomer customer1;
        private CashCustomer cashCustomer;
       

        public CustomerModule(CustomerForm form)
        {
            InitializeComponent(); 
            cn = new SqlConnection(Databasecon.connection());
            customer = form;
        }

        public CustomerModule(CashCustomer form)
        {
         
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());
            customer1 = form;
        }
        

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                CheckField();
                if (check)
                {
                    if (MessageBox.Show("Are you sure you want to register this customer?", "Customer Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("INSERT INTO Customertable(name,address,phone)VALUES(@name,@address,@phone)", cn);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Customer has been successfully registered!", title);
                        Clear();
                        if (customer != null)
                        {
                            customer.LoadCustomer();
                        }



                        if (customer1 != null)
                        {
                            customer1.LoadCustomer();
                        }

                                              
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
                    if (MessageBox.Show("Are you sure you want to Edit this record?", "Record Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("UPDATE Customertable SET name=@name, address=@address, phone=@phone WHERE id=@id", cn);
                        cm.Parameters.AddWithValue("@id", lblcid.Text);
                        cm.Parameters.AddWithValue("@name", txtName.Text);
                        cm.Parameters.AddWithValue("@address", txtAddress.Text);
                        cm.Parameters.AddWithValue("@phone", txtPhone.Text);


                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Customer data has been successfully updated!", title);
                        Clear();
                        customer.LoadCustomer();
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
        private void CustomerModule_Load(object sender, EventArgs e)
        {

        }

        private void CustomerModule_Load_1(object sender, EventArgs e)
        {

        }
        #region method
        public void CheckField()
        {
            if (txtName.Text == "" | txtAddress.Text == "" | txtPhone.Text == "")
            {
                MessageBox.Show("Required data field!", "Warning");
                return;
            }



            check = true;
        }

        public void Clear()
        {
            txtName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();

            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
        }

        #endregion method

        
    }

}
