using System;
using ProductNameSpace;

class Program
{
    static void Main(string[] args)
    {
        // Створення об'єкту з використанням конструктора з параметрами
        Product product1 = new Product("Phone", 500, "Apple", new DateTime(2023, 1, 1), new double[] { 400, 350, 300 });

        // Створення об'єкту з використанням конструктора без параметрів та встановлення значень полів через set-методи
        Product product2 = new Product();
        product2.Name = "Laptop";
        product2.Price = 1000;
        product2.Manufacturer = "Dell";
        product2.ManufacturingDate = new DateTime(2023, 2, 1);
        product2.WholesalePrices = new double[] { 900, 850, 800 };

        // Створення об'єкту з використанням конструктора копіювання
        Product product3 = new Product(product1);

        Console.WriteLine(product1.GetShortInfo());

        // Зміна ціни товару з використанням дисконтної картки
        product1.ChangePrice(5); // 5% знижка
        
        product2.ChangePrice(3); // 3% знижка

        // Виведення скороченої інформації про товари
        Console.WriteLine("Product 1:");
        Console.WriteLine(product1.GetShortInfo());
        Console.WriteLine();
 
        Console.WriteLine("Product 2:");
        Console.WriteLine(product2.GetShortInfo());
        Console.WriteLine();

        Console.WriteLine("Product 3:");
        Console.WriteLine(product3.GetShortInfo());
        Console.WriteLine();

        // Читання даних з консолі для товару
        // Product product4 = new Product();
        // product4.ReadFromConsole();
        // Console.WriteLine();

        // // Виведення даних товару на консоль
        // product4.WriteToConsole();



        List<Product> arrayOfProducts = new List<Product>();
        arrayOfProducts.Add(product1);
        arrayOfProducts.Add(product2);
        arrayOfProducts.Add(product3);

        while(true) {

            for (int i = 0; i < arrayOfProducts.Count; i++)
            {
                Product product = arrayOfProducts[i];
                Console.WriteLine("Index: " + i + " " + product.Name);
            }

            Console.WriteLine("Ви хочете створити продукт чи змінити ціну існуючого? Якщо створити введіть -1, інакше введіть індекс масиву продуктів");

            int answer = int.Parse(Console.ReadLine());

            if (answer == -1) {
                Product product = new Product();
                product.ReadFromConsole();
                product.WriteToConsole();
                arrayOfProducts.Add(product);
                Console.WriteLine();
                Console.WriteLine("Створений продукт доданий в масив");
            } else {
                Product chosenProduct = arrayOfProducts[answer];

                Console.WriteLine("Введіть знижку для товара 3, 5, або 7");

                int price = int.Parse(Console.ReadLine());

                chosenProduct.ChangePrice(price);

                Console.WriteLine(chosenProduct.GetShortInfo());
                Console.WriteLine("________________________");
            }


        }
    }
}
