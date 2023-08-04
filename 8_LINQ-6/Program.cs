//Существует класс солдата. В нём есть поля: имя, вооружение, звание, срок службы(в месяцах).
//Написать запрос, при помощи которого получить набор данных состоящий из имени и звания.
//Вывести все полученные данные в консоль.
//(Не менее 5 записей)
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ6
{
    internal class Program
    {
        static void Main()
        {
            Database database = new Database();

            database.Work();
        }
    }

    class Database
    {
        private readonly List<Soldier> _soldiers = new List<Soldier>();

        public Database()
        {
            AddSoldiers();
        }

        public void Work()
        {
            bool isWork = true;

            string commandShowSoldierData = "1";
            string commandExit = "2";

            Console.WriteLine("Получить набор данных солдат - " + commandShowSoldierData);
            Console.WriteLine("Выход - " + commandExit);

            while (isWork)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (userInput == commandShowSoldierData)
                {
                    var newSoldiers = _soldiers.Select(soldier => new
                    {
                        soldier.Name,
                        soldier.Title
                    });

                    foreach (var soldier in newSoldiers)
                    {
                        Console.WriteLine($"Имя - {soldier.Name}, Звание - {soldier.Title}");
                    }
                }
                else if (userInput == commandExit)
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        private void AddSoldiers()
        {
            _soldiers.Add(new Soldier("Ваня", "Штыковая лопата", "Рядовой", 1));
            _soldiers.Add(new Soldier("Вова", "Нож", "Ефрейтор", 2));
            _soldiers.Add(new Soldier("Коля", "Пистолет", "Младший сержант", 6));
            _soldiers.Add(new Soldier("Илья", "Граната", "Сержант", 12));
            _soldiers.Add(new Soldier("Никита", "Автомат", "Старший сержант", 11));
        }
    }

    class Soldier
    {
        public Soldier(string appellation, string weapon, string rank, int durability)
        {
            Name = appellation;
            Armament = weapon;
            Title = rank;
            ServiceLife = durability;
        }

        public string Name { get; private set; }
        public string Armament { get; private set; }
        public string Title { get; private set; }
        public int ServiceLife { get; private set; }
    }
}
