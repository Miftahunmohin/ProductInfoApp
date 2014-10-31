using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductInfoApp.DAL.DAO;

namespace ProductInfoApp.DAL.GateWay
{
    internal class ProductGateWay
    {
        private SqlConnection connection;
        public ProductGateWay()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["con"];

            string connectionString = "";           
            if (settings != null)
                connectionString = settings.ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;

        }

        public string Save(Product aProduct)
        {
            connection.Open();
            string query = string.Format("INSERT INTO t_Product '{0}','{1}',{2}", aProduct.Code, aProduct.Name,
                aProduct.Quantity);                                                                      
            SqlCommand command = new SqlCommand(query, connection);
            int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows >= 0)
                return "Insert success";
            return "Something happens wromg";
        }

        public bool IsValidName(string name)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE ProductName='{0}' ", name);
           SqlCommand command = new SqlCommand(query, connection);
           SqlDataReader aReader = command.ExecuteReader();        
            if (aReader.HasRows)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;

        }

        public bool IsValidCode(string code)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Product WHERE ProductCode='{0}' ",code);
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();        
            if (aReader.HasRows)
            {
                connection.Close();
                return true;
            }
            connection.Close();
            return false;
        }
    }
}
