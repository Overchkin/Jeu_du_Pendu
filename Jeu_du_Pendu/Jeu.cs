using System; // Inclut l'espace de noms System pour les fonctionnalités de base comme Console, gestion des chaînes, etc.
using System.Collections.Generic; // Inclut les collections génériques (comme List) utilisées pour stocker des éléments dynamiquement.
using System.Linq; // Permet de travailler avec LINQ pour manipuler les collections.
using System.Runtime.CompilerServices; // Inclut des fonctionnalités pour l'accès à des membres spécifiques à l'exécution.
using System.Text; // Contient des classes pour la manipulation de chaînes de caractères.
using System.Threading.Tasks; // Permet la gestion de tâches asynchrones et de parallélisme.

namespace Jeu_du_Pendu // Déclaration du namespace pour organiser le code.
{
    public class Jeu // Classe Jeu qui contient la logique pour exécuter le jeu du pendu.
    {
        private Pendu pendu = new Pendu(); // Instance de la classe Pendu pour gérer la partie de pendu.

        public void LancerJeu() // Méthode pour lancer le jeu du pendu.
        {
            Console.Clear(); // Efface la console avant de commencer le jeu.

            // Tant que le joueur n'a pas gagné ou perdu (méthode GagnerOuPerdu renvoie false), la boucle continue.
            while (pendu.GagnerOuPerdu() == false)
            {
                // Affiche les lettres testées jusque-là sous forme de liste.
                Console.WriteLine($"Lettres testées : {string.Join(" ", pendu.LettresTestees)}");
                pendu.AfficherPendu(); // Affiche l'état visuel du pendu.
                Console.WriteLine($"Mot actuel: {pendu.MotCourant}"); // Affiche le mot en cours avec des tirets ou lettres trouvées.

                // Demande à l'utilisateur d'entrer une lettre.
                Console.Write("Entrer une lettre: ");
                char Saisie = RecupererSaisieUtilisateur(); // Récupère la saisie de l'utilisateur (méthode définie plus bas).

                pendu.TesterLettre(Saisie); // Teste la lettre saisie par l'utilisateur dans le mot.
                Console.Clear(); // Efface la console pour une nouvelle itération.
            }

            // Une fois la partie terminée (gagnée ou perdue), on gère la fin du jeu.
            GestionFinDeJeu();
        }

        private void GestionFinDeJeu() // Méthode pour gérer la fin du jeu (victoire ou défaite).
        {
            Console.Clear(); // Efface la console pour afficher la conclusion du jeu.

            // Si le mot actuel est identique au mot à trouver, le joueur a gagné.
            if (pendu.MotCourant == pendu.MotATrouver)
            {
                Console.WriteLine("Bravo, vous avez gagné !");
            }
            else // Si le joueur n'a pas deviné le mot, il a perdu.
            {
                Console.WriteLine("Dommage, vous avez perdu !");
            }

            pendu.AfficherPendu(); // Affiche l'état final du pendu (pour voir le dessin complet).
            Console.WriteLine($"Le mot à trouver était: {pendu.MotATrouver}"); // Affiche le mot à trouver.
        }

        private char RecupererSaisieUtilisateur() // Méthode pour récupérer et valider la saisie d'une lettre par l'utilisateur.
        {
            char? Saisie = null; // Variable nullable pour stocker la saisie de l'utilisateur.

            // Tant que la saisie n'est pas valide, la boucle continue.
            while (Saisie.HasValue == false)
            {
                try
                {
                    // Récupère la saisie de l'utilisateur depuis la console.
                    var consoleSaisie = Console.ReadLine();

                    // Si la saisie n'est pas vide, on essaie de la convertir en caractère.
                    if (string.IsNullOrEmpty(consoleSaisie) == false)
                    {
                        Saisie = char.Parse(consoleSaisie); // Parse la saisie en un caractère.
                    }
                    else
                    {
                        Saisie = null; // Si la saisie est vide, on garde Saisie à null.
                    }
                }
                catch
                {
                    Saisie = null; // Si une erreur survient (par exemple une saisie invalide), on garde Saisie à null.
                }
            }

            return Saisie.Value; // Renvoie la valeur du caractère validé.
        }
    }
}
