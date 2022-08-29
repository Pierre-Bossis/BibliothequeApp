using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApp
{
    internal class Roman : Ouvrage
    {
        public Roman(string Nom, string Auteur, string Genre) : base(Nom, Auteur, Genre)
        {
            _TypeOuvrage = typeof(Roman).Name;
        }
        public override string ReturnType()
        {
            return typeof(Roman).Name;
        }
    }
}
