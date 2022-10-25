using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ConsoleAdatbazis
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("23.feladat");
            Console.WriteLine("Hány házhoz szállítása volt az egyes futároknak?");
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);


            try
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select fnev, count(rendeles.fazon) from futar, rendeles where rendeles.fazon = futar.fazon group by fnev;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    Console.WriteLine("23.feladat");
                    while (dr.Read())
                    {
                        string pazon = dr.GetString("fnev");
                        string pnev = dr.GetString(1);
                        Console.WriteLine($"{pazon}. {pnev}");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
            Console.WriteLine("__________________________________");
            Console.WriteLine("24.feladat");
            Console.WriteLine("A fogyasztás alapján mi a pizzák népszerűségi sorrendje?");
            feladat24();
            Console.WriteLine("__________________________________");
            Console.WriteLine("25.feladat");
            Console.WriteLine("A rendelések összértéke alapján mi a vevők sorrendje?");
            feladat25();
            Console.WriteLine("__________________________________");
            Console.WriteLine("26.feladat");
            Console.WriteLine("Melyik a legdrágább pizza?");
            feladat26();
            Console.WriteLine("__________________________________");
            Console.WriteLine("27.feladat");
            Console.WriteLine("Ki szállította házhoz a legtöbb pizzát?");
            feladat27();
            Console.WriteLine("__________________________________");
            Console.WriteLine("28.feladat");
            Console.WriteLine("Ki ette a legtöbb pizzát?");
            feladat28();







            Console.ReadKey();
        }
        private static void feladat24()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);


            try
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select pnev, sum(db) from pizza, tetel where tetel.pazon = pizza.pazon group by pnev order by sum(db) desc;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string pazon = dr.GetString("pnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{pazon} | {db} ");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }
        }
        private static void feladat25()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);


            try
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select vnev, sum(par * db) from vevo, rendeles, pizza, tetel where rendeles.vazon = vevo.vazon and rendeles.razon = tetel.razon and tetel.pazon = pizza.pazon group by vnev order by sum(par*db) desc;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string vnev = dr.GetString("vnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{vnev} | {db} ");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }



        }
        private static void feladat26()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);


            try
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select par, pnev from pizza order by par desc limit 1;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string Pnev = dr.GetString("pnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{Pnev}  ");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }



        }
        private static void feladat27()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);


            try
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select fnev, sum(db) from futar, rendeles, tetel where rendeles.razon = tetel.razon and rendeles.fazon = futar.fazon group by fnev order by sum(db) desc limit 1;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string fnev = dr.GetString("fnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{fnev} |{db} ");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }



        }
        private static void feladat28()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "pizza";
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);


            try
            {

                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select vnev, sum(db) from vevo, rendeles, tetel where rendeles.razon = tetel.razon and rendeles.vazon = vevo.vazon group by vnev order by sum(db) desc limit 1;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string fnev = dr.GetString("vnev");
                        string db = dr.GetString(1);
                        Console.WriteLine($"{fnev} |{db} ");

                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);

                throw;
            }



        }

    }
}
//select fnev, count(rendeles.fazon) from futar, rendeles where rendeles.fazon = futar.fazon group by fnev; --23.feladat
//select pnev, sum(db) from pizza, tetel where tetel.pazon = pizza.pazon group by pnev order by sum(db) desc; --24.feladat
//select vnev, sum(par * db) from vevo, rendeles, pizza, tetel where rendeles.vazon = vevo.vazon and rendeles.razon = tetel.razon and tetel.pazon = pizza.pazon group by vnev order by sum(par*db) desc; --26.feladat
//select par, pnev from pizza order by par desc limit 1; --25.feladat
//select fnev, sum(db) from futar, rendeles, tetel where rendeles.razon = tetel.razon and rendeles.fazon = futar.fazon group by fnev order by sum(db) desc limit 1; --27.feladat
//select vnev, sum(db) from vevo, rendeles, tetel where rendeles.razon = tetel.razon and rendeles.vazon = vevo.vazon group by vnev order by sum(db) desc limit 1; --28.feladat

