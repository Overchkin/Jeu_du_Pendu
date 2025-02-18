using System; // Importation de l'espace de noms System, qui contient des classes fondamentales comme Console pour l'interaction avec l'utilisateur.
using System.Collections.Generic; // Pour l'utilisation de collections génériques comme List, etc.
using System.Linq; // Pour utiliser les méthodes LINQ pour travailler avec des collections.
using System.Text; // Pour gérer des opérations sur les chaînes de caractères.
using System.Threading.Tasks; // Permet d'utiliser des tâches asynchrones et des opérations asynchrones.

namespace Jeu_du_Pendu // Déclaration de l'espace de noms (namespace) pour organiser les classes et éviter les conflits de noms.
{
    internal class Program // Classe principale de l'application. "internal" signifie qu'elle est accessible dans le même assemblage (généralement dans le même projet).
    {
        static void Main(string[] args) // Point d'entrée de l'application. La méthode Main est l'endroit où l'exécution commence.
        {
            var Jeux = new Jeu(); // Création d'une instance de la classe "Jeu". Cela permet d'accéder aux fonctionnalités de jeu.
            Jeux.LancerJeu(); // Appel de la méthode "LancerJeu" pour démarrer le jeu du pendu.
        }
    }
}
