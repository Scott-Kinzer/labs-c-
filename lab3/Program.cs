using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SpecialProductSpace;
using ProductNameSpace;
using IndustrialProductSpace;

class Program
{
    static void Main()
    {
        SpecialProduct specialProduct = new SpecialProduct("Apple", 500, "Fabric", new DateTime(2023, 5, 25), new double[] { 400, 350, 300 }, 100);
       
       Console.WriteLine(specialProduct.RemainingDays());
       specialProduct.WriteToConsole();
       specialProduct.ChangePrice(5);
       specialProduct.WriteToConsole();

        SpecialProduct specialProduct2 = new SpecialProduct();


       specialProduct2.ReadFromConsole();

       specialProduct2.WriteToConsole();


        IndustrialProduct industrialProduct = new IndustrialProduct("Tv", 500, "Samsung", new DateTime(2023, 5, 25), new double[] { 400, 350, 300 }, true);
       
       industrialProduct.WriteToConsole();
       industrialProduct.ChangePrice(5);
       industrialProduct.WriteToConsole();

        IndustrialProduct industrialProduct2 = new IndustrialProduct();


       industrialProduct2.ReadFromConsole();

       industrialProduct.ChangePrice(5);

       industrialProduct2.WriteToConsole();
    }

}
