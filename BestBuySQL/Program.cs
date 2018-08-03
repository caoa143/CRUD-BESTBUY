using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;




namespace BestBuySQL
{
    class Program
    {
        static void Main4(string[] args)
        {

            //==============READ USER INPUT==========================

            Console.WriteLine("What color products do you want to see");    //  USER INPUT FOR COLOR
            string response = Console.ReadLine();
            List<string> values = GetProductNames(response);

            foreach (string value in values)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();

            //========================================================
            DeleteProductReview();

            Console.ReadLine();
        }

        static void DeleteProductReview()   //METHOD TO DELETE PRODUCT REVIEW_________________________________________________
        {
            string connStr = "Server=127.0.0.1; Database=adventureworks;Uid=root;Pwd=passw0rd;SslMode=None;";
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM productreview WHERE reviewername='David';";  //Delte davids Review

                cmd.ExecuteNonQuery();
            }

        }

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++====

        static List<string> GetProductNames(string color)
        {
            string connStr = "Server=127.0.0.1; Database=adventureworks;Uid=root;Pwd=passw0rd;SslMode=None;";

            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Name FROM product WHERE color=@param1;";  //COLOR PRODUCTS
                cmd.Parameters.AddWithValue("param1", color);  //PARAMETER TO PREVENT DUMB INPUTS OR DANGEROUS INPUTS
                MySqlDataReader dr = cmd.ExecuteReader();

                List<string> productNames = new List<string>();

                while (dr.Read())
                {
                    productNames.Add(dr["Name"].ToString());
                }

                return productNames;

            }
        }
    }
}
