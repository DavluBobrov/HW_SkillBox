using System;

namespace Block_7
{
    internal struct Worker
    {
        #region Свойства полей

        public int ID { get; }
        public int Age { get; }
        public int Heigth { get; }
        public string FullName { get; }
        public string BirthPlace { get; }
        public DateTime DateAdd { get; }
        public DateTime DateOfBirth { get; }

        #endregion Свойства полей

        /// <summary>
        /// Конструктор для добавления НОВОГО сотрудника
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="heigth">Рост</param>
        /// <param name="fullName">ФИО</param>
        /// <param name="birthPlace">Место рождения</param>
        /// <param name="dateОfBirth">Дата рождения</param>
        public Worker(int id, int heigth, string fullName, string birthPlace, DateTime dateОfBirth)
            : this(id, DateTime.Now, fullName, 0, heigth, dateОfBirth, birthPlace)
        {
            this.Age = DateAdd.Year - dateОfBirth.Year;
            this.Age -= this.DateOfBirth >= DateAdd.AddYears(-this.Age) ? 1 : 0;
        }

        /// <summary>
        /// Конструктор для заполнения массива в CollectionDir.cs из файла
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateAdd"></param>
        /// <param name="age"></param>
        /// <param name="heigth"></param>
        /// <param name="fullName"></param>
        /// <param name="birthPlace"></param>
        /// <param name="dateОfBirth"></param>
        public Worker(int id, DateTime dateAdd, string fullName, int age, int heigth, DateTime dateОfBirth, string birthPlace)
        {
            this.ID = id;
            this.Age = age;
            this.Heigth = heigth;
            this.FullName = fullName;
            this.BirthPlace = birthPlace;
            this.DateOfBirth = dateОfBirth;
            this.DateAdd = dateAdd;
        }

        public static bool operator ==(Worker left, Worker right)
        {
            if (left.ID == right.ID) return true;
            else return false;
        }

        public static bool operator !=(Worker left, Worker right)
        {
            if (left.ID != right.ID) return true;
            else return false; ;
        }
    }
}