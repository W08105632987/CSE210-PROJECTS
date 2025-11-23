using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        //------------------ Order 1 ------------------
        Address addr1 = new Address("123 Main St", "Rexburg", "ID", "USA");
        Customer cust1 = new Customer("John Doe", addr1);
        Order order1 = new Order(cust1);

        order1.AddProduct(new Product("Laptop", "LP100", 850.00, 1));
        order1.AddProduct(new Product("Mouse", "MS200", 25.00, 2));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");


        //------------------ Order 2 ------------------
        Address addr2 = new Address("55 Market Rd", "Lagos", "Lagos", "Nigeria");
        Customer cust2 = new Customer("Mary Johnson", addr2);
        Order order2 = new Order(cust2);

        order2.AddProduct(new Product("Phone", "PH300", 500.00, 1));
        order2.AddProduct(new Product("Charger", "CH150", 20.00, 3));

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}");

        
    }
}