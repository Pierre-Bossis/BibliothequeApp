using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace BibliothequeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuer = true;
            List<Ouvrage> Books = new List<Ouvrage>();

            Books.Add(new Manga("Berserk", "Kentaro Miura", "Dark-fantasy"));
            Books.Add(new Manga("Dragon Ball", "Akira Toriyama", "Action"));
            Books.Add(new Manga("Bleach", "Tite Kubo", "Action"));
            Books.Add(new Manga("Burn The Witch", "Tite Kubo", "Action"));
            Books.Add(new Manga("One Piece", "Eichiro Oda", "Aventure"));
            Books.Add(new Manga("Dragon Ball Z", "Akira Toriyama", "Action"));
            Books.Add(new Manga("Gintama", "Hideaki Sorachi", "Comédie"));
            Books.Add(new BD("Aquaman", "Paul Norris", "Super-Hero"));
            Books.Add(new BD("Captain America", "Joe Simon", "Super-Hero"));
            Books.Add(new BD("Spiderman", "Stan Lee", "Super-Hero"));
            Books.Add(new BD("Batman", "Bob Kane", "Super-Hero"));
            Books.Add(new BD("Doctor Strange", "Stan Lee", "Super-Hero"));
            Books.Add(new Roman("Misery", "Stephen King", "Thriller"));
            Books.Add(new Roman("Et si c'était vrai", "Marc Levy", "Comédie romantique"));
            Books.Add(new Roman("Harry Potter", "J.K. rowling", "Fantaisie"));
            Books.Add(new Manga("Dragon Ball Super", "Akira Toriyama", "Action"));
            Books.Add(new Roman("L'autre intégrale", "Pierre Bottero", "Action"));
            
            while (continuer == true)
            {

                Console.WriteLine("Que souhaitez vous faire ?(search/location/rendre ouvrage/exit)");
                string Response = Console.ReadLine();



                if (Response == "search")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Par quoi souhaitez vous chercher ? (type d'ouvrage/nom/auteur/genre)");
                    Console.WriteLine("");
                    Response = Console.ReadLine();

                    if (Response == "nom")
                    {
                        Console.WriteLine("veuillez entrer le nom de l'ouvrage que vous cherchez :");
                        Console.WriteLine("");
                        string NomLivre = Console.ReadLine();

                        var FilterNom = from Book in Books
                                        where NomLivre == Book.Nom && Book.IsEmprunted == false
                                        select new { Book.Nom, Book.Auteur, Book.Genre } + "\n";
                        if(FilterNom.Any())
                            Console.WriteLine(String.Join(' ', FilterNom));
                        
                        else
                        
                            Console.WriteLine("L'ouvrage a été emprunté ou n'existe pas.");
                        


                    }
                    else if (Response == "auteur")
                    {
                        Console.WriteLine("veuillez entrer l'auteur de l'ouvrage que vous cherchez :");
                        Console.WriteLine("");
                        string AuteurLivre = Console.ReadLine();

                        var FilterAuteur = from Book in Books
                                           where AuteurLivre == Book.Auteur && Book.IsEmprunted == false
                                           select new { Book.Nom, Book.Auteur, Book.Genre } + "\n";
                        if(FilterAuteur.Any())
                        Console.WriteLine(String.Join(' ', FilterAuteur));
                        else
                            Console.WriteLine($"Nous ne possédons aucun ouvrage de l'auteur {AuteurLivre}.");

                    }
                    else if (Response == "genre")
                    {
                        Console.WriteLine("veuillez entrer le genre de l'ouvrage que vous cherchez :");
                        Console.WriteLine("");
                        string GenreLivre = Console.ReadLine();

                        var FilterGenre = from Book in Books
                                          where GenreLivre == Book.Genre && Book.IsEmprunted == false
                                          select new { Book.Nom, Book.Auteur, Book.Genre } + "\n";
                        if(FilterGenre.Any())
                        Console.WriteLine(String.Join(' ', FilterGenre));
                        else
                            Console.WriteLine($"Nous ne possédons aucun ouvrage du genre {GenreLivre}.");
                    }
                    else if (Response == "type d'ouvrage")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Quel type d'ouvrage cherchez-vous ?(BD/Manga/Roman)");
                        Response = Console.ReadLine();
                        if (Response == "BD")
                        {
                            Console.WriteLine("Voici la liste de nos BD : ");
                            var FilterType = from Book in Books
                                             where Book.TypeOuvrage == "BD" && Book.IsEmprunted == false
                                             select new { Book.Nom, Book.Auteur, Book.Genre } + "\n";
                            Console.WriteLine(String.Join(' ', FilterType));
                        }
                        else if (Response == "Manga")
                        {
                            Console.WriteLine("Voici la liste de nos Mangas : ");
                            var FilterType = from Book in Books
                                             where Book.TypeOuvrage == "Manga" && Book.IsEmprunted == false
                                             select new { Book.Nom, Book.Auteur, Book.Genre } + "\n";
                            Console.WriteLine(String.Join(' ', FilterType));

                        }
                        else if (Response == "Roman")
                        {
                            Console.WriteLine("Voici la liste de nos romans : ");
                            var FilterType = from Book in Books
                                             where Book.TypeOuvrage == "Roman" && Book.IsEmprunted == false
                                             select new { Book.Nom, Book.Auteur, Book.Genre } + "\n";
                            Console.WriteLine(String.Join(' ', FilterType));

                        }
                        else
                        {
                            Console.WriteLine("Nous ne possédons pas ce genre d'ouvrage.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Réponse non valide.");
                    }
                }
                else if (Response == "location")
                {
                    Console.WriteLine("Quel ouvrage souhaitez vous-emprunter ?");
                    string NomLivre = Console.ReadLine();
                    var FilterNom = from Book in Books
                                    where NomLivre == Book.Nom
                                    select Book.Nom;
                    foreach (var item in Books.Where(who => who.Nom == NomLivre))
                    {
                        item.IsEmprunted = true;
                    }

                    if (FilterNom.Any())
                    {
                        Console.WriteLine("Le livre que vous venez d'emprunter est : " + "\n" + "\n" + string.Join(' ', FilterNom));
                        Console.WriteLine("");

                    }
                    else
                    {
                        Console.WriteLine("Le livre n'existe pas ou à déjà été emprunté.");
                    }

                }
                else if ( Response == "rendre ouvrage")
                {
                    var VerifyIfBookIsEmprunted = from Book in Books
                                        where Book.IsEmprunted == true
                                        select Book;
                    if (VerifyIfBookIsEmprunted.Any())
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Voici la liste des ouvrages loués : ");
                        Console.WriteLine("");
                        var OuvragesLoues = from Book in Books
                                            where Book.IsEmprunted == true
                                            select Book.Nom + "\n";
                        Console.WriteLine(String.Join(' ', OuvragesLoues));
                        Console.WriteLine("");
                        Console.WriteLine("Quel ouvrage souhaitez-vous rendre ?");
                        Response = Console.ReadLine();

                        bool found = false;

                        foreach (var Book in Books)
                        {
                            if (Response == Book.Nom && Book.IsEmprunted == true)
                            {
                                Book.IsEmprunted = false;
                                found = true;
                            }
                        }
                        if (found == true)
                        {
                            Console.WriteLine($"{Response} a bien été rendu à la Bibliothèque.");
                        }
                        else
                        {
                            Console.WriteLine("Ce livre n'existe pas ou n'est pas en location.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Aucun livre n'a été loué.");
                    }
                }

                else if (Response == "exit")
                {
                    Environment.Exit(0);
                }
            }
        }

    }
}