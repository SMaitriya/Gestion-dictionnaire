using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace GestionDictionnaire {
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* Déclaration de variables*/
            int unChoix;
            string uneCapitale, unPays, value;
            /* Déclaration du dictionnaire */

            var MonDictionnaire = new Dictionary<String, String>();

            /* Affichage du menu : A l'aide d'une procédure qui affiche le menu */

            AffichageMenu();


            /* Choix de l'utilisateur */

            Console.WriteLine("saisir un choix");
            unChoix = int.Parse(Console.ReadLine());

            while (unChoix != 8)
            {
                /* traitement en fonction du choix de l'utilisateur */
                /* avec une structure si.. alors..sinon ou avec selon..*/


                switch (unChoix)
                {
                    case 1:
                        Console.WriteLine("saisir une capital");
                        uneCapitale = Console.ReadLine();
                        Console.WriteLine("saisir un pays");
                        unPays = Console.ReadLine();
                        MonDictionnaire.Add(unPays, uneCapitale);
                        break;

                    case 2:
                        Console.WriteLine("----------------------------");
                        Console.WriteLine("-Pays      -Capitale");
                        Console.WriteLine("----------------------------");
                        foreach (KeyValuePair<String, String> pair in MonDictionnaire)
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("-" + pair.Key + "     " + "-" + pair.Value);
                        }

                        Console.WriteLine("----------------------------");
                        break;

                    case 3:
                        bool trouver = false;

                        while (!trouver)
                        {
                            Console.WriteLine("Saisir le pays de la capitale recherchée");
                             unPays = Console.ReadLine();

                            if (MonDictionnaire.ContainsKey(unPays))
                            {
                                Console.WriteLine("La capitale de " + unPays + " est " + MonDictionnaire[unPays]);
                                trouver = true;
                            }
                            else
                            {
                                Console.WriteLine(unPays + " non trouvé. Voulez-vous réessayer ? (Oui/Non)");
                                string response = Console.ReadLine();
                                if (response.Trim().Equals("Non", StringComparison.OrdinalIgnoreCase))
                                {
                                    break;
                                }
                            }
                        }
                        break;

                    case 4: 
                        Console.WriteLine("Quel pays voulez vous supprimer ?");
                        unPays = Console.ReadLine();

                        if (MonDictionnaire.ContainsKey(unPays))
                        {
                            MonDictionnaire.Remove(unPays);
                            Console.WriteLine("Le pays " + unPays + "a été supprimé");
                        }
                        else
                        {
                            Console.WriteLine(unPays + " non trouvé.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Quel pays souhaitez-vous mettre à jour ?");
                        unPays = Console.ReadLine();

                        if (MonDictionnaire.ContainsKey(unPays))
                        {
                            Console.WriteLine("Saisir la nouvelle capitale pour " + unPays);
                            string nouvelleCapitale = Console.ReadLine();
                            MonDictionnaire[unPays] = nouvelleCapitale; 
                            Console.WriteLine("La capitale de " + unPays + " a été mise à jour.");
                        }
                        else
                        {
                            Console.WriteLine(unPays + " non trouvé dans le dictionnaire.");
                        }
                        break;

                    case 6:
                        string PaysAssoc;
                        Console.WriteLine("Indiquer la ville à chercher");
                        string ville = Console.ReadLine();


                        if (MonDictionnaire.ContainsValue(ville))
                        {

                            foreach (KeyValuePair<string, string> pair in MonDictionnaire)
                                if (pair.Value == ville)
                                {
                                    PaysAssoc = pair.Key;
                                    Console.WriteLine(ville + " est bien une capitale" + " de " + PaysAssoc);
                                }
                        }
                        else
                        {
                            Console.WriteLine(ville + " non trouvé");
                        }
                        break;

                    case 7:

                        int reponse;
                        Console.WriteLine("Si vous voulez trier par Capitale tapez 1 et par Ville tapez 2");
                        reponse = int.Parse(Console.ReadLine());

                        if (reponse == 1)
                        {
                            var sortedDict = MonDictionnaire.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("-Pays      -Capitale");
                            Console.WriteLine("----------------------------");
                            foreach (var dict in sortedDict) {
                          
                                Console.WriteLine("\n");
                                Console.WriteLine("-" + dict.Key + "     " + "-" + dict.Value);
                             

                            }
                            
                           
                        }
                        else if (reponse == 2)
                        {
                            var sortedDict = MonDictionnaire.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                            Console.WriteLine("----------------------------");
                            Console.WriteLine("-Pays      -Capitale");
                            Console.WriteLine("----------------------------");
                            foreach (var dict in sortedDict)
                            {
                            
                                Console.WriteLine("\n");
                                Console.WriteLine("-" + dict.Key + "     " + "-" + dict.Value);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Choix invalide. Tapez 1 pour trier par Capitale ou 2 pour trier par Pays.");
                        }
                        break;
                }
                




                /* affichage du menu à l'aide de la fonction AffichageMenu()*/

                AffichageMenu();

                /* Choix de l'utilisateur */
                Console.WriteLine("Saisir un choix");
                unChoix = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Press any key to STOP");
            Console.ReadKey(true);



        }

        static void AffichageMenu()
        {
            Console.WriteLine("1--> Alimenter le dictionnaire des capitales");
            Console.WriteLine("2--> Afficher toutes les capitales");
            Console.WriteLine("3--> Chercher le pays d'une capital");
            Console.WriteLine("4--> Suprimer une entrée");
            Console.WriteLine("5--> Mettre à jour la capitale d'un pays");
            Console.WriteLine("6--> Vérifier si une ville est une Capitale");
            Console.WriteLine("7--> Trier le dictionnaire par Pays ou par Capitale");
            Console.WriteLine("8--> Quitter le programme");
        }
    }
}
