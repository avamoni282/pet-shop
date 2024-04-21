using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pet_Shop
{
    internal class DatabaseConnect
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        private string con;


        public string connection()
        {
            con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""G:\Pet Shop\Pet Shop\DatabasePetShop.mdf"";Integrated Security=True";

            return con;
        }

        public void executeQuery(string sql)
        {
            try
            {
                cn.ConnectionString = connection();
                cn.Open();
                cm = new SqlCommand(sql, cn);



                cm.ExecuteNonQuery();
                cn.Close();



            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }



        }
    }
}
