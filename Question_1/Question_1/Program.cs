using System;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;


namespace Question_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Directory of my txt files
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\james\Desktop\Zen\InterBet\DevTest 2019\Test transactions\");

            FileInfo[] files = di.GetFiles("*.txt");

            string line;

            foreach (FileInfo fl in files)

            {

                using (StreamReader streamReader = fl.OpenText())

                {
                    try
                    { 
                        //Read the first line of text
                        line = streamReader.ReadLine();

                        //Continue to read until you reach end of file
                        while (line != null)
                        {
                            //write the line to console window
                            //Console.WriteLine(line);

                            //I have read from text files, Now I have to save it to SQL Server Database
                            SqlCon(line);

                            //Read the next line
                            line = streamReader.ReadLine();
                        }

                        //close the file
                        streamReader.Close();
                        Console.ReadLine();
                    }
                      catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }
            }

            }


        }

        private void SqlCon(List<string> x)
        {
            //Replace with your server credentials/info
            SqlConnection myConnection = new SqlConnection("user id=username;" + "password=password;server=serverurl;" + "Trusted_Connection=yes;" + "database=database; " + "connection timeout=30");
            try
            {
                myConnection.Open();
                for (int i = 0; i <= x.Count - 13; i += 13)//Implement by 3...
                {
                    //Replace table_name with your table name, and Column1 with your column names (replace for all).
                    SqlCommand myCommand = new SqlCommand("INSERT INTO Transactions (UniqueInstanceID, EffectiveDate, TransactionCode, TransactionAmount, TransactionDate, TransactionTime, ChequeNumber, DrCrIndicator, BankName, BranchCode, ReferenceNumber, AccountNumber, Identifier) " +
                                         String.Format("Values ('{0}','{1}','{2}','{3}')", x[i], x[i + 1], x[i + 2], x[i + 3]), myConnection);
                    myCommand.ExecuteNonQuery();
                }

            }
            catch (Exception e) { Console.WriteLine(e.ToString());
            }
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

}
