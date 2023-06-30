using System;

namespace ProductNameSpace {
public class Product
{
    private string name;
    private double price;
    private string manufacturer;
    private DateTime manufacturingDate;
    private double[] wholesalePrices;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public string Manufacturer
    {
        get { return manufacturer; }
        set { manufacturer = value; }
    }

    public DateTime ManufacturingDate
    {
        get { return manufacturingDate; }
        set { manufacturingDate = value; }
    }

    public double[] WholesalePrices
    {
        get { return wholesalePrices; }
        set { wholesalePrices = value; }
    }

    public Product()
    {
        // Конструктор без параметрів
    }

    public Product(string name, double price, string manufacturer, DateTime manufacturingDate, double[] wholesalePrices)
    {
        this.name = name;
        this.price = price;
        this.manufacturer = manufacturer;
        this.manufacturingDate = manufacturingDate;
        this.wholesalePrices = wholesalePrices;
    }

    public Product(Product other)
    {
        this.name = other.name;
        this.price = other.price;
        this.manufacturer = other.manufacturer;
        this.manufacturingDate = other.manufacturingDate;
        this.wholesalePrices = other.wholesalePrices;
    }

    public void ChangePrice(double discount)
    {
    if (discount == 3 || discount == 5 || discount == 7)
    {
        double discountedPrice = price - (price * discount / 100);
        price = Math.Round(discountedPrice, 2);
    }
    else
    {
        Console.WriteLine("Invalid discount value. Discount should be 3, 5, or 7.");
    }
    }

    public string GetShortInfo()
    {
        return $"Name: {name}, Price: {price}, Manufacturer: {manufacturer}, Manufacturing Date: {manufacturingDate.ToShortDateString()}";
    }

    public void ReadFromConsole()
    {
        Console.WriteLine("Enter the product details:");
        Console.Write("Name: ");
        name = Console.ReadLine();

        Console.Write("Price: ");
        price = Convert.ToDouble(Console.ReadLine());

        Console.Write("Manufacturer: ");
        manufacturer = Console.ReadLine();

        Console.Write("Manufacturing Date (dd-mm-yyyy): ");
        manufacturingDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

        Console.Write("Wholesale Prices (comma-separated): ");
        string[] wholesalePricesStr = Console.ReadLine().Split(',');
        wholesalePrices = Array.ConvertAll(wholesalePricesStr, Double.Parse);
    }

    public void WriteToConsole()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Price: {price}");
        Console.WriteLine($"Manufacturer: {manufacturer}");
        Console.WriteLine($"Manufacturing Date: {manufacturingDate.ToShortDateString()}");
        Console.WriteLine("Wholesale Prices:");
        foreach (double wholesalePrice in wholesalePrices)
        {
            Console.WriteLine(wholesalePrice);
        }
    }
}
}