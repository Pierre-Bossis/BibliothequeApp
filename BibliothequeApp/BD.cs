using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApp
{
    internal class BD : Ouvrage
    {
        public BD(string Nom, string Auteur, string Genre) : base(Nom, Auteur, Genre)
        {
            _TypeOuvrage = typeof(BD).Name;
        }

        public override string ReturnType()
        {
            return typeof(BD).Name;
        }
    }
}
