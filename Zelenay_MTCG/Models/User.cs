using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterCardGame.Models.Cards;
namespace MonsterCardGame.Models.User
{
    public class User
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int UserCoins { get; set; }
        public List<Card> CardStack { get; private set; } //alle karten des users
        public List<Card> BattleDeck { get; private set; }    //4 karten die zum kämpfen benutzt werden
        public int RankingPoints { get; set; }
        public int TotalWins { get; set; }
        public int TotalLosses { get; set; }
        public string AuthenticationToken { get; set; }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            UserCoins = 20;
            CardStack = new List<Card>();
            BattleDeck = new List<Card>();
            ELO = 100;
            TotalLosses = 0;
            TotalWins = 0;

        }
    }
}
