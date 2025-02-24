using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

namespace PR5445 {
    class Program {
       
        public static void Main () {
            Dictionary<string, string> tasks = new Dictionary<string, string>() {
                {"1", "Создать файл numbers.txt и запишите в него натуральные числа от 1 до 256 через запятую."},
                {"2", "Дан массив строк: 'Toyota', 'Ford', 'Chevrolet', 'Honda', 'Nissan', 'BMW', 'Mercedes-Benz', 'Audi', 'Volkswagen',  'Hyundai', 'Kia'. Запишите в файл 	элементы массива построчно (каждый элемент в новой строке)."},
                {"3", "Возьмите любой текстовый файл, и найдите в нем размер самой длинной строки."},
                {"4", "Дан массив размера N , заполненный случайными величинами. Вывести в консоли вначале его элементы с четными индексами, а	затем - с нечетными и записать результат в файл."},
                {"5", "Копировать большой файл с данными; Отобразить прогресс копирования в процентах; Сохранить измененный текст в новый файл"}
            };

            Dictionary<string, Action> functions = new Dictionary<string, Action>() {
                {"1", Task1}, {"2", Task2}, {"3", Task3}, {"4", Task4}, {"5", Task5}
            };
            foreach (string key in tasks.Keys) Console.WriteLine($"{key} {tasks[key]}");
            Start:
            Console.Write("Введите номер задания: ");
            string input = Console.ReadLine() ?? "";
            if (tasks.ContainsKey(input)) functions[input]();
            else goto Start;

        }

        public static void Task1 () {
            List<int> numbers = new List<int>();
            for (int i = 1; i < 256; i++) numbers.Add(i);
            string string_numbers = string.Join(",", numbers);
            File.WriteAllText("numbers.txt", string_numbers);
            Console.WriteLine("Выполнено!");
        }

        public static void Task2 () {
            List<string> cars = new List<string>() {
            "Toyota", "Ford", "Chevrolet", "Honda", "Nissan", 
            "BMW", "Mercedes-Benz", "Audi", "Volkswagen",  
            "Hyundai", "Kia"};
            File.WriteAllLines("cars.txt", cars);
            Console.WriteLine("Выполнено!");
        }

        public static void Task3 () {
            List<string> lines = File.ReadAllLines("cars.txt").ToList();
            int len_max_string = 0;
            foreach (string line in lines) if (line.Length > len_max_string) len_max_string = line.Length;
            Console.WriteLine($"длина самой длинной строки {len_max_string}");
        }

        public static void Task4 () {
            List<int> even_numbers = new List<int>() {}; // четные числа
            List<int> not_even_numbers = new List<int>() {}; // нечетные числа
            Console.Write("Введите длину массива: ");
            string input = Console.ReadLine() ?? "";
            bool can_parse = int.TryParse(input, out int len);
            Random randomizer = new Random();
            if (can_parse == true) {
                for (int i = 0; i<len; i++) {
                    // Если четное, добавить сгенерированное число к списку четных индексов
                    if (i % 2 == 0) even_numbers.Add(randomizer.Next(1, 1000));
                    // Если нет, то добавить сгенерированное число к списку нечетных индексов
                    else not_even_numbers.Add(randomizer.Next(1, 1000));
                };
                foreach (int number in even_numbers) Console.Write($"{number} "); // Вывод четных чисел в консоль
                Console.WriteLine(); // Для переноса строки
                foreach (int number in not_even_numbers) Console.Write($"{number} "); // Вывод нечетных в консоль
                File.WriteAllText(
                    "task4_numbers.txt", 
                    $"{string.Join(" ", even_numbers)}\n{string.Join(" ", not_even_numbers)}"
                ); // Записать четные в файл
            }
            Console.WriteLine("\n Выполнено!");  
        }

        public static void Task5 () {
            List<string> data = File.ReadAllLines("cars.txt").ToList();
            File.Create("new.txt");
            for (int i = 0; i < data.Count; i++) {
                File.AppendAllText("new.txt", $"{data[i]}\n");
                double del = (double)i / (double)data.Count * (double)100;
                Console.WriteLine($"{Math.Round(del)}%");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Выполнено!");
        }
    }

}