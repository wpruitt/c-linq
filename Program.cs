using System;
using System.Collections.Generic;
using System.Linq;


namespace linq
{
    // Define a bank
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            var LFruits = 
                from fruit in fruits
                where fruit.StartsWith("L")
                select fruit;
                foreach (string fruit in LFruits)
                {
                Console.WriteLine(fruit);
                }
            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            
            var fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
            foreach (var number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre" 
            };

            var descend = names.OrderByDescending(word => word);
            foreach (var word in descend)
            {
                Console.WriteLine(word);
            }
            // Build a collection of these numbers sorted in ascending order

            var ascend = 
                from number in numbers
                orderby number ascending
                select number;
                foreach (var number in ascend)
                {
                    Console.WriteLine(number);
                }

            // Output how many numbers are in this list

            int numberCount = numbers.Count();
            Console.WriteLine("There are {0} numbers in numbers.", numberCount);
                

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            var sumMoney = purchases.Sum();
            Console.WriteLine("We have made, ${0}.", sumMoney);
                

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            var maxPrice = prices.Max();
            Console.WriteLine("The most expensive produce costs ${0}.", maxPrice);

            /*
                Store each number in the following List until a perfect square
                is detected.

                Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            var trueSquare = wheresSquaredo.TakeWhile(number => ((Math.Sqrt(number))% 1) != 0);
            foreach (int number in trueSquare)
            {
                Console.WriteLine(number);
            }

            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            IEnumerable<Customer> millionaires =
                from customer in customers
                where customer.Balance >= 1000000
                select customer;

            var grouped = from mill in millionaires
            group mill by mill.Bank into taco
            select new { Bank = taco.Key, Count = taco.Count() };

            foreach (var taco in grouped)
            {
                Console.WriteLine($"{taco.Bank} - {taco.Count}");
            }

            var millionaireBanks =
                from customer in customers
                where customer.Balance >= 1000000 
                group customer by customer.Bank into mB
                select new {Bank = mB.Key, howManyMils = mB};

            foreach (var mB in millionaireBanks)
            {
                Console.WriteLine("{0}:", mB.Bank);
                foreach (var n in mB.howManyMils)
                {
                    Console.WriteLine(n.Name);
                }
            }

            // IEnumerable<string, int> MPB = new IEnumerable<string, int>() 
            // foreach (Customer millionaire in millionaires)
            // {
            //     if(!)
            //     {
            //         Console.WriteLine(millionaire.Bank);
            //     }
            // }

            /* 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://code.msdn.microsoft.com/LINQ-to-DataSets-Grouping-c62703ea

                Example Output:
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */


            /*
                TASK:
                As in the previous exercise, you're going to output the millionaires,
                but you will also display the full name of the bank. You also need
                to sort the millionaires' names, ascending by their LAST name.

                Example output:
                    Tina Fey at Citibank
                    Joe Landy at Wells Fargo
                    Sarah Ng at First Tennessee
                    Les Paul at Wells Fargo
                    Peg Vale at Bank of America
            */

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            // Create some customers and store in a List
            List<Customer> lastcustomers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            var millionaireReport =
                from bank in banks 
                join customer in lastcustomers on bank.Symbol equals customer.Bank
                where customer.Balance >= 1000000
                select new { Bank = bank.Name, Name = customer.Name }; 

            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Name} at {customer.Bank}");
            }
        }
    }
}
