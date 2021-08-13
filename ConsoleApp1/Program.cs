using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======  Nos Ordinateurs ========" );

            Ordinateur monOrdi = new Ordinateur("MemoryPc", 01101, 1400, "Ryzen 5; 2060 Super; 16GB RAM");
            Ordinateur tonOrdi = new Ordinateur("Memory", 01102, 1400, "Ryzen 5; 2060 Super; 16GB RAM");
            
           // Console.WriteLine(monOrdi.caracteristiques);
           // Console.WriteLine(tonOrdi.caracteristiques);
           
           // monOrdi.Decrire();
           // tonOrdi.Decrire();

           Portable p1 = new Portable("DELL", 01103,800, "Ryzen 5; 1060 Ti; 16GB RAM", "17''");
           p1.Decrire();

           Macbook m1 = new Macbook("Macbook Pro", 01104, 1800, "Ryzen 5; 1060 Ti; 16GB RAM", "17''", "Léopard");
           m1.Decrire();
           
           List<Ordinateur> ordis =  new List<Ordinateur>();
           {
               new Ordinateur("HP Omen", 01105, 1500, "IntelCore i7; RTX 2080; 16GB RAM");
               new Ordinateur("AlienWare A51", 01106, 1750, "IntelCore i5; RTX 2060; 16GB RAM");
               new Ordinateur("Asus ROG", 01107, 1380, "IntelCore i9; 2070 Ti; 32GB RAM");
               new Ordinateur("Acer Predator", 01108, 1980, "IntelCore i7; RTX 3080 Ti; 32GB RAM");
           }
           ;

           foreach (Ordinateur o in ordis)
           {
               o.Decrire();
           }
           Console.WriteLine(" ======== FIN ==========");
        }
        
    }
    
    // Interface poru décrire un ordi
    interface IDescriptible
    {
        void Decrire();
    }

    // Ordinateur
    class Ordinateur : IDescriptible
    {
        // Propriétés, caractéristique de la classe ...
        public string nom { get; set; }
        public int reference { get; set; }
        public int prix { get; set; }
        public string caracteristiques { get; set; }
        
        
        // Var statique
        private static int nbOrdis = 0;
        
        
        // Constructeur
        public Ordinateur(string nom, int reference, int prix, string caracteristiques)
        {
            this.nom = nom;
            this.reference = reference;
            this.prix = prix;
            this.caracteristiques = caracteristiques;

            nbOrdis++;
        }

        public virtual void Decrire()
        {
            Console.WriteLine(nom + "(" + reference + ")");
            DecrireCaracteristiques();
            Console.WriteLine(" Prix TTC : " + prix);

            if (nbOrdis > 5)
            {
                Console.WriteLine("Nous avons beaucoup d'ordinateur en stock");
                
                Console.WriteLine("****************************************");
            }
        }

        protected void DecrireCaracteristiques()
        {
            Console.WriteLine("*** Caracteristique de l'ordinateur ***");
            string[] caracts = caracteristiques.Split(";");
            Console.WriteLine("CPU : " + caracts[0]);
            Console.WriteLine("GPU : " + caracts[1]);
            Console.WriteLine("RAM : " + caracts[2]);
        }
    }

    class Portable : Ordinateur
    {
        string tailleEcran;
        
        public Portable(string nom, int reference, int prix, string caracteristiques, string tailleEcran) : base(nom,reference,prix,caracteristiques)
        {
            this.tailleEcran = tailleEcran;
        }

        public override void Decrire()
        {
            base.Decrire();
            Console.WriteLine("Laptop avec ecran de " + tailleEcran);
            
        } 
        
    }

    class Macbook : Portable
    {
        string os;

        public Macbook(string nom, int reference, int prix, string carateristiques, string tailleEcran, string os) :
            base(nom, reference, prix, carateristiques, tailleEcran)
        {
            this.os = os;
        }

        public override void Decrire()
        {
            base.Decrire();
            Console.WriteLine("Macbook avec MAC OS version " + os);
        }
    }
}