using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeManager.DAO
{
    public class DataProvider
    {
        private static DataProvider instance; // Ctr + R + E: Đóng gói

        private string connectionSTR = "Data Source=SON;Initial Catalog=CoffeeManager;Persist Security Info=True;User ID=sa;Password=sonlearn2003";

        public static DataProvider Instance 
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExcuteQuery(String query, Object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                if(parameter != null) 
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach(string item in listPara) 
                    {
                        if(item.Contains('@')) 
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExcuteNonQuery(String query, Object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                data = cmd.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExcuteScalar(String query, Object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i++]);
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                connection.Close();
            }

            return data;
        }
    }
} 
