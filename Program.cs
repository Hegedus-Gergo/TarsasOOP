using System;

namespace lud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> palyak = new List<string>();
            List<string> dobasok = new List<string>();

            StreamReader palyaolvaso = new StreamReader("osvenyek.txt");
            while (!palyaolvaso.EndOfStream) { 
            palyak.Add(palyaolvaso.ReadLine());
            }
            StreamReader dobasolvaso = new StreamReader("dobasok.txt");
            while (!dobasolvaso.EndOfStream) {
                string[] egydobas = dobasolvaso.ReadLine().Split(" ");
                for (int i = 0; i < egydobas.Length; i++)
                {
                    dobasok.Add(egydobas[i]);
                }
            }
            dobasolvaso.Close();
            palyaolvaso.Close();
            Console.WriteLine($"2. feladat\nA dobások száma: {dobasok.Count()}\nAz ösvények száma: {palyak.Count()}");

            string leghosszabb = palyak[0];
            int sorszama = -1;
            bool ugyanakkora = false;
            for (int i = 0; i < palyak.Count; i++)
            {
                if (leghosszabb.Length < palyak[i].Length)
                {
                    ugyanakkora = false;
                    leghosszabb = palyak[i];
                    sorszama = i + 1;
                }
                else if (leghosszabb.Length == palyak[i].Length && ugyanakkora == false)
                {
                    ugyanakkora = true;
                }
            }
            if (ugyanakkora == true)
            {
                Console.WriteLine($"\n3. feladat\nAz egyik leghosszabb a(z) {sorszama}. ösvény, hossza: {leghosszabb.Length}");
            }
            else {
                Console.WriteLine($"\n3. feladat\nA leghosszabb a(z) {sorszama}. ösvény, hossza: {leghosszabb.Length}");
            }


            Console.WriteLine("\n4. feladat");
            Console.Write("Adja meg egy ösvény sorszámát! ");
            int osvenysorszama = Convert.ToInt32(Console.ReadLine());
            Console.Write("Adja meg a játékosok számát! ");
            int jatekosok = Convert.ToInt32(Console.ReadLine());


            int m = 0;
            int v = 0;
            int e = 0;
            for (int i = 0; i < palyak[osvenysorszama].Length; i++)
            {
                foreach (char c in palyak[osvenysorszama])
                {
                    if (c == 'm')
                    {
                        m++;
                    }
                    else if (c == 'v')
                    {
                        v++;
                    }
                    else if (c == 'e') {
                        e++;
                    }
                }
            }

            Console.WriteLine($"\n5. feladat\n{(m != 0 ? "M = "+m+" darab\n":' ')}{(v != 0 ? "V = " + v + " darab\n" : ' ')}{(e != 0 ? "E = " + e + " darab\n" : ' ')}");

            StreamWriter sw = new StreamWriter("kulonleges.txt");
            for (int i = 0; i < palyak[osvenysorszama].Length; i++) {
                if (Convert.ToInt16(palyak[osvenysorszama][i]) == Convert.ToInt16("v")) {
                    sw.WriteLine($"{i+1}sorszámú v karakter\t");
                }
                else if (Convert.ToInt16(palyak[osvenysorszama][i]) == Convert.ToInt16("e"))
                {
                    sw.WriteLine($"{i + 1}sorszámú e karakter\t");
                }
            }
                
        }

    }
}