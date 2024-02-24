

using System.Data.SqlClient;

namespace ADANET_Lab3
{
    internal class Program
    {
        public static string ConnectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StationaryStore;Integrated Security=True;Connect Timeout=30;";
        static void Main()
        {


            Console.WriteLine("Connect [StationaryStore]?(Y/N)");
            string responce = Console.ReadLine();
            if (responce != "N")
            {
                try
                {
                    bool exit = false;
                    string query = "";
                    while (!exit)
                    {
                        Console.Clear();
                        Console.WriteLine("Select an option:\n\t1)\n\t2)\n\t3)\n\t4)\n\t5)\n\t6)\n\t7)\n\t8)\n\t9)\n\t10)\n\t11)\n\t0)Exit");
                        responce = Console.ReadLine();
                        switch (responce)
                        {
                            case "1":
                                query = "SELECT  Name, ProductType.Type as TypeName, Price FROM Product JOIN ProductType ON Product.Type = ProductType.Id";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Product info");
                                        Console.WriteLine($"Name\t|Type|\tPrice");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Name"]}|\t{reader["TypeName"]}|\t{reader["Price"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "2":
                                query = "SELECT  * FROM ProductType";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Type info");
                                        Console.WriteLine($"Id\t|Type|\tQuantity");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Id"]}|\t{reader["Type"]}|\t{reader["Quantity"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "3":
                                query = "SELECT  * FROM Managers";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Manager info");
                                        Console.WriteLine($"Id\t|FirstName|\tLastName");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Id"]}|\t{reader["FirstName"]}|\t{reader["LastName"]}");
                                        }
                                    }
                                } 
                                Console.ReadKey();
                                break;
                            case "4":
                                query = "SELECT * FROM ProductType WHERE Quantity = (SELECT MAX(Quantity) FROM ProductType);";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Max type Quantity:");
                                        Console.WriteLine($"Type\t|Quantity");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Type"]}: {reader["Quantity"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "5":
                                query = "SELECT * FROM ProductType WHERE Quantity = (SELECT MIN(Quantity) FROM ProductType);";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Min type Quantity:");
                                        Console.WriteLine($"Type\t|Quantity");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Type"]}: {reader["Quantity"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "6":
                                query = "SELECT * FROM Product WHERE Price = (SELECT MIN(Price) FROM Product);";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Min product price:");
                                        Console.WriteLine($"Name\t|Price");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Name"]}: {reader["Price"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "7":
                                query = "SELECT * FROM Product WHERE Price = (SELECT MAX(Price) FROM Product);";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Max product price:");
                                        Console.WriteLine($"Name\t|Price");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Name"]}: {reader["Price"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "8":
                                Console.WriteLine("Enter type:");
                                string type = Console.ReadLine();


                                query = $"SELECT Product.*, ProductType.Type as TypeName FROM Product JOIN ProductType ON Product.Type = ProductType.Id WHERE ProductType.Type LIKE '{type}'";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        if (!reader.HasRows)
                                        {
                                            Console.Write($"No items found with this type");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Name\t|Price\t|Type");
                                            while (reader.Read())
                                            {
                                                Console.WriteLine($"{reader["Name"]}\t|{reader["Price"]}\t|{reader["TypeName"]}");
                                            }
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "9":
                                Console.WriteLine("Enter manager's name:");
                                string manager = Console.ReadLine();


                                query = $"SELECT Product.Name, Product.Price, ProductType.Type AS TypeName FROM Product JOIN ProductType ON ProductType.Id = Product.[Type] JOIN Sale ON Sale.ProductId = Product.Id JOIN Managers ON Sale.ManagerId = Managers.Id WHERE Managers.FirstName LIKE '{manager}';";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        if (!reader.HasRows)
                                        {
                                            Console.Write($"No items found sold by this manager");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Name\t|Price\t|Type");
                                            while (reader.Read())
                                            {
                                                Console.WriteLine($"{reader["Name"]}\t|{reader["Price"]}\t|{reader["TypeName"]}");
                                            }
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "10":

                                Console.WriteLine("Enter buyer company's name:");
                                string company = Console.ReadLine();


                                query = $"SELECT Product.Name, Product.Price, ProductType.Type AS TypeName FROM Product JOIN ProductType ON ProductType.Id = Product.[Type] JOIN Sale ON Sale.ProductId = Product.Id JOIN Managers ON Sale.ManagerId = Managers.Id WHERE Sale.BuyerCompany LIKE '{company}';";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        if (!reader.HasRows)
                                        {
                                            Console.Write($"No items found sold by this manager");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Name\t|Price\t|Type");
                                            while (reader.Read())
                                            {
                                                Console.WriteLine($"{reader["Name"]}\t|{reader["Price"]}\t|{reader["TypeName"]}");
                                            }
                                        }
                                            
                                    }
                                }
                                Console.ReadKey();
                                break;
                            case "11":

                                query = "SELECT Managers.FirstName + ' ' + Managers.LastName AS Manager, Product.Name AS ProductName, Product.Price, ProductQuantity, BuyerCompany, Date FROM Product JOIN Sale ON Sale.ProductId = Product.Id JOIN Managers ON Sale.ManagerId = Managers.Id WHERE Sale.Date = (SELECT MAX(Sale.Date) FROM Sale);";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Latest sale info:");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["Manager"]}\t|{reader["ProductName"]}\t|{reader["Price"]}\t|{reader["ProductQuantity"]}\t|{reader["BuyerCompany"]}\t|{reader["Date"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;

                            case "12":
                                //My database only stores quantity of products as a type, so i made this task about average price instead. Almost no changes, really

                                query = "SELECT ProductType.Type AS TypeName, AVG(Product.Price) AS AvgPrice FROM Product  JOIN ProductType ON ProductType.Id = Product.Type GROUP BY ProductType.Type";

                                using (SqlConnection connection = new SqlConnection(ConnectionString))
                                {
                                    connection.Open();
                                    using (SqlCommand cmd = new SqlCommand(query, connection))
                                    {
                                        SqlDataReader reader = cmd.ExecuteReader();
                                        Console.WriteLine("Average price per type:");
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"{reader["TypeName"]}: {reader["AvgPrice"]}");
                                        }
                                    }
                                }
                                Console.ReadKey();
                                break;
                        
                            case "0":
                                exit = true;
                                break;
                            default: break;
                        }

                    }





                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while connecting to [StationaryStore]; Error: " + ex.Message);

                }
            }
            else
            {
                Console.WriteLine("Connection terminated");

            }

        }
    }
}
