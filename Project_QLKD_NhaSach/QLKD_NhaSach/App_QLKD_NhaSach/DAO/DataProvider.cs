using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_QLKD_NhaSach.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider(){ }

        private String ConnectionString = "Data Source=.\\sqlexpress;Initial Catalog=QLKD_CHSach;Integrated Security=True;TrustServerCertificate=True";

        public DataTable ExecuteQuery(String query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(query, sqlConnection);


                if (parameter != null ) 
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach ( string item in listPara ) 
                    { 
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                    
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                sqlConnection.Close();

            }
            
            return data;
        }


        public int ExecuteNonQuery(String query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(query, sqlConnection);


                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                
                data = command.ExecuteNonQuery();

                sqlConnection.Close();

            }

            return data;
        }


        public object ExecuteScalar(String query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand command = new SqlCommand(query, sqlConnection);


                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }

                data = command.ExecuteScalar();

                sqlConnection.Close();

            }

            return data;
        }
    }
}
