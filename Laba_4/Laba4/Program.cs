using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Laba4
{

    public class Set //класс Set
    {
        private readonly Owner owner;
        public HashSet<String> collection;
        private readonly Date date;
        public int Size;

        public Set(int ownerId, string ownerFIO)
        {
            this.owner = new Owner(ownerId, ownerFIO);
            this.collection = new HashSet<string>();
            this.date = new Date();
        }

        public HashSet<string> GetHash()
        {
            return collection;
        }

        public void Show()
        {
            foreach (string item in collection)
            {
                Console.WriteLine(item);
            }
        }

        public Owner GetOwner()
        {
            return owner;
        }

        public int GetSize()
        {
            int size = 0;
            foreach (string item in collection)
            {
                size++;
            }
            return size;
        }

        public void AddItem(string item) //добавление элемента
        {
            collection.Add(item);
        }

        public class Date //вложенный класс Date
        {
            public readonly DateTime time;

            public Date()
            {
                time = DateTime.Now;
            }
        }

        public string GetItemByIndex(int index) //получить элемент по индексу
        {
            if (index > this.GetSize() - 1)
                throw new Exception("GetItemByIndex: OutOfRange");

            int size = -1;
            foreach (string item in collection)
            {
                size++;
                if (size == index)
                    return item;
            }
            return "";
        }

        #region Overload

        public static Set operator -(Set set, string item)
        {
            set.collection.Remove(item);
            return set;
        }

        public static Set operator *(Set set, Set set2)
        {
            set.collection.IntersectWith(set2.collection);
            return set;
        }

        public static bool operator <(Set set, Set set2)
        {
            return set.GetSize() < set2.GetSize();
        }

        public static bool operator >(Set set, Set set2)
        {
            if (set.collection.IsSubsetOf(set2.collection))
                return true;
            else
                return false;
        }

        public static Set operator &(Set set, Set set2)
        {
            set.collection.Except(set2.collection);
            return set;
        }
        public class Owner //вложенный класс Owner
        {
            private readonly int id;
            private readonly string fio;

            public Owner(int id, string fio)
            {
                this.id = id;
                this.fio = fio;
            }

            public void GetInfo()
            {
                Console.WriteLine($"Owner - ID: {id}, FIO: {fio}");
            }
        }
        #endregion
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Set set = new Set(1, "SYO");
            set.AddItem("Max");
            set.AddItem("Nick");

            Set set2 = new Set(2, "BEI");
            set2.AddItem("Max");
            set2.AddItem(" ");
            set2.AddItem("Lia");
            set2.AddItem("Nick");

            Set set3 = new Set(3, "LIO");
            set3.AddItem("Jio");
            set3.AddItem("Mari");

            Set set4 = new Set(4, "KPF");
            set4.AddItem("Jhon");
            set4.AddItem("");
            set4.AddItem("Leo");

            Console.WriteLine("--------- Перегрузка оператора - ---------");
            string name = "Jio";
            set3 = set3 - name;
            set3.Show();
            Console.WriteLine("--------- Перегрузка оператора * ------------");
            set2 = set2 * set;
            set2.Show();

            Console.WriteLine("--------- Перегрузка оператора & ----------------");
            set3 = set3 & set;
            set3.Show();

            Console.WriteLine("--------- Перегрузка оператора > ----------------");
            Console.WriteLine(set > set2);

            Console.WriteLine("--------- Перегрузка оператора < ----------------");
            Console.WriteLine(set < set2);
            Console.WriteLine("----------------Удаление нулевых элементов из множества---------------------");
            Console.WriteLine("До:");
            set4.Show();
            Console.WriteLine("После:");
            set4.RemoveSpace();
            set4.Show();
            Console.WriteLine("----------------Добавление точки в конец строки-----------------------------");
            set4.DotAfterWord();
            set4.Show();
        }
    }
}
