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
    public partial class Home : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DatabaseConnect Databasecon = new DatabaseConnect();
        string title = "Pet Shop Management System";
        
       
        public Home()
        {
            InitializeComponent();
            cn = new SqlConnection(Databasecon.connection());
            
        }
        #region Method
        public int extractData(string str)
        {    
            int data = 0;
            try
            {
                cn.Open();
                cm= new SqlCommand("SELECT ISNULL(SUM(pqty),0) AS qty FROM Producttable WHERE pcategory= '" + str + "'", cn);
                data = int.Parse(cm.ExecuteScalar().ToString());
                cn.Close();
            }
            catch (Exception ex) 
            {
                cn.Close();
                MessageBox.Show(ex.Message, title);
            }
            return data;
        }

        #endregion method
        
        private void Home_Load(object sender, EventArgs e)
        { 
            lblDog.Text = extractData("Dog").ToString();
            lblCat.Text = extractData("Cat").ToString();
            lblBird.Text = extractData("Bird").ToString();
            lblFish.Text = extractData("Fish").ToString();
        }
    }
    }

