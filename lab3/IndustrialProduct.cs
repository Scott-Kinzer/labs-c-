using System;
using ProductNameSpace;

namespace IndustrialProductSpace
{
    public class IndustrialProduct : Product
    {
        private bool isCoolManufacturer;

        public bool IsCoolManufacturer
        {
            get { return isCoolManufacturer; }
            set { isCoolManufacturer = value; }
        }

        public IndustrialProduct()
            : base()
        {}

        public IndustrialProduct(string name, double price, string manufacturer, DateTime manufacturingDate, double[] wholesalePrices, bool isCoolManufacturer)
            : base(name, price, manufacturer, manufacturingDate, wholesalePrices)
        {
            this.isCoolManufacturer = isCoolManufacturer;
        }


        public override void ChangePrice(double discount)
        {
            // Зміна ціни продукту на акційну категорію товарів
            if (!isCoolManufacturer)
            {
                double discountedPrice = Price - (Price * discount / 100);
                Price = Math.Round(discountedPrice, 2);
            }
            else
            {
                Console.WriteLine("Цей виробник модний, не можна зробити знижку");
            }
        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Is cool: {isCoolManufacturer}");
            Console.WriteLine($"Manufacturer: {Manufacturer}");
            Console.WriteLine($"Manufacturing Date: {ManufacturingDate.ToShortDateString()}");
            Console.WriteLine("Wholesale Prices:");
            foreach (double wholesalePrice in WholesalePrices)
            {
                Console.WriteLine(wholesalePrice);
            }
        }


        public virtual void ReadFromConsole()
        {
            Console.WriteLine("Enter the product details:");
            Console.Write("Name: ");
            Name = Console.ReadLine();

            Console.Write("Price: ");
            Price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Manufacturer: ");
            Manufacturer = Console.ReadLine();

            Console.Write("Цей виробник модний? Так/Ні: ");
            string isCool = Console.ReadLine();

            if (isCool == "Так") {
                isCoolManufacturer = true;
            } else {
                isCoolManufacturer = false;
            }

            Console.Write("Manufacturing Date (dd-mm-yyyy): ");
            ManufacturingDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

            Console.Write("Wholesale Prices (comma-separated): ");
            string[] wholesalePricesStr = Console.ReadLine().Split(',');
            WholesalePrices = Array.ConvertAll(wholesalePricesStr, Double.Parse);
        }
    }
}
