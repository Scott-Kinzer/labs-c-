using System;
using ProductNameSpace;

class Program
{
     static void Main(string[] args)
        {
            // Створення екземпляра класу "Товар"
            Product product1 = new Product("Product 1", 200.0, "Manufacturer 1", DateTime.Now, new double[] { 10.0, 20.0, 30.0 });

            // Порівняння двох товарів за ціною
            Product product2 = new Product("Product 2", 250.0, "Manufacturer 2", DateTime.Now, new double[] { 15.0, 25.0, 35.0 });
            Product product3 = new Product("Product 2", 350.0, "Manufacturer 2", DateTime.Now, new double[] { 15.0, 25.0, 35.0 });
            Product product4 = new Product("Product 2", 950.0, "Manufacturer 2", DateTime.Now, new double[] { 15.0, 25.0, 35.0 });

            // if (product1 > product2)
            // {
            //     Console.WriteLine("Product 1 has a higher price than Product 2");
            // }
            // else if (product1 < product2)
            // {
            //     Console.WriteLine("Product 1 has a lower price than Product 2");
            // }
            // else if (product1 == product2)
            // {
            //     Console.WriteLine("Product 1 has the same price as Product 2");
            // }
            // else
            // {
            //     Console.WriteLine("Comparison failed");
            // }

            // Присвоєння одного товару іншому

            // Виведення даних екземпляра класу "Товар" в консоль (з використанням перевантаження оператора приведення до типу string)
            // Console.WriteLine((string)product3);

            // Збільшення ціни товару на 1000
            product3++;
            // Console.WriteLine($"Updated price: {product3.Price}");

            // Зменшення ціни товару на 1000
            product3--;
            // Console.WriteLine($"Updated price: {product3.Price}");





            Product[] arrayOfProducts = { product1, product2, product3, product4 };

            BubbleSort(arrayOfProducts);

            // Вивід відсортованого масиву
            Console.WriteLine("After sorting:");
            PrintProducts(arrayOfProducts);

            // Бінарний пошук по відсортованому масиві
            Console.WriteLine(BinarySearchByPrice(arrayOfProducts, 250));


            // Пошук обєктів в діапазоні
            Product[] filteredArray = FindProductsInRange(arrayOfProducts,product2, product4);

            Console.WriteLine("After filtering:");
            PrintProducts(filteredArray);
        }

            static void BubbleSort(Product[] products)
        {
            int n = products.Length;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (products[j] > products[j + 1])
                    {
                        Swap(products, j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        static Product[] FindProductsInRange(Product[] products, Product A, Product B)
        {
            List<Product> result = new List<Product>();

            foreach (Product product in products)
            {
                if (product > A && product < B)
                {
                    result.Add(product);
                }
            }

            return result.ToArray();
        }

        static void Swap(Product[] products, int i, int j)
        {
            Product temp = products[i];
            products[i] = products[j];
            products[j] = temp;
        }

        static void PrintProducts(Product[] products)
        {
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        static Product BinarySearchByPrice(Product[] products, double targetPrice)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                Product midProduct = products[mid];

                if (midProduct.Price == targetPrice)
                {
                    return midProduct; // Знайдено товар з заданою ціною
                }
                else if (midProduct.Price < targetPrice)
                {
                    left = mid + 1; // Шукати у правій частині масиву
                }
                else
                {
                    right = mid - 1; // Шукати у лівій частині масиву
                }
            }

            return null; // Товар з заданою ціною не знайдено
        }

}
