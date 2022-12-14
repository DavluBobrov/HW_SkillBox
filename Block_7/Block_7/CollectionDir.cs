using System;
using System.IO;
using System.Text;
using static System.Console;

namespace Block_7
{
    internal struct CollectionDir
    {
        private int index;
        private readonly string path;
        private Worker[] workArray;

        int Count { get { return index + 1; } }
        int MaxID { get; set; }
        string Path { get { return path; } }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="path">Путь до справочника</param>
        public CollectionDir(string path)
        {
            this.path = path;
            this.MaxID = 0;
            this.index = -1;
            this.workArray = new Worker[1];
            InitCollection();
        }

        /// <summary>
        /// Инициализация Коллекции
        /// </summary>
        private void InitCollection()
        {
            using (FileStream fs = File.OpenRead(path))
            {
                fs.Seek(5, new SeekOrigin());
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
            }
            using StreamReader sr = new(Path);
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (s != string.Empty)
                {
                    string[] arg = s.Split("#");
                    Worker w = ParserLineFile(arg);
                    AddWorkerInCollection(w);
                    FindMaxID(w.ID);
                }
            }
        }

        #region Public Methods

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns>Возвращает Worker из коллекции по его ID</returns>
        public Worker this[int ID]
        {
            get
            {
                return GetWorker(ID, out _);
            }
        }

        /// <summary>
        /// Печать данных сотрудника в консоль
        /// </summary>
        /// <param name="ID">ID</param>
        public void PrintWorker(int ID)
        {
            Worker w = GetWorker(ID, out _);
            if (w != new Worker())
            {
                PrintWorker(w);
            }
            else Console.WriteLine("ID не найден.");
        }

        /// <summary>
        /// Печать данных сотрудника в консоль
        /// </summary>
        /// <param name="w">Структура Worker</param>
        public static void PrintWorker(Worker w)
        {
            Console.WriteLine($"{w.ID,2}{w.DateAdd.ToShortDateString() + " " + w.DateAdd.ToShortTimeString(),20}" +
                $"{w.FullName,30}{w.Age,8}{w.Heigth,5}{w.DateOfBirth.ToShortDateString(),15}{w.BirthPlace,15}");
        }

        /// <summary>
        /// Печать шапки в консоль
        /// </summary>
        public static void PrintTitle()
        {
            Console.WriteLine($"{"ID",2}{"Дата записи",20}{"Полное Имя",30}" +
                        $"{"Возраст",8}{"Рост",5}{"Дата рождения",15}{"Место рождения",15}\n");
        }

        /// <summary>
        /// Печать коллекции
        /// </summary>
        public void PrintCollection()
        {
            PrintTitle();
            foreach (var w in workArray)
            {
                if (w.ID != 0) PrintWorker(w);
            }
        }

        /// <summary>
        /// Сортировка коллекции по дате создания записи
        /// </summary>
        public void SortCollection(bool flagReverse = false)
        {
            DateTime[] datarr = new DateTime[Count];
            for (int i = 0; i < Count; i++)
            {
                datarr[i] = workArray[i].DateAdd;
            }
            Array.Sort(datarr, workArray);
            if (flagReverse) Array.Reverse(workArray, 0, Count);
        }

        /// <summary>
        /// Сохранение коллекции в файл
        /// </summary>
        public void Save()
        {
            string[] arr = new string[Count];
            int j = 0;
            for (int i = 0; i < Count; i++)
            {
                if (workArray[i].ID != 0)
                {
                    arr[j] = WorkerToString(workArray[i]);
                    j++;
                }
            }
            File.WriteAllLines(Path, arr);
        }

        /// <summary>
        /// Метод добавления нового сотрудника
        /// </summary>
        /// <param name="dirPath">Путь до Справочника</param>
        public void AddMember(string dirPath)
        {
            // 1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
            int ID = MaxID + 1;
            MaxID++;
            string FullName = "";

            #region Data Input

            Console.Write("Введите Имя: ");
            FullName += $"{ReadLine()} ";
            Console.Write("Введите Фамилию: ");
            FullName += $"{ReadLine()} ";
            Console.Write("Введите Отчество: ");
            FullName += ReadLine();
            Console.Write("Введите Рост: ");
            int heigth = Int32.Parse(ReadLine());
            Console.Write("Введите Дату рождения через точку (01.01.2000): ");
            DateTime DateОfBirth = DateTime.Parse(ReadLine());
            Console.Write("Введите Место рождения: ");
            string birthPlace = ReadLine();

            #endregion Data Input

            Worker w = new(ID, heigth, FullName, birthPlace, DateОfBirth);

            //int age = (dateAdd - DateОfBirth).Days / 365;        // Вычисление возраста
            string addText = WorkerToString(w) + "\n";
            File.AppendAllText(dirPath, addText);
        }

        /// <summary>
        /// Изменение данных сотрудника
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        public void EditingMember(int ID)
        {
            // 1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
            Console.WriteLine("Старе данные: ");
            PrintWorker(ID);
            GetWorker(ID, out int i);

            string FullName = "";

            #region Data Input

            Console.Write("Введите Имя: ");
            FullName += $"{ReadLine()} ";
            Console.Write("Введите Фамилию: ");
            FullName += $"{ReadLine()} ";
            Console.Write("Введите Отчество: ");
            FullName += ReadLine();
            Console.Write("Введите Рост: ");
            int heigth = Int32.Parse(ReadLine());
            Console.Write("Введите Дату рождения через точку (01.01.2000): ");
            DateTime DateОfBirth = DateTime.Parse(ReadLine());
            Console.Write("Введите Место рождения: ");
            string birthPlace = ReadLine();

            #endregion Data Input

            Worker w = new(ID, heigth, FullName, birthPlace, DateОfBirth);
            workArray[i] = w;
        }

        /// <summary>
        /// Удаление данных сотрудника
        /// </summary>
        /// <param name="ID">ID Сотрудника</param>
        public void RemoveMember(int ID)
        {
            //string newText = string.Empty;
            GetWorker(ID, out int index);
            for (int i = index; i < Count - 1; i++)
            {
                workArray[i] = workArray[i + 1];
            }
            Array.Resize(ref workArray, workArray.Length - 1);
            this.index--;
            Save();
        }

        /// <summary>
        /// Печать данных по диапазону дат добавления записи
        /// </summary>
        /// <param name="time1">Нижний порог даты</param>
        /// <param name="time2">Верхний порог даты</param>
        public void PrintDateRange(DateTime time1, DateTime time2)
        {
            foreach (var w in workArray)
            {
                if (w.DateAdd >= time1 && w.DateAdd <= time2.AddDays(1))
                    PrintWorker(w);
            }
        }

        #endregion Public Methods

        #region static Methods

        /// <summary>
        /// Преобразования данных сотрудника в строку
        /// </summary>
        /// <param name="w">структура Worker</param>
        /// <returns>Возвращает преобразованные данные в виде строки с разделителями # для добавления в справочник</returns>
        private static string WorkerToString(Worker w)
        {
            return $"{w.ID}#{w.DateAdd.ToShortDateString()} {w.DateAdd.ToShortTimeString()}" +
                   $"#{w.FullName}#{w.Age}#{w.Heigth}#{w.DateOfBirth.ToShortDateString()}#{w.BirthPlace}";
        }

        /// <summary>
        /// Преобразование данных из справочника
        /// </summary>
        /// <param name="str">Массив слов</param>
        /// <returns>Возвращает данные в виде структуры Worker для добавления в коллекцию</returns>
        private static Worker ParserLineFile(string[] str)
        {
            return new Worker(Int32.Parse(str[0]), DateTime.Parse((str[1])), str[2],
                Int32.Parse(str[3]), Int32.Parse(str[4]), DateTime.Parse(str[5]), str[6]);
        }

        #endregion static Methods

        #region private Methods

        /// <summary>
        /// Метод присваивания максимального ID
        /// </summary>
        /// <param name="id">Сравниваемый ID с максимальным</param>
        private void FindMaxID(int id)
        {
            MaxID = (id > MaxID) ? id : MaxID;
        }

        /// <summary>
        /// Увеличение размера коллекции
        /// </summary>
        /// <param name="flag">Требование увеличение</param>
        private void Resize(bool flag)
        {
            if (flag) Array.Resize(ref workArray, workArray.Length + 1);
        }

        /// <summary>
        /// Добавление Данных сотрудника в коллекцию
        /// </summary>
        /// <param name="worker">Структура Worker</param>
        private void AddWorkerInCollection(Worker worker)
        {
            this.index++;
            this.Resize(index >= this.workArray.Length);
            this.workArray[index] = worker;
        }

        /// <summary>
        /// Получение Worker коллекии
        /// </summary>
        /// <param name="ID">ID сотрудника</param>
        /// <param name="index">индекс в коллекции</param>
        /// <returns>Возвращает структурированные данные сотрудника Worker</returns>
        private Worker GetWorker(int ID, out int index)
        {
            index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (workArray[i].ID == ID)
                {
                    index = i;
                    return workArray[i];
                }
            }
            return new Worker();
        }

        #endregion private Methods
    }
}