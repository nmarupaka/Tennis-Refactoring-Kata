using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tennis
{
    //Loading player methods and properties from Interface
    public class Player : IPlayer
    {
        public Player(string name)
        {
            this.Name = name;
        }
        //Player Name
        public string Name { get; set; }

        //ScoredPoints of the Player
        public Points ScoredPoints { get; set; }

        //
        public bool IsDeuce { get; set; }

        //To AddPoints to the players 
        public void AddPoint()
        {
            ScoredPoints = (Points)((int)ScoredPoints + 1);
        }

        //to Remove Advantage 
        public void RemoveAdvantage()
        {
            ScoredPoints = (Points.Forty);
        }
    }
}

