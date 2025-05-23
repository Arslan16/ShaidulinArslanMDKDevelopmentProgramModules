﻿using System.Runtime.CompilerServices;
using System.Xml.XPath;

void task_0() {
    var students = new [] { 
        new {Name = "Aleksandr", Age = 20}, 
        new {Name = "Vasily", Age = 23}, 
        new {Name = "Petr", Age = 21} };
    var selection = from student in students where student.Age > 20 select student.Name;
    foreach (var student in selection.ToList()) { Console.WriteLine(student); }
}

Console.WriteLine("\n\nЗадача 0:");
task_0();

void task_1() {
    var employees = new[] {
        new { Name = "Иван", Age = 28, Department = "IT" }, new { Name = "Мария", Age = 34, Department = "HR" }, 
        new { Name = "Анна", Age = 25, Department = "Finance" }, new { Name = "Дмитрий", Age = 30, Department = "IT" },
    };
    var result = from emp in employees where emp.Department == "IT" select emp;
    foreach (var el in result.ToList()) { Console.WriteLine(el); }
}


Console.WriteLine("\n\nЗадача 1:");
task_1();

void task_2() {
    var products = new[]
    {
        new { Name = "Яблоко", Price = 100 },
        new { Name = "Банан", Price = 80 },
        new { Name = "Груша", Price = 120 },
    };
    var result = from product in products select product.Name;
    foreach(var product in result) { Console.WriteLine(product); }
}


Console.WriteLine("\n\nЗадача 2:");
task_2();

void task_3() {
    var books = new[]
    {
        new { Title = "Война и мир", Author = "Лев Толстой" },
        new { Title = "1984", Author = "Джордж Оруэлл" },
        new { Title = "Собачье сердце", Author = "Михаил Булгаков" },
    };
    var result = books.Where(book => book.Author == "Лев Толстой").First();
    Console.WriteLine(result);
}


Console.WriteLine("\n\nЗадача 3:");
task_3();

void task_4() {
    var cars = new[] {
        new { Brand = "Toyota", Year = 2020 },
        new { Brand = "Honda", Year = 2018 },
        new { Brand = "Ford", Year = 2021 },
    };
    var result = from car in cars orderby car.Year select car;
    foreach(var el in result) {Console.WriteLine(el);}
}


Console.WriteLine("\n\nЗадача 4:");
task_4();


void task_5() {
    var students = new[] {
        new { Name = "Алексей", Grade = 5 },
        new { Name = "Мария", Grade = 4 },
        new { Name = "Дмитрий", Grade = 5 },
        new { Name = "Елена", Grade = 3 },
    };
    var result = students.GroupBy(student => student.Grade);
    foreach(var el in result) {Console.WriteLine($"{el.Key} - {el.Count()}");}
}



Console.WriteLine("\n\nЗадача 5:");
task_0();

void task_6() {
    var movies = new[] {
        new { Title = "Звёздные войны", Genre = "Фантастика" },
        new { Title = "Зелёная миля", Genre = "Драма" },
        new { Title = "Властелин колец", Genre = "Фантастика" },
    };
    var result = movies.Count(movi => movi.Genre == "Фантастика");
    Console.WriteLine($" количество фильмов в жанре Фантастика : {result}");
}


Console.WriteLine("\n\nЗадача 6:");
task_6();


void task_7() {
    var clients = new[] {
        new { Name = "Андрей", IsActive = false },
        new { Name = "Светлана", IsActive = true },
        new { Name = "Николай", IsActive = false },
    };
    var result = clients.Any(client => client.IsActive);
    var s_res = result? "Да": "Нет";
    Console.WriteLine($"Среди клиентов есть активные: {s_res}!");
}

Console.WriteLine("\n\nЗадача 7:");
task_7();

void task_8() {
    var movies = new[] {
        new { Title = "Терминатор", Year = 1984 },
        new { Title = "Матрица", Year = 1999 },
        new { Title = "Начало", Year = 2010 },
        new { Title = "Интерстеллар", Year = 2014 },
    };
    var result = movies.OrderBy(mov => mov.Year).Last();
    Console.WriteLine(result);
}

Console.WriteLine("\n\nЗадача 8:");
task_8();


void task_9() {
    var genres = new[]
    {
        new { Name = "Фантастика" },
        new { Name = "Драма" },
        new { Name = "Приключения" },
        new { Name = "Фантастика" },
        new { Name = "Комедия" },
    };
    var result = genres.Distinct();
    foreach(var el in result) {Console.WriteLine(el);}
}

Console.WriteLine("\n\nЗадача 9:");
task_9();

void task_10() {
    var students = new[]
    {
        new { Name = "Аня", Age = 18 },
        new { Name = "Борис", Age = 19 },
        new { Name = "Света", Age = 20 },
        new { Name = "Игорь", Age = 21 },
        new { Name = "Фидель", Age = 22 }
    };
    var result = students.Take(3);
    foreach(var el in result) {Console.WriteLine(el);}
}

Console.WriteLine("\n\nЗадача 10:");
task_10();

void task_11() {
    var books = new[] { 
        new { Title = "1984", Author = "Джордж Оруэлл" },
        new { Title = "Гарри Поттер", Author = "Дж.К. Роулинг" },
        new { Title = "Война и мир", Author = "Лев Толстой" }, 
        new { Title = "Мастер и Маргарита", Author = "Михаил Булгаков" },
        new { Title = "Убить пересмешника", Author = "Харпер Ли" }
    };
    var result = books.Skip(2);
    foreach(var el in result) {Console.WriteLine(el);}
}

Console.WriteLine("\n\nЗадача 11:");
task_11();

void task_12() {
    var courses = new[] { 
        new { CourseName = "Математика", Students = new[] { "Аня", "Борис" } },
        new { CourseName = "Физика", Students = new[] { "Света", "Игорь", "Фидель" } } };
    var result = courses.SelectMany(course => course.Students);
    foreach(var el in result) {Console.WriteLine(el);}
}

Console.WriteLine("\n\nЗадача 12:");
task_12();

void task_13() {
    var customers = new[] { 
        new { CustomerId = 1, Name = "Иван" }, 
        new { CustomerId = 2, Name = "Алексей" }
    };
    var orders = new[] { 
        new { OrderId = 101, CustomerId = 1 }, 
        new { OrderId = 102, CustomerId = 2 }, 
        new { OrderId = 103, CustomerId = 1 }
    };
    var result = orders.Join(customers, order => order.CustomerId, customer => customer.CustomerId, 
        (order, customer) => new {CustomerId = order.CustomerId, Name = customer.Name, OrderId = order.OrderId});
    foreach(var el in result) {Console.WriteLine(el);}
}

Console.WriteLine("\n\nЗадача 13:");
task_13();

void task_14() {
    var services = new[] {
        new { ServiceName = "Стрижка", Price = 500 }, 
        new { ServiceName = "Укладка", Price = 1000 },
        new { ServiceName = "Маникюр", Price = 700 } };
    var result = services.Select(ser => new {ser.ServiceName, ser.Price}).ToList();
    foreach(var el in result) Console.WriteLine($"Услуга : {el.ServiceName}, Цена : {el.Price}");
}

Console.WriteLine("\n\nЗадача 14:");
task_14();

void task_15() {
    var orders = new[]
    {
        new { OrderId = 1, Product = "Шоколад", Quantity = 3 },
        new { OrderId = 2, Product = "Чай", Quantity = 5 },
        new { OrderId = 3, Product = "Шоколад", Quantity = 2 },
        new { OrderId = 4, Product = "Кофе", Quantity = 1 },
        new { OrderId = 5, Product = "Чай", Quantity = 4 }
    };
    var result = orders.GroupBy(order => order.Product);
    foreach(var el in result) Console.WriteLine($"Продукт : {el.Key} | Количество : {el.Count()}");
}

Console.WriteLine("\n\nЗадача 15:");
task_15();

void task_16() {
    var students = new[] {
        new { Name = "Анна", Score = 85 },
        new { Name = "Иван", Score = 95 },
        new { Name = "Мария", Score = 90 },
        new { Name = "Дмитрий", Score = 78 },
        new { Name = "Светлана", Score = 88 },
    };
    var result = students.OrderByDescending(student => student.Score).Take(3).ToList();
    foreach(var el in result) Console.WriteLine(el);
}

Console.WriteLine("\n\nЗадача 16:");
task_16();

void task_17() {
    var products = new[]
    {
        new { Name = "Яблоко", Price = 100, IsAvailable = true },
        new { Name = "Банан", Price = 80, IsAvailable = false },
        new { Name = "Груша", Price = 120, IsAvailable = true },
        new { Name = "Апельсин", Price = 90, IsAvailable = false }
    };
    var result = products.Any(product => product.Price > 90);
    Console.WriteLine(result? "Да" : "Нет");
}

Console.WriteLine("\n\nЗадача 17:");
task_17();

void task_18() {
    var students = new[] { "Алексей", "Аня", "Мария" };
    var scores = new[] { 85, 90, 75 };
    var result = students.Zip(scores, (first_name, score) => first_name + " " + score);
    foreach(var el in result) Console.WriteLine(el);
}

Console.WriteLine("\n\nЗадача 18:");
task_18();


void task_19() {
    var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var result = numbers.TakeWhile(number => number < 6);
    foreach(var el in result) {
        Console.Write(el);
        Console.Write(" ");
    }
    Console.WriteLine();
}

Console.WriteLine("\n\nЗадача 19:");
task_19();

void task_20() {
    var profits = new[] { 50000, 75000, 64000, 48000, 54000 };
    var result = profits.Aggregate((current, next) => current + next);
    Console.WriteLine(result);
}

Console.WriteLine("\n\nЗадача 20:");
task_20();

void task_21() {
    var studentGrades = new[] {
        new { Name = "Аня", Subject = "Математика", Grade = 5 },
        new { Name = "Борис", Subject = "Математика", Grade = 4 },
        new { Name = "Аня", Subject = "Физика", Grade = 5 },
        new { Name = "Борис", Subject = "Физика", Grade = 3 },
    };
    var result = studentGrades.GroupBy(student => student.Name
        ).Select(student => new {
            Name = student.Key, Average = student.Average(grade => grade.Grade)
        });
    foreach(var el in result) Console.WriteLine(el);
}

Console.WriteLine("\n\nЗадача 21:");
task_21();
