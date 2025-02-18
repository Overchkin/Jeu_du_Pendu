using System; // Inclut l'espace de noms System, qui contient des fonctionnalités de base comme la manipulation de chaînes, l'entrée/sortie (Console), etc.
using System.Collections.Generic; // Inclut des collections génériques telles que List, utilisées pour stocker des données dynamiques.
using System.Linq; // Fournit des outils pour la manipulation de collections, comme LINQ (Language Integrated Query), permettant des opérations comme le filtrage, l'agrégation, etc.
using System.Text; // Contient des classes pour gérer les chaînes de caractères.
using System.Threading.Tasks; // Permet de travailler avec des tâches asynchrones et le parallélisme.

namespace Jeu_du_Pendu // Déclaration du namespace (espace de noms), qui permet de regrouper logiquement les classes.
{
    public class Pendu // Déclaration de la classe Pendu, représentant la logique du jeu du pendu.
    {
        // Liste des mots disponibles dans le jeu.
        private List<string> mots = new List<string>
        {
            "chien", "cheval", "maison", "ordinateur", "famille", "piano", "clavier", "honneur"
        };

        private const int NbEssaiMax = 7; // Constante représentant le nombre d'essais maximum avant de perdre.
        private int NbEssai = 0; // Compteur des essais faits par le joueur.

        // Propriétés publiques de la classe.
        public List<char> LettresTestees { get; } = new List<char>(); // Liste des lettres déjà testées.
        public string MotATrouver { get; private set; } // Le mot à trouver dans le jeu.
        public string MotCourant { get; private set; } // Le mot en cours de jeu, avec des tirets représentant les lettres non trouvées.

        public Pendu() // Constructeur de la classe, utilisé pour initialiser le jeu.
        {
            var Aleatoire = new Random(); // Création d'un objet Random pour générer un nombre aléatoire.
            var Indexation = Aleatoire.Next(8); // Sélection d'un mot aléatoire parmi les 8 mots disponibles.

            MotATrouver = mots[Indexation]; // Affecte le mot choisi à la propriété MotATrouver.
            MotCourant = string.Concat(Enumerable.Repeat("-", MotATrouver.Length)); // Crée un mot courant avec des tirets, ayant la même longueur que le mot à trouver.
        }

        public bool GagnerOuPerdu() // Méthode pour vérifier si le joueur a gagné ou perdu.
        {
            return MotCourant == MotATrouver || NbEssai >= NbEssaiMax; // Si le mot courant est égal au mot à trouver ou si le nombre d'essais atteint le maximum, la partie est terminée.
        }

        public void TesterLettre(char c) // Méthode qui teste si une lettre donnée est présente dans le mot à trouver.
        {
            if (LettresTestees.Contains(c)) // Si la lettre a déjà été testée, on ne la teste pas à nouveau.
            {
                return;
            }

            var Copie = MotCourant.ToArray(); // Copie du mot courant sous forme de tableau de caractères.
            bool Trouve = false; // Variable pour indiquer si la lettre a été trouvée.

            // Parcours du mot à trouver pour vérifier si la lettre existe.
            for (int i = 0; i < MotATrouver.Length; i++)
            {
                var Caractere = MotATrouver[i]; // Récupère le caractère du mot à trouver à la position i.
                if (Caractere == c) // Si le caractère correspond à la lettre testée, on le remplace dans la copie du mot courant.
                {
                    Copie[i] = c;
                    Trouve = true;
                }
            }

            if (Trouve) // Si la lettre a été trouvée, on met à jour le mot courant.
            {
                MotCourant = new string(Copie);
            }
            else // Si la lettre n'est pas trouvée, on incrémente le nombre d'essais.
            {
                NbEssai++;
            }

            MotCourant = new string(Copie); // Mise à jour finale du mot courant après avoir testé la lettre.
        }

        public void AfficherPendu() // Méthode qui affiche l'état actuel du pendu.
        {
            // Modèle de l'affichage du pendu avec des éléments variables pour afficher l'état du jeu.
            var template = "  --------------     " + Environment.NewLine +
                             "    |        1       " + Environment.NewLine +
                             "    |        1       " + Environment.NewLine +
                             "    |       2 2'      " + Environment.NewLine +
                             "    |       2'2¤2      " + Environment.NewLine +
                             "    |      44355     " + Environment.NewLine +
                             "    |        3       " + Environment.NewLine +
                             "    |        3       " + Environment.NewLine +
                             "    |       6 7      " + Environment.NewLine +
                            @"   /|\     6   7     " + Environment.NewLine +
                            @"  / | \              " + Environment.NewLine +
                            @" /  |  \             ";

            // Parcours des essais pour déterminer l'état visuel du pendu.
            for (int i = 1; i <= NbEssaiMax; i++)
            {
                if (NbEssai >= i) // Si le nombre d'essais est supérieur ou égal à i, on remplace les caractères du modèle.
                {
                    if (i != 2)
                    {
                        template = template.Replace(i.ToString(), i switch
                        {
                            1 => "|",
                            3 => "|",
                            4 => "-",
                            5 => "-",
                            6 => "/",
                            7 => "\\",
                            _ => ""
                        });
                    }
                    else
                    {
                        template = template
                            .Replace("2'", "\\")
                            .Replace("2¤", "_")
                            .Replace("2", "/");
                    }
                }
                else // Si l'essai est inférieur au nombre actuel, on remplace certains caractères par des espaces ou rien.
                {
                    template = template.Replace(i.ToString(), i switch
                    {
                        4 => " ",
                        _ => ""
                    })
                    .Replace("'", "").Replace("¤", "");
                }
            }

            // Affichage du modèle du pendu après remplacement des caractères en fonction des essais.
            Console.Write(template);
            Console.WriteLine(); // Saut de ligne après l'affichage.
        }
    }
}
