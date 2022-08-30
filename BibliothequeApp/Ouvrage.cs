using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeApp
{
    abstract class Ouvrage
    {
        protected string _Nom;
        protected string _Auteur;
        protected string _Genre;
        protected string _TypeOuvrage;

        public string Nom
        {
            get
            {
                return _Nom;
            }
            set
            {
                _Nom = value;
            }
        }
        public string Auteur
        {
            get
            {
                return _Auteur;
            }
            set
            {
                _Auteur = value;
            }
        }
        public string Genre
        {
            get
            {
                return _Genre;
            }
            set
            {
                _Genre = value;
            }
        }

        public string TypeOuvrage
        {
            get
            {
                return _TypeOuvrage;
            }
        }

        public bool IsEmprunted = false;

        protected Ouvrage(string Nom,string Auteur, string Genre)
        {
            _Nom = Nom;
            _Auteur = Auteur;
            _Genre = Genre;
            
        }
        public virtual string ReturnType()
        {
            return typeof(BD).Name;
        }
    }
}
