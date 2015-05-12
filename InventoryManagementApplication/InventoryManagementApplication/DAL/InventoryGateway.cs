using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using InventoryManagementApplication.MODEL;

namespace InventoryManagementApplication.DAL
{

    public class InventoryGateway
    {
        string connectionString = ConfigurationManager.ConnectionStrings["InventoryConString"].ConnectionString;
        public int Insert(Product aProduct)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("INSERT INTO product VALUES('{0}', '{1}', '{2}',{3})", aProduct.product_code, aProduct.description, aProduct.quantity,aProduct.suppliarId);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        public Product ChechProductCode(string product_code)
        {

            
            SqlConnection connection = new SqlConnection(connectionString);
            string sql = "select * from product  where product_code='" + product_code + "'";
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);

            Product apProduct = new Product();
            SqlDataReader aReader = command.ExecuteReader();
            if (aReader.HasRows)
            {
                aReader.Read();
                apProduct.product_code = aReader["product_code"].ToString();
                aReader.Close();
                connection.Close();
                return apProduct;

            }


            aReader.Close();
            connection.Close();
            return null;

        }

        public List<Product> GetProduct()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT product.product_code,product.description,product.quantity,suppliar.suppliar_name from product  LEFT OUTER JOIN suppliar ON product.suppliar_id = suppliar.suppliar_id";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product();
                product.product_code = reader["product_code"].ToString();
                product.description = reader["description"].ToString();
                product.quantity = int.Parse(reader["quantity"].ToString());
               // product.suppliarId = reader["suppliar_id"].ToString() == "" ? (int?)null : int.Parse(reader["suppliar_id"].ToString());
                product.suppliarName = reader["suppliar_name"].ToString();

                products.Add(product);
            }
            reader.Close();
            connection.Close();

            return products;
        }

        public int InsertSuppliar(Suppliar aSuppliar)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = string.Format("INSERT INTO suppliar VALUES('{0}')", aSuppliar.suppliarName);
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }

        public List<Suppliar> GetAllSuppliars()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM suppliar";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<Suppliar> suppliars = new List<Suppliar>();

            while (reader.Read())
            {
                Suppliar aSuppliar = new Suppliar();
                aSuppliar.suppliarName= reader["suppliar_name"].ToString();
                aSuppliar.SuppliarID =int.Parse(reader["suppliar_id"].ToString());
                
                suppliars.Add(aSuppliar);
            }
            reader.Close();
            connection.Close();

            return suppliars;
        }
    }
}
