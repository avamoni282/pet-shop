using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop
{
    public partial class UserForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
        SqlDataReader dr;
        string title = "Pet Shop Management Systeam";
        public UserForm()
        {
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());
            LoadUser();
        }

       

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule module = new UserModule(this);
            module.ShowDialog();
        }

        


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           string colName = dgvUser.Columns[e.ColumnIndex].Name;
           if (colName == "Edit")

            {

                UserModule module = new UserModule(this);

                module.lbluid.Text = dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString();

                module.txtName.Text = dgvUser.Rows[e.RowIndex].Cells[2].Value.ToString();

                module.txtAddress.Text = dgvUser.Rows[e.RowIndex].Cells[3].Value.ToString();

                module.txtPhone.Text = dgvUser.Rows[e.RowIndex].Cells[4].Value.ToString();

                module.comboBox1.Text = dgvUser.Rows[e.RowIndex].Cells[5].Value.ToString();

                module.dtDob.Text = dgvUser.Rows[e.RowIndex].Cells[6].Value.ToString();

                module.txtPassword.Text = dgvUser.Rows[e.RowIndex].Cells[7].Value.ToString();



                module.buttonSave.Enabled = false;

                module.buttonUpdate.Enabled = true;

                module.ShowDialog();

            }

            else if (colName == "Delete")

            {

                if (MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                {
                    Databasecon.executeQuery("DELETE FROM Usertable WHERE id LIKE'" + dgvUser.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("User data has been successfully removed", title, MessageBoxButtons.OK, MessageBoxIcon.Question);

                  
                }

            }

            LoadUser();

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Method
        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM Usertable WHERE CONCAT(name,address,phone,role,dob) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), DateTime.Parse(dr[5].ToString()).ToShortDateString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();

        }

        #endregion Method

    }
}
