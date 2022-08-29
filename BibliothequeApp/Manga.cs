using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApp
{
    internal class Manga : Ouvrage
    {
        public Manga(string Nom,string Auteur,string Genre) : base(Nom, Auteur, Genre)
        {
            _TypeOuvrage = typeof(Manga).Name;
        }
        public override string ReturnType()
        {
            return typeof(Manga).Name;
        }
    }
}
