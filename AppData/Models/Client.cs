using System;
using System.Collections.Generic;
using System.Text;

namespace AppData.Models
{
   public class Client
    {
        public Client() {

            Random random = new Random();
            id =  random.Next(1000);
            Sexe = 'F';
            Etat_Civil = "M";
            //Carte_Fidelite = true;
            //Carte_Credit = false;

        }
        public Client(int id)
        {

            this.id = id;
        }


        public int id { get; set; }
        public string Nom { get;  set; }
        public string Prenom { get; set; }
        public char Sexe { get; set; }
        public string Adresse { get; set; }
        public decimal Telephone { get; set; }
        public string Etat_Civil { get; set; }
        public bool Carte_Credit { get; set; }
        public bool Carte_Fidelite { get; set; }
        public int Age { get; set; }








    }
}
