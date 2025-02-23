using System.Data;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace app{
    class UniversalTask1to4 {
        static string sep = "	"; // Спец. Символ из pg_dump postgresql
        public static Dictionary<string, int> GetResult (List<string> lines, int count_parametr_ind, int to_count_ind) {
            Dictionary<string, int> result = new Dictionary<string, int>(); // Автор: Количество; Книга: Количество
            List<string> existing = [];
            foreach(string line in lines) {
                string [] parts_in_line = line.Split(sep);
                string count_parametr = parts_in_line[count_parametr_ind]; // У чего считать (Автор, Книга)
                string to_count = parts_in_line[to_count_ind]; // Количество чего подсчитывать (Количество книг)
                if (result.ContainsKey(count_parametr)) {
                    result[count_parametr] += 1;
                } else {
                    result[count_parametr] = 1;
                    existing.Add(to_count);
                }
            };
            return result;
        }
    }

    class UniversalTask5to8 : UniversalTask1to4 {
        public static List<string> GetListOfMax (Dictionary<string, int> result) {
            List<string> has_max= new List<string>();
            int current_max = 0;
            foreach (string key in result.Keys) {
                int getted_value = result[key];
                if (getted_value > current_max) {
                    current_max = getted_value;
                    has_max = [key];
                } else if ( ! has_max.Contains(key) & getted_value == current_max){
                    has_max.Add(key);
                }
            }
            return has_max;
        }
    }

    class Task9 : UniversalTask5to8 {
        static string sep = "	"; // Спец. Символ из pg_dump postgresql
        public static List<string> GetPublishers (List<string> lines) {
            Dictionary<string, int> result = GetResult(lines, 1, 0); // данные из задания 7
            List<string> has_max= GetListOfMax(result);
            List<string> publishers = new List<string>();
            foreach (string line in lines) {
                string [] parts_in_line = line.Split(sep);
                if (has_max.Contains(parts_in_line[1])) {
                    if (! publishers.Contains(parts_in_line[2])) {
                        publishers.Add(parts_in_line[2]);
                    }
                }
            }
            return publishers;

        }
    }

    class Task10 : UniversalTask5to8 {
        static string sep = "	"; // Спец. Символ из pg_dump postgresql
        public static List<string> GetAutors (List<string> lines) {
            Dictionary<string, int> result = GetResult(lines, 3, 1); // данные из задания 8
            List<string> years = GetListOfMax(result);
            List<string> autors = new List<string>();
            foreach (string line in lines) {
                string [] parts_in_line = line.Split(sep);
                if (years.Contains(parts_in_line[3])) {
                    if ( ! autors.Contains(parts_in_line[0])) {
                        autors.Add(parts_in_line[0]);
                    }
                }
            }
            return autors;
        }
    }


    internal class Program {
        static string sep = "	"; // Спец. Символ из pg_dump postgresql
        static Dictionary<string, string> tasks = new Dictionary<string, string>(){
            {"1", "перечень авторов с указанием числа их книг"},
            {"2", "перечень наименований с указанием числа книг с таким названием"},
            {"3", "перечень издательств с указанием числа книг, выпущенных ими"},
            {"4", "перечень годов изданий с указанием числа книг, выпущенных в эти годы"},
            {"5", "перечень авторов, имеющих максимальное число книг"},
            {"6", "перечень издательств, выпустивших максимальное число книг"},
            {"7", "перечень наименований книг, встречающихся максимальное число раз"},
            {"8", "перечень годов изданий, в которые выпущено максимальное число книг"},
            {"9", "перечень издательств, выпустивших книги авторов, которые имеют максимальное число книг в таблице данных"},
            {"10", "перечень авторов, выпустивших книги в годы издания, в которые опубликовано максимальное число книг в таблице данных."},
            {"new", "Создать новую запись"},
            {"delete", "Удалить запись"},
            {"show all", "Показать содержимое файла"}
        };

         public static void Main () {
            Start:
            Console.Write("Введите путь к файлу: ");
            string? filepath = Console.ReadLine() ?? "";
            bool file_exists = File.Exists(filepath);
            if (file_exists == true) {
                Console.WriteLine("Содержимое файла: ");
                List<string> lines = File.ReadAllLines(filepath).ToList();
                foreach (string line in lines) Console.WriteLine(line);
                Console.WriteLine();
                foreach (string key in tasks.Keys) Console.WriteLine($"{key}. {tasks[key]}");
                choose_task:
                Console.Write("\nВыберите действие:");
                string input = Console.ReadLine() ?? "";
                switch (input) { 
                    case "1":
                        Dictionary<string, int> result = UniversalTask1to4.GetResult(lines, 0, 1);
                        foreach (string key in result.Keys) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToDictionary(result, filepath);
                        goto choose_task;
                    case "2":
                        result = UniversalTask1to4.GetResult(lines, 1, 0);
                        foreach (string key in result.Keys) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToDictionary(result, filepath);
                        goto choose_task;
                    case "3": // 2 1
                        result = UniversalTask1to4.GetResult(lines, 2, 1);
                        foreach (string key in result.Keys) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToDictionary(result, filepath);
                        goto choose_task;
                    case "4": // 3 1
                        result = UniversalTask1to4.GetResult(lines, 3, 1);
                        foreach (string key in result.Keys) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToDictionary(result, filepath);
                        goto choose_task;
                    case "5": // 0 1
                        result = UniversalTask5to8.GetResult(lines, 0, 1);
                        List<string> has_max = UniversalTask5to8.GetListOfMax(result);
                        foreach (string key in has_max) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToList(has_max, filepath);
                        goto choose_task;
                    case "6": // 2 1
                        result = UniversalTask5to8.GetResult(lines, 2, 1);
                        has_max = UniversalTask5to8.GetListOfMax(result);
                        foreach (string key in has_max) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToList(has_max, filepath);
                        goto choose_task;
                    case "7": // 1 0
                        result = UniversalTask5to8.GetResult(lines, 1, 0);
                        has_max = UniversalTask5to8.GetListOfMax(result);
                        foreach (string key in has_max) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToList(has_max, filepath);
                        goto choose_task;
                    case "8": // 3 1
                        result = UniversalTask5to8.GetResult(lines, 3, 1);
                        has_max = UniversalTask5to8.GetListOfMax(result);
                        foreach (string key in has_max) Console.WriteLine($"{key} {result[key]}");
                        SaveStateToList(has_max, filepath);
                        goto choose_task;
                    case "9":
                        List<string> publishers = Task9.GetPublishers(lines);
                        foreach (string publisher in publishers) Console.WriteLine($"{publisher}");
                        SaveStateToList(publishers, filepath);
                        goto choose_task;
                    case "10":
                        List<string> autors = Task10.GetAutors(lines);
                        foreach (string autor in autors) Console.WriteLine($"{autor}");
                        SaveStateToList(autors, filepath);
                        goto choose_task;
                    case "delete":
                        DeleteState(lines, filepath);
                        goto choose_task;
                    case "show all":
                        goto Start;
                    case "new":
                        CreateNewState(lines, filepath);
                        goto Start;
                    default:
                        Console.WriteLine("Вы ввели не существующий вариант. Допустимые значения 1-10");
                        goto choose_task;
                }
            } else {
                Console.WriteLine("Не удалось найти файл");
                goto Start;
            } 
        }

        static void SaveStateToDictionary(Dictionary<string, int> result, string root_file) {
            chooseSave:
            Console.Write("Сохранить в файл? Y/N ");
            string choose = Console.ReadLine() ?? "";
            if (choose == "Y") {
                Console.Write("Напишите имя файла:");
                string filename = Console.ReadLine() ?? "";
                if (filename != "" & filename != root_file) {
                    List<string> lines_to_write = new List<string>();
                    foreach (string key in result.Keys) {
                        lines_to_write.Add($"{key}{sep}{result[key]}");
                    }
                    File.WriteAllLines(filename, lines_to_write);
                    Console.WriteLine("Данные успешно записаны!");
                } else {
                    Console.WriteLine($"Нельзя записать в пустой или исходный файл! Введенное имя ${filename}");
                }
            } else if (choose != "N") {
                Console.WriteLine("Выбор может быть только N или Y");
                goto chooseSave;
            } 
        }

        static void SaveStateToList(List<string> result, string root_file) {
            chooseSave:
            Console.Write("Сохранить в файл? Y/N ");
            string choose = Console.ReadLine() ?? "";
            if (choose == "Y") {
                Console.WriteLine("Напишите имя файла:");
                string filename = Console.ReadLine() ?? "";
                if (filename != "" & filename != root_file) {
                    File.WriteAllLines(filename, result);
                    Console.WriteLine("Данные успешно записаны!");
                } else {
                    Console.WriteLine("Нельзя записать в пустой или исходный файл!");
                }
            } else if (choose != "N") {
                Console.WriteLine("Выбор может быть только N или Y");
                goto chooseSave;
            } 
        }

        static void DeleteState (List<string> lines, string file_path) {
            ChooseLine:
            Console.Write("Выберите номер строки: ");
            string input = Console.ReadLine() ?? "";
            bool can_be_parsed = int.TryParse(input, out int lineNumber);
            if (can_be_parsed == true) {
                if (lineNumber > 0 && lineNumber <= lines.Count) {
                    lines.RemoveAt(lineNumber - 1);
                    File.WriteAllLines(file_path, lines);
                    Console.WriteLine($"Строка {lineNumber} удалена.");
                } else {
                    Console.WriteLine("Ошибка: номер строки вне диапазона.");
                };
            } else if ( input == "A"){
                lines.Clear();
                File.WriteAllLines(file_path, lines);
            } else {
                Console.WriteLine($"Строка больше длины! Введите число меньше {lines.Count+1}");
                goto ChooseLine;
            }
        }

        static void CreateNewState (List<string> lines, string file_path) {
            Console.Write("ФИО: ");
            string? fio = Console.ReadLine() ?? "";
            Console.Write("Название книги: ");
            string? book_name = Console.ReadLine() ?? "";
            Console.Write("Издательство: ");
            string? publisher = Console.ReadLine() ?? "";
            Console.Write("Год: ");
            string? year = Console.ReadLine() ?? "";
            List<string> new_data = [fio, book_name, publisher, year];
            string new_line = string.Join(sep, new_data);
            lines.Add(new_line);
            File.WriteAllLines(file_path, lines);
        }
    }
}
