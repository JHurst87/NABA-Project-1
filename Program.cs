using System;
using System.Data.SqlClient;

namespace PersonInfo
{
    class PersonInfo
    {
        static void Main()
        {
            string firstName;
            string lastName;
            string ans;
            const string WRITE_CMD = "INSERT INTO NABA.dbo.Person ([FirstName], [LastName]) VALUES (@firstName, @lastName)";
            const string READ_CMD = "SELECT * FROM NABA.dbo.Person";
            const string DELETE_CMD = "DELETE FROM NABA.dbo.Person";
            SqlConnection connectionString = new SqlConnection(@"Data Source = DESKTOP-GQR2API;Initial Catalog = NABA;Trusted_Connection = true");
            
            //Write to table
            using (SqlCommand cmd = new SqlCommand(WRITE_CMD, connectionString))
            {
                connectionString.Open();
                
                Console.Write("Enter first name: ");
                firstName = Console.ReadLine();
                cmd.Parameters.Add("@firstName", System.Data.SqlDbType.NChar).Value = firstName;

                Console.Write("Enter last name: ");
                lastName = Console.ReadLine();
                cmd.Parameters.Add("@lastName", System.Data.SqlDbType.NChar).Value = lastName;

                cmd.ExecuteNonQuery();
                connectionString.Close();
            }

            //Read from table
            using (SqlCommand read = new SqlCommand(READ_CMD, connectionString))
            {
                connectionString.Open();

                SqlDataReader myReader = read.ExecuteReader();

                while (myReader.Read())
                {
                    Console.Write("Full name: ");
                    Console.Write(myReader["FirstName"].ToString());
                    Console.WriteLine(myReader["LastName"].ToString());
                }

                myReader.Close();
            }

            //Delete from table
            Console.Write("Delete data from table (Y/N): ");
            ans = Console.ReadLine();
            if (ans == "Y")
            {
                SqlCommand cmd = new SqlCommand(DELETE_CMD, connectionString);
                cmd.ExecuteNonQuery();
            }

        }
    }
}
