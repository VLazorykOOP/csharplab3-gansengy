namespace Lab3CSharp
{
            class ITriangle
        {
            // Поля
            protected int a; // Сторона основи
            protected int b; // Бічна сторона
            protected int color; // Колір

            // Конструктор
            public ITriangle(int baseSide, int side, int col)
            {
                a = baseSide;
                b = side;
                color = col;
            }

            // Методи
            public void PrintDimensions()
            {
                Console.WriteLine($"Сторона основи: {a}, Бічна сторона: {b}");
            }

            public int Perimeter()
            {
                return 2 * a + b;
            }

            public double Area()
            {
                return 0.5 * a * Math.Sqrt(Math.Pow(b, 2) - Math.Pow(a / 2.0, 2));
            }

            public bool IsEquilateral()
            {
                return b == Math.Sqrt(2 * Math.Pow(a / 2.0, 2));
            }

            // Властивості
            public int BaseSide
            {
                get { return a; }
                set { a = value; }
            }

            public int Side
            {
                get { return b; }
                set { b = value; }
            }

            public int Color
            {
                get { return color; }
            }
        }

    ///2

            class Employee
        {
            public string Name { get; set; }
            public double Salary { get; set; }

            public Employee(string name, double salary)
            {
                Name = name;
                Salary = salary;
            }

            public virtual void Show()
            {
                Console.WriteLine($"Ім'я: {Name}, Заробітна плата: {Salary}");
            }
        }

        class HR : Employee
        {
            public int InterviewsCount { get; set; }

            public HR(string name, double salary, int interviewsCount) : base(name, salary)
            {
                InterviewsCount = interviewsCount;
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Кількість проведених співбесід: {InterviewsCount}");
            }
        }

        class Engineer : Employee
        {
            public string Specialization { get; set; }

            public Engineer(string name, double salary, string specialization) : base(name, salary)
            {
                Specialization = specialization;
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Спеціалізація: {Specialization}");
            }
        }

        class Administration : Employee
        {
            public string Position { get; set; }

            public Administration(string name, double salary, string position) : base(name, salary)
            {
                Position = position;
            }

            public override void Show()
            {
                base.Show();
                Console.WriteLine($"Посада: {Position}");
            }
        }

    internal class Program
    {
        static Random random = new Random();

    static Employee GenerateRandomEmployee()
    {
            string[] names = { "Павло", "Петро", "Маруся", "Ольга", "Василь", "Тетяна" };
            string name = names[random.Next(names.Length)];

            double salary = random.Next(1500, 4000);

            int choice = random.Next(3); // Випадковий вибір типу працівника
            switch (choice)
            {
                case 0:
                    return new HR(name, salary, random.Next(5, 20)); // HR з випадковою кількістю проведених співбесід
                case 1:
                    return new Engineer(name, salary, "Спеціалізація " + random.Next(1, 6)); // Інженер з випадковою спеціалізацією
                case 2:
                    return new Administration(name, salary, "Посада " + random.Next(1, 4)); // Адміністрація з випадковою посадою
                default:
                    throw new Exception("Непідтримуваний тип працівника");
            }
        }
        static void Main(string[] args)
        {
            static void task1(){
            Console.WriteLine("Введіть кількість трикутників:");
            int n = int.Parse(Console.ReadLine());

            ITriangle[] triangles = new ITriangle[n];

            // Введення даних
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Трикутник {i + 1}:");
                Console.WriteLine("Введіть сторону основи:");
                int baseSide = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть бічну сторону:");
                int side = int.Parse(Console.ReadLine());
                Console.WriteLine("Введіть колір:");
                int color = int.Parse(Console.ReadLine());

                triangles[i] = new ITriangle(baseSide, side, color);
            }

            // Виведення інформації про трикутники
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Інформація про трикутник {i + 1}:");
                triangles[i].PrintDimensions();
                Console.WriteLine($"Периметр: {triangles[i].Perimeter()}");
                Console.WriteLine($"Площа: {triangles[i].Area()}");
                Console.WriteLine($"Чи є правильним: {triangles[i].IsEquilateral()}");
                Console.WriteLine();
            }

            // Підрахунок кількості правильних трикутників
            int equilateralCount = 0;
            foreach (ITriangle triangle in triangles)
            {
                if (triangle.IsEquilateral())
                {
                    equilateralCount++;
                }
            }

            Console.WriteLine($"Загальна кількість правильних трикутників: {equilateralCount}");
            }
            static void task2(){
            List<Employee> employees = new List<Employee>();

            // Наповнення масиву рандомними об'єктами похідних класів
            for (int i = 0; i < 10; i++)
            {
                employees.Add(GenerateRandomEmployee());
            }

            // Виведення масиву
            Console.WriteLine("Масив рандомних працівників:");
            foreach (var employee in employees)
            {
                employee.Show();
                Console.WriteLine();
            }
            }
           
            while(true){
                Console.WriteLine("  ****  Lab 3  ****  \n\n");
                Console.Write("Press 0 to exit\n");
                Console.Write("Which task would you like to review ? (1-4) : ");
                string? str = Console.ReadLine();
                if ( str == "0") break;
                if (str != null && short.TryParse(str, out short ans))
                {
                    switch (ans)
                {
                    case 1: { task1(); break; }
                    case 2: { task2(); break; }
                    
                    default: { Console.WriteLine("Put the correct number"); break; }
                }
                }
            }

            }
        }
}

