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

namespace Pet_Shop
{
    public partial class MainForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
     
        public MainForm()
        {
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());
            btnHome.PerformClick();
            loadDailySale();
           
        }

       private void MainForm_Load(object sender, EventArgs e)
        {
          

        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
             if (MessageBox.Show("Exit Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            };
        }

        private void panelDash_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelChile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)    // Home
        {
            openChildForm(new Home());
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }


        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            openChildForm(new CashForm(this));
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout Application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

            LoginForm login = new LoginForm();
            this.Dispose();
            login.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void progress_ValueChanged(object sender, EventArgs e)
        {

        }


        #region Method
        private Form activeForm = null;
        //pvate object labelAdministratorOnly;
       //rivate object buttonAdministratorOnly;

        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

         public void loadDailySale()
         {
             string sdate = DateTime.Now.ToString("yyyyMMdd");

 

             try
             {
                 cn.Open();
                 cm = new SqlCommand("SELECT ISNULL(SUM(total),0) AS total FROM Cashtable WHERE transno LIKE'" + sdate + "%'", cn);
                 lblDailySale.Text = double.Parse(cm.ExecuteScalar().ToString()).ToString("#,##0.00");
                 cn.Close();
             }
             catch (Exception ex)
             {
                 cn.Close();
                 MessageBox.Show(ex.Message);
             }
         }

        #endregion Method

        private void btnUser_ControlAdded(object sender, ControlEventArgs e)
        {

            
        }

        private void btnUser_Validating(object sender, CancelEventArgs e)
        {

        }
    }

}
