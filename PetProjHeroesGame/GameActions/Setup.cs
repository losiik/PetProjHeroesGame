using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetProjHeroesGame
{
    internal class Setup
    {
        public int GamersAmount { get; set; }

        public static List<Gamer> gamersList = new List<Gamer>();

        public void AddGamers(Gamer gamer) 
        {
            gamersList.Add(gamer);
        }

        public int GetGamersAmount() 
        {
            return gamersList.Count;
        }

        public Gamer GetGamerById(int id) 
        {
            return gamersList[id];
        }

        public void KillTheGamer(int damagedGamerId) 
        {
            gamersList.RemoveAt(damagedGamerId);
        }
    }
}
