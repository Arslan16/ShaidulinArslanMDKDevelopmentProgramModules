
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

void example () {
    var employees = new[]
    {
        new { Name = "Иван", Age = 28, Department = "IT" },
        new { Name = "Мария", Age = 34, Department = "HR" },
        new { Name = "Анна", Age = 25, Department = "Finance" },
        new { Name = "Дмитрий", Age = 30, Department = "IT" },
    };

    List<string> result = new List<string>();
    foreach (var employee in employees)
    {
        if (employee.Name.StartsWith('M'))
        {
            result.Add(employee.Name);
        }
    }

    var select_start_with_m = employees.Where(empl => empl.Name.StartsWith("M"));
    var select_start_with_a = employees.Select(e => e.Name.StartsWith("A"));
    var order_result = employees.OrderBy(e => e.Age).ToList();
    var _RESULT = from emp in employees
                orderby emp.Age descending
                select emp;

    employees.OrderByDescending(e => e.Age);

    if (result.Any()) {}; // Проверяет на наличие и на не пустоту

};

void task_0 () {
    // Задание 0
    // var filteredStudents = new List<string>();

    // for (int i = 0; i < students.Length; i++)
    // {
    //     if (students[i].Age > 20) // Фильтруем студентов старше 20 лет
    //     {
    //         filteredStudents.Add(students[i].Name);
    //     }
    // }

    // // Выводим результат
    // foreach (var name in filteredStudents)
    // {
    //     Console.WriteLine(name);
    // }

    // Оптимизируйте его как LINQ запрос.
    
    var students = new [] {
        new {Name = "Alek", Age = 20},
        new {Name = "ARk", Age = 23},
        new {Name = "Pika", Age = 21}
    };
    var result = from student in students where student.Age > 20 select student.Name;
    foreach (var student in result.ToList()) { Console.WriteLine(student);} 

};

void task_1 () {
    //Задание 1: Использование Where
    // Найдите всех сотрудников, работающих в департаменте "IT".
    var employees = new[]
    {
        new { Name = "Иван", Age = 28, Department = "IT" },
        new { Name = "Мария", Age = 34, Department = "HR" },
        new { Name = "Анна", Age = 25, Department = "Finance" },
        new { Name = "Дмитрий", Age = 30, Department = "IT" },
    };
    
    var result = from emp in employees
                    where emp.Department == "IT"
                    select emp;
                    
    foreach (var employee in result.ToList()) { Console.WriteLine(employee);} 
};

void task_2 () {
    // Задание 2: Использование Select
    // Условие:
    // Создайте новую коллекцию, которая будет содержать только названия продуктов.

    var products = new[]
    {
        new { Name = "Яблоко", Price = 100 },
        new { Name = "Банан", Price = 80 },
        new { Name = "Груша", Price = 120 },
    };

    var product_names = from product in products
                        select product.Name;
    foreach (var product_name in product_names.ToList()) { Console.WriteLine(product_name);}

}

void task_3 () {
    // Задание 3: Использование First
    // Данные:
    // Список книг в виде массива объектов:
    // Условие:
    // Найдите первую книгу, автором которой является "Лев Толстой".
    var books = new[]
    {
        new { Title = "Война и мир", Author = "Лев Толстой" },
        new { Title = "1984", Author = "Джордж Оруэлл" },
        new { Title = "Собачье сердце", Author = "Михаил Булгаков" },
    };

    var seelction = books.Where(book => book.Author == "Лев Толстой").First();
};

void task_4 () {
    // Задание 4: Использование OrderBy
    // Данные:
    // Список автомобилей в виде массива объектов:

    // Условие:
    // Сортируйте список автомобилей по году выпуска в порядке возрастания.

    var cars = new[]
    {
        new { Brand = "Toyota", Year = 2020 },
        new { Brand = "Honda", Year = 2018 },
        new { Brand = "Ford", Year = 2021 },
    };

    var result = cars.OrderBy(car => car.Year);

};


void task_5 () {
    // Задание 5: Использование GroupBy
    // Данные:
    // Список студентов и их оценки в виде массива объектов:

    // Условие:
    // Группируйте студентов по их оценкам.

    var students = new[]
    {
        new { Name = "Алексей", Grade = 5 },
        new { Name = "Мария", Grade = 4 },
        new { Name = "Дмитрий", Grade = 5 },
        new { Name = "Елена", Grade = 3 },
    };

    var result = students.GroupBy(student => student.Grade);
    foreach(var el in result) {Console.WriteLine($"{el.Key} - {el.Count()}");}
};


void task_6 () {
    // Данные:
    // Список фильмов в виде массива объектов:
    // Условие:
    // Подсчитайте количество фильмов в жанре "Фантастика".
    var movies = new[]
    {
        new { Title = "Звёздные войны", Genre = "Фантастика" },
        new { Title = "Зелёная миля", Genre = "Драма" },
        new { Title = "Властелин колец", Genre = "Фантастика" },
    };

    var result = movies.Where(movie => movie.Genre == "Фантастика").Count();

}

void task_7 () {
    // Задание 7: Использование Any
    // Данные:
    // Список клиентов в виде массива объектов:
    // Убедитесь, есть ли среди клиентов активные клиенты.

    var clients = new[]
    {
        new { Name = "Андрей", IsActive = false },
        new { Name = "Светлана", IsActive = true },
        new { Name = "Николай", IsActive = false },
    };
    var result = clients.Where(client => client.IsActive is true);
    if (result.Any()) Console.WriteLine("Активный клиент есть");
    else Console.WriteLine("Активных клиентов нет");
};


void task_8 () {
    // Задание 8: Использование Last
    // Данные:
    // Список любимых фильмов в виде массива объектов:
    // Условие:
    // Найдите последний фильм в списке по году выпуска.

    var movies = new[]
    {
        new { Title = "Терминатор", Year = 1984 },
        new { Title = "Матрица", Year = 1999 },
        new { Title = "Начало", Year = 2010 },
        new { Title = "Интерстеллар", Year = 2014 },
    };

    var result =  movies.OrderBy(movie => movie.Year).Last();
}

void task_9 () {
    // Задание 9: Использование Distinct
    // Данные:
    // СписокGenres в виде массива объектов:

    // Условие:
    // Получите список уникальных жанров.

    var genres = new[]
    {
        new { Name = "Фантастика" },
        new { Name = "Драма" },
        new { Name = "Приключения" },
        new { Name = "Фантастика" },
        new { Name = "Комедия" },
    };

    var result = genres.DistinctBy(genre => genre.Name);

}

void task_10 () {
    // Задание 10: Использование Take
    // Данные:
    // Список студентов в виде массива объектов:

    // Условие:
    // Возьмите первых 3 студента из списка.

    var students = new[]
    {
        new { Name = "Аня", Age = 18 },
        new { Name = "Борис", Age = 19 },
        new { Name = "Света", Age = 20 },
        new { Name = "Игорь", Age = 21 },
        new { Name = "Фидель", Age = 22 }
    };

    var result = students.Take(3);
}

void task_11 () {
    //     Задание 11: Использование Skip
    // Данные:
    // Список книг в виде массива объектов:
    //Пропустите первые 2 книги и выведите оставшиеся.

    var books = new[]
    {
        new { Title = "1984", Author = "Джордж Оруэлл" },
        new { Title = "Гарри Поттер", Author = "Дж.К. Роулинг" },
        new { Title = "Война и мир", Author = "Лев Толстой" },
        new { Title = "Мастер и Маргарита", Author = "Михаил Булгаков" },
        new { Title = "Убить пересмешника", Author = "Харпер Ли" }
    };

    var result = books.Skip(2);
};


void task_12 () {
    // Задание 12: Использование SelectMany
    // Данные:
    // Список курсов и студентов в виде массивов объектов:
    // Условие:
    // Получите список всех студентов, зарегистрированных на курсы.
    var courses = new[]
    {
        new { CourseName = "Математика", Students = new[] { "Аня", "Борис" } },
        new { CourseName = "Физика", Students = new[] { "Света", "Игорь", "Фидель" } }
    };

    var result = courses.SelectMany(e => e.Students);
}

void task_13 () {
    //     Задание 13: Использование Join
    // Данные:
    // Списки заказов и клиентов в виде массивов объектов:
    // Соедините заказы с клиентами и получите список заказов с именами клиентов.
    var customers = new[]
    {
        new { CustomerId = 1, Name = "Иван" },
        new { CustomerId = 2, Name = "Алексей" },
    };

    var orders = new[]
    {
        new { OrderId = 101, CustomerId = 1 },
        new { OrderId = 102, CustomerId = 2 },
        new { OrderId = 103, CustomerId = 1 },
    };

    var result = from order in orders
            join customer in customers on order.CustomerId equals customer.CustomerId
            select new
            {
                CustomerOrderId = order.OrderId,
                CustomerName = customer.Name
            };
}



