using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Block_8_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ФИО;");
            XElement Header = new XElement("Person", new XAttribute("name", Console.ReadLine()));
            Console.WriteLine("Введите Улицу");
            XElement Address = new XElement("Address", new XElement("Street",Console.ReadLine()));
            Console.WriteLine("Введите номер дома");
            Address.Add(new XElement("HouseNumber", Console.ReadLine()));
            Console.WriteLine("Введите номер квартиры");
            Address.Add(new XElement("FlatNumber", Console.ReadLine()));
            Header.Add(Address);
            XElement Phones = new XElement("Address");
            Console.WriteLine("Введите номер телефона");
            Phones.Add(new XElement("MobilePhone", Console.ReadLine()));
            Console.WriteLine("Введите домашний телефон");
            Phones.Add(new XElement("FlatPhone", Console.ReadLine()));
            Header.Add(Phones);
            Header.Save("Bezobrazie.xml");
            Console.ReadKey();
        }
    }
}
