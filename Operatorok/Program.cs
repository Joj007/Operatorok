using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Operatorok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Operátor> operatorok = new List<Operátor> ();
            foreach (string sor in File.ReadLines("szoveg.txt"))
            {
                string[] adatok = sor.Split();
                operatorok.Add(new Operátor(int.Parse(adatok[0]), adatok[1], int.Parse(adatok[2])));
            }

            Console.WriteLine($"2. feladat: Kifejezések száma: {operatorok.Count()}");

            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {operatorok.Count(n=>n.MuveletiJel=="mod")}");

            Console.Write("4. feladat: ");
            Console.WriteLine(operatorok.Any(n => n.EloTag % 10 == 0 && n.UtoTag % 10 == 0) ? "Van ilyen kifejezés!" : "Nincs ilyen kifejezés!");

            Console.WriteLine("5. feladat: Statisztika");
            string[] megfeleloOperatorok = {"mod", "/", "div", "-", "*", "+"};
            operatorok.Where(n=>megfeleloOperatorok.Contains(n.MuveletiJel)).GroupBy(n => n.MuveletiJel).ToList().ForEach(n=>Console.WriteLine($"\t{n.Key} -> {n.Count()} db"));

            Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
            string bekeres = Console.ReadLine();
            string[] bekertAdatok;
            while (bekeres!="vége"){
                bekertAdatok = bekeres.Split();
                try
                {
                    Console.WriteLine($"\t{bekeres} = {Operátor.Kiszamol(int.Parse(bekertAdatok[0]), bekertAdatok[1], int.Parse(bekertAdatok[2]))}");
                }
                catch (Exception)
                {
                    Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                    bekeres = Console.ReadLine();
                    continue;
                }
                Console.Write("7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                bekeres = Console.ReadLine();
            };


            operatorok.ForEach(n => File.WriteAllText("eredmenyek.txt", $"{n.EloTag} {n.MuveletiJel} {n.UtoTag} = {Operátor.Kiszamol(n.EloTag, n.MuveletiJel, n.UtoTag)}"));

            


        }
    }
}
