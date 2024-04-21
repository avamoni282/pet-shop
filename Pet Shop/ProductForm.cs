using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Shop
{
    public partial class ProductForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
        SqlDataReader dr;
        string title = "Pet Shop Management System";



        public ProductForm()
        {
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());
            LoadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule module = new ProductModule(this);
            module.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }
        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ProductModule module = new ProductModule(this);
                module.lblPcode.Text = dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                module.txtName.Text = dgvProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                module.txtType.Text = dgvProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                module.cbCategory.Text = dgvProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                module.txtQty.Text = dgvProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                module.txtPeice.Text = dgvProduct.Rows[e.RowIndex].Cells[6].Value.ToString();



                module.buttonSave.Enabled = false;
                module.buttonUpdate.Enabled = true;
                module.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this items?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    Databasecon.executeQuery("DELETE FROM Producttable WHERE pcode LIKE '" + dgvProduct.Rows[e.RowIndex].Cells[1].Value.ToString() + "'");
                    MessageBox.Show("Item record has been successfully removed!", title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            LoadProduct();

        }

        #region Method

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM Producttable WHERE CONCAT(pname,ptype,pcategory) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            cn.Close();
        }
        #endregion Method
        /// <summary>
        /// ////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guna2Button1_Click(object sender, EventArgs e) // ADD btn 2
        {
            ProductModule module = new ProductModule(this);
            module.ShowDialog();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) ///Search 2
        {
            LoadProduct();
        }
    }
}
