using System;
using System.Collections.Generic;
using System.Text;

namespace AppData.Models
{
   public class Client
    {
        public Client() {
            id = new int();
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
