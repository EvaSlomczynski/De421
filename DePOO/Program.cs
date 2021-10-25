using System;
using System.Collections.Generic;
using System.Linq;

namespace DePOO
{
    public class Declasse
    {
        public int NbFaces = 6;
        public Random random = new Random();
        public int Face { get; protected set; }
        private List<string> faces = new List<string>();

        public Declasse()
        {
            faces.Add("1");
            faces.Add("2");
            faces.Add("3");
            faces.Add("4");
            faces.Add("5");
            faces.Add("6");
            Lancer();
        }
        
        public int Lancer()
        {
            Face = random.Next(1, NbFaces + 1);
            return(Face);
        }

        public string ToString()
        {
            return (Face.ToString());
        }
    }

    class DeTruque : Declasse
    {
        public int Lancer()
        {
            List<int> faceTruq = new List<int>{1,2,3,4,5,5,6,6,6,6,6,6};
            int index = random.Next(faceTruq.Count);
            Face = faceTruq[index];
            return Face;
        } 
    }

    class Jeu
    {
        private readonly int NbManches;
        private readonly int NbDes;
        private readonly int NbDesTruq;
        private List<Declasse> Des = new List<Declasse>();

        public Jeu()
        {
            this.NbManches = 5;
            NbDes = 5;
            DesDes();
        }

        public Jeu(int NbDes, int NbManches)
        {
            this.NbManches = NbManches;
            this.NbDes = NbDes;
            DesDes();
        }

        public Jeu(int NbDes, int NbDesTruq,int nbManches)
        {
            this.NbDes = NbDes;
            this.NbManches = NbManches;
            this.NbDesTruq = NbDesTruq;
            DesDes();
        }

        private void DesDes()
        {
            for (int i = 0; i < NbDes; i++)
            {
                Des.Add(new Declasse());
            }

            for (int i = 0; i < NbDesTruq; i++)
            {
                Des.Add(new DeTruque());
            }
        }

        public void Relancer(int i)
        {
            Des[i].Lancer();
        }

        public int Score()
        {
            int score = 0;
            foreach (Declasse De in Des)
            {
                score += De.Face;
            }
            return score;
        }
        
        public override string ToString()
        {
            string cetruc = "";
            foreach (Declasse Cas in Des)
            {
                cetruc += Cas.ToString() + " ";
            }

            return cetruc;
        }

        public int Run()
        {
            Console.WriteLine(ToString());
            for (int i = 0; i < NbManches; i++)
            {
                Console.WriteLine("Quels dés voulez-vous relancer ?");
                string Relance = Console.ReadLine();
                foreach (char Ca in Relance)
                {
                    if (Char.IsNumber(Ca))
                    {
                        Relancer(Ca - '0' - 1);
                    }
                }

                Console.WriteLine(ToString());
            }

            return Score();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*Declasse de = new Declasse();
            DeTruque detruq = new DeTruque();
            de.Lancer();
            detruq.Lancer();
            Console.WriteLine(de.ToString());
            Console.WriteLine(detruq.ToString());*/

            Jeu jeu = new Jeu();
            Console.WriteLine($"Score : {jeu.Run()}");
        }
    }
}