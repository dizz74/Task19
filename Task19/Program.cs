using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task19
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Computer> comps = new List<Computer> {
            new Computer(){ Code="3H5J",Brand="IRU",CPU="Intel",Freq=1600,Ram=2048,Hdd=200,VideoRam=1024,Cost=244.4,InStock=5},
            new Computer(){ Code="1F4D",Brand="ACER",CPU="Intel",Freq=2200,Ram=4096,Hdd=1000,VideoRam=2048,Cost=288.5,InStock=30},
            new Computer(){ Code="6HJ4",Brand="GG",CPU="Intel",Freq=3200,Ram=1024,Hdd=500,VideoRam=1024,Cost=210.05,InStock=2},
            new Computer(){ Code="2R32",Brand="ACER",CPU="AMD",Freq=2600,Ram=512,Hdd=100,VideoRam=2048,Cost=434.1,InStock=8},
            new Computer(){ Code="2R3R",Brand="MS",CPU="Intel",Freq=2100,Ram=2048,Hdd=200,VideoRam=1024,Cost=311.65,InStock=12},
            new Computer(){ Code="GRF3",Brand="IRU",CPU="AMD",Freq=4200,Ram=4096,Hdd=1000,VideoRam=2048,Cost=290.1,InStock=33},
            new Computer(){ Code="5JJ7",Brand="OK",CPU="Intel",Freq=3000,Ram=1024,Hdd=500,VideoRam=1024,Cost=230.15,InStock=20},
            new Computer(){ Code="2FER",Brand="1C",CPU="AMD",Freq=1500,Ram=128,Hdd=50,VideoRam=512,Cost=112,InStock=1}
            };


            Console.WriteLine("Введите название процессора(Intel / AMD):");
            string needCPU = Console.ReadLine();
            List<Computer> finded1 = comps.Where(c => c.CPU == needCPU).ToList();
            if (finded1 != null && finded1.Count>0)
            {
                foreach (Computer c in finded1) c.PrintInfo();
            }
            else NotFound();


            Console.WriteLine();

            Console.WriteLine("Сколько нужно ОЗУ:");
            int needRAM = Convert.ToInt32(Console.ReadLine());
            List<Computer> finded2 = (from c in comps
                                      where c.Ram > needRAM
                                      select c).ToList();

            if (finded2 != null && finded2.Count > 0)
            {
                foreach (Computer c in finded2) c.PrintInfo();
            }
            else NotFound();


            Console.WriteLine();

            List<Computer> findedSorted = comps.OrderBy(c => c.Cost).ToList();
            Console.WriteLine("По цене:");
            foreach (Computer c in findedSorted) c.PrintInfo();


            Console.WriteLine();

            List<IGrouping<string,Computer>> findedSorted2 = comps.GroupBy(c => c.CPU).ToList();
            Console.WriteLine("По ЦП:");
            foreach (IGrouping<string, Computer> igroup in findedSorted2)
            {
                Console.WriteLine($"{igroup.Key}: ");
                foreach (Computer mComp in igroup) mComp.PrintInfo();
            } 


            Console.WriteLine();

            //Computer comp = comps.Where(c=>c.Cost == comps.Max(c2 => c2.Cost)).First();
            Computer comp = comps.OrderByDescending(c => c.Cost).First();
            Console.WriteLine("Самый дорогой:");
            comp.PrintInfo();

            Console.WriteLine();

            //Computer comp2 = comps.Where(c => c.Cost == comps.Min(c2 => c2.Cost)).First();
            Computer comp2 = comps.OrderBy(c=>c.Cost).First();
            Console.WriteLine("Самый дешевый:");
            comp2.PrintInfo();

            Console.WriteLine();

            Console.WriteLine("В наличии >30:");
            List<Computer> findMore30 = comps.Where(c=>c.InStock>30).ToList();
            if (findMore30 != null && findMore30.Count>0)
            {
                foreach (Computer c in findMore30) c.PrintInfo();
            }
            else NotFound();

            Console.ReadKey();

        }
        static public void NotFound()
        {
            Console.WriteLine("Не найдено");
        }

    }
     



    class Computer
    {
        public string Code { get; set; }
        public string Brand { get; set; }
        public string CPU { get; set; }
        public int Freq { get; set; }
        public int Ram { get; set; }
        public int Hdd { get; set; }
        public int VideoRam { get; set; }
        public double Cost { get; set; }
        public int InStock { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Код:{Code} Марка:{Brand} ЦП:{CPU} {Freq}Mhz ОЗУ:{Ram} HDD:{Hdd} Видео:{VideoRam} {Cost}$ Склад:{InStock}");
        }

    }
}
