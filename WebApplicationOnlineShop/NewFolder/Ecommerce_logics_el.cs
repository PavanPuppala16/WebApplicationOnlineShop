using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using WebApplicationOnlineShop.Models;

namespace WebApplicationOnlineShop.NewFolder
{
    public class Ecommerce_logics_el
    {
       

        public static bool Insertdata(Register obj)
        {
            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_INSERTUSERS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", obj.LastName);
                    cmd.Parameters.AddWithValue("@EmailID", obj.EmailId);
                    cmd.Parameters.AddWithValue("@Password", obj.Password);
                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@Dob", Convert.ToDateTime(obj.DOB));
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }
                }
                catch (Exception)
                {



                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
                   
        public static DataTable Login(Ecommerce obj)
        {
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_LOGINUSERS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailID", obj.EmailID);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static List<Uploads> GetALlDataDummy()
        {
            List<Uploads> obj = new List<Uploads>();
            var dbconfig = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from tblFiles ", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new Uploads
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            ProductName = dr["ProductName"].ToString(),
                            Name = dr["Name"].ToString(),
                            Quantity = Convert.ToInt32(dr["Quantity"].ToString()),
                            Price = Convert.ToInt32(dr["Price"].ToString())
                        }
                        );
                }
                return obj;
            }
        }
        }
}
