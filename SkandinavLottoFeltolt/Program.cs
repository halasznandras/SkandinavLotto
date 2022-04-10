using SkandinavAdat.Data;
using SkandinavAdat.Models;
using System;
using System.IO;
using System.Linq;

namespace SkandinavLottoFeltolt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SkandinavAdatContext db = new SkandinavAdatContext();

            if (!db.LottoSzamok.Any())
            {
                var sorok = File.ReadAllLines(@"C:\temp\SkandinavLottoSzamok.csv").Skip(1);
                string[] JoSorok = sorok.ToArray();
                int[] tombSzam = new int[7];
                foreach (var sor in JoSorok)
                {
                    string[] tombSor = sor.Split(";");
                    

                    for (int i = 1; i <= 7; i++)
                    {
                        tombSzam[i-1] = Convert.ToInt32(tombSor[i]);
                        db.LottoSzamok.Add(new LottoSzam(tombSzam));
                    }

                    for (int i = 1; i <= 7; i++)
                    {
                        tombSzam[i-1] = Convert.ToInt32(tombSor[i+7]);
                        db.LottoSzamok.Add(new LottoSzam(tombSzam));
                    }
                }
                db.SaveChanges();

                
            }
            else
            {
                Console.WriteLine("A Lottó Számok tábla már tartalmaz adatokat!");
            }
        }
    }
}
