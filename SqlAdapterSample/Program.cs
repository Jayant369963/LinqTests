using System;
using System.Data;
using System.Data.SqlClient;
namespace AdoNetConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ConString = "Data Source=ACHU;Integrated Security=SSPI;Initial Catalog=AdventureWorks2019;MultipleActiveResultSets=true";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from Person.Person", connection);

                    //Using Data Table
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    Console.WriteLine("Using Data Table");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["FirstName"] + ",  " + row["MiddleName"] + ",  " + row["LastName"]);
                    }
                    Console.WriteLine("---------------");
                    ////Using DataSet
                    //DataSet ds = new DataSet();
                    //da.Fill(ds, "student");
                    //Console.WriteLine("Using Data Set");
                    //foreach (DataRow row in ds.Tables["student"].Rows)
                    //{
                    //    Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    //}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }
    }
}