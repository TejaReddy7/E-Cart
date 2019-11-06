using System;
using System.Collections.Generic;


namespace Repository
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Dictionary<String, List<String>> products = new Dictionary<string, List<string>>();

            List<String> productDetailsOfLaptop = new List<string>() { "Ideapad", "Lenovo", "2018", "3 years", "70000" };
            List<String> productDetailsOfMobile = new List<string>() { "ROG 2", "Asus", "2019", "1 year", "60000" };
            List<String> productDetailsOfDesktop = new List<string>() { "Legion", "Hp", "2019", "2 years", "80000" };

            try
            {
                products.Add("Laptop", productDetailsOfLaptop);
                products.Add("Mobile", productDetailsOfMobile);
                products.Add("Desktop", productDetailsOfDesktop);
            }
            catch (ArgumentException)
            {
                ArgumentException e = new ArgumentException("Same key is added twice in Product Dictionary.");
                Console.WriteLine(e.Message);
            }
            

            Dictionary<String, List<String>> users = new Dictionary<string, List<string>>();

            List<String> userDetailsOfTeja = new List<string>() { "charanteja1110@gmail.com", "12345", "9912345972", "Hyderabad" };
            List<String> userDetailsOfAyush = new List<string>() { "ayush@gmail.com", "12345", "9945645651", "Hyderabad" };
            List<String> userDetailsOfNeha = new List<string>() { "neha@gmail.com", "12345", "9946544645", "Hyderabad" };


            try
            {
                users.Add("Teja Reddy", userDetailsOfTeja);
                users.Add("Ayush", userDetailsOfAyush);
                users.Add("Neha", userDetailsOfNeha);
            }
            catch (ArgumentException)
            {
                ArgumentException e = new ArgumentException("Same key is added twice in User Dictionary.");
                Console.WriteLine(e.Message);
            }
            catch (NullReferenceException)
            {
                NullReferenceException e = new NullReferenceException("No key is added in User Dictionary");
                Console.WriteLine(e.Message);
            }

            var search = true;

            do
            {
                Console.WriteLine("List of Products/Users required?");
                var option = Console.ReadLine();
                try
                {
                    if (!(option == "Products" || option == "Users"))
                    {
                        throw new ArgumentException("Enter either Products or Users.");
                    }
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                try
                {
                    if (option == "Products")
                    {
                        foreach (KeyValuePair<String, List<String>> item in products)
                        {
                            Console.WriteLine(item.Key);
                        }

                        Console.WriteLine("Enter the Product name of which details are required:");
                        var pOption = Console.ReadLine();

                        foreach (var item in products[
                            pOption ?? throw new KeyNotFoundException(
                                "You should enter item from Product List, cannot be empty.")])
                        {
                            Console.WriteLine(item);
                        }

                    }

                    if (option == "Users")
                    {
                        foreach (KeyValuePair<String, List<String>> item in users)
                        {
                            Console.WriteLine(item.Key);
                        }

                        Console.WriteLine("Enter the Username of whom details are required:");
                        var userOption = Console.ReadLine();

                        foreach (var item in users[
                            userOption ??
                            throw new KeyNotFoundException(
                                "You should enter item from User List and cannot be empty.")])
                        {
                            Console.WriteLine(item);
                        }

                    }

                    Console.WriteLine("Do you want to search more? y/n:");
                    var s = Console.ReadLine();

                    if (s != null && s.Contains('n'))
                        search = false;

                    else
                    {
                        throw new NullReferenceException("Enter 'y' or 'n' only.");
                    }
                }

                catch (KeyNotFoundException e)
                {

                    Console.WriteLine(e.Message);

                }
                catch (FormatException)
                {
                    FormatException e = new FormatException("Enter in string format only");
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (search);


        }
    }

}

