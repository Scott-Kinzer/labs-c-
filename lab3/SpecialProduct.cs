using System;
using ProductNameSpace;

namespace SpecialProductSpace
{
    public class SpecialProduct : Product
    {
        private int daysLeft;

        public int DaysLeft
        {
            get { return daysLeft; }
            set { daysLeft = value; }
        }

        public SpecialProduct()
            : base()
        {}

        public SpecialProduct(string name, double price, string manufacturer, DateTime manufacturingDate, double[] wholesalePrices, int daysLeft)
            : base(name, price, manufacturer, manufacturingDate, wholesalePrices)
        {
            this.daysLeft = daysLeft;
        }


        public override void ChangePrice(double discount)
        {
            // Зміна ціни продукту на акційну категорію товарів
            if (RemainingDays() < 0)
            {
                double discountedPrice = Price - (Price * discount / 100);
                Price = Math.Round(discountedPrice, 2);
            }
            else
            {
                Console.WriteLine("Знижка не спрацює, оскільки термін придатності не закінчився");
            }
        }

        public virtual void WriteToConsole()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Days left: {RemainingDays()}");
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

            Console.Write("Days left: ");
            DaysLeft = int.Parse(Console.ReadLine());

            Console.Write("Manufacturing Date (dd-mm-yyyy): ");
            ManufacturingDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

            Console.Write("Wholesale Prices (comma-separated): ");
            string[] wholesalePricesStr = Console.ReadLine().Split(',');
            WholesalePrices = Array.ConvertAll(wholesalePricesStr, Double.Parse);
        }

        public int RemainingDays()
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan remainingTime = ManufacturingDate.AddDays(daysLeft) - currentDate;
            return remainingTime.Days;
        }
    }
}
