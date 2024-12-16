using System;
using System.Collections.Generic;

public class Product
{
    public int PCode { get; }
    public string PName { get; set; }
    public int QtyInStock { get; set; }
    public double DiscountAllowed { get; set; }
    public static string Brand { get; set; }

    public Product(int pcode, string pname, int qtyInStock, double discountAllowed)
    {
        PCode = pcode;
        PName = pname;
        QtyInStock = qtyInStock;
        DiscountAllowed = discountAllowed;
    }

    public void DisplayDetails()
    { 
        Console.WriteLine($"Product Code: {PCode}");
        Console.WriteLine($"Product Name: {PName}");
        Console.WriteLine($"Quantity in Stock: {QtyInStock}");
        Console.WriteLine($"Discount Allowed: {DiscountAllowed}%");
        Console.WriteLine($"Brand: {Brand}");
    }
}

public class Program
{
    private static List<Product> products = new List<Product>();

    public static void Main(string[] args)
    {
        Product.Brand = "TATA";

        while (true)
        {
            Console.WriteLine("Who are you?");
            Console.WriteLine("1. Admin");
            Console.WriteLine("2. Customer");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                AdminMenu();
            }
            else if (choice == 2)
            {
                CustomerMenu();
            }
        }
    }

    private static void AdminMenu()
    {
        Console.WriteLine("1. Add product");
        Console.WriteLine("2. Display products");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            AddProduct();
        }
        else if (choice == 2)
        {
            DisplayProducts();
        }
    }

    private static void AddProduct()
    {
        Console.Write("Enter Product Code: ");
        int pcode = int.Parse(Console.ReadLine());

        Console.Write("Enter Product Name: ");
        string pname = Console.ReadLine();

        Console.Write("Enter Quantity in Stock: ");
        int qtyInStock = int.Parse(Console.ReadLine());

        Console.Write("Enter Discount Allowed: ");
        double discountAllowed = double.Parse(Console.ReadLine());

        Product product = new Product(pcode, pname, qtyInStock, discountAllowed);
        products.Add(product);
    }

    private static void DisplayProducts()
    {
        foreach (var product in products)
        {
            product.DisplayDetails();
            Console.WriteLine();
        }
    }

    private static void CustomerMenu()
    {
        Console.Write("Enter Product Name: ");
        string pname = Console.ReadLine();

        Product product = products.Find(p => p.PName.Equals(pname, StringComparison.OrdinalIgnoreCase));

        if (product != null)
        {
            product.DisplayDetails();
            Console.Write("Enter Quantity to Purchase: ");
            int qty = int.Parse(Console.ReadLine());

            if (qty <= product.QtyInStock)
            {
                double totalAmount = CalculateTotalAmount(product, qty);
                Console.WriteLine($"Total Amount to be Paid (after 50% discount): {totalAmount}");
                ProduceBill(product, qty, totalAmount);
            }
            else
            {
                Console.WriteLine("Insufficient stock.");
            }
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    private static double CalculateTotalAmount(Product product, int qty)
    {
        double originalAmount = qty * (100 - product.DiscountAllowed) / 100;
        double discountedAmount = originalAmount * 0.5; // 50% discount for 26th Jan
        return discountedAmount;
    }

    private static void ProduceBill(Product product, int qty, double totalAmount)
    {
        Console.WriteLine("----- Bill -----");
        Console.WriteLine($"Product Name: {product.PName}");
        Console.WriteLine($"Quantity: {qty}");
        Console.WriteLine($"Total Amount: {totalAmount}");
        Console.WriteLine("----------------");
    }
}
