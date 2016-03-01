using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tennis
{
    public interface IPlayer
    {
        //Player Name
        string Name { get; set; }

        //ScoredPoints of the Player
        Points ScoredPoints { get; set; }      

        //To AddPoints to the players 
        void AddPoint();

        //to Remove Advantage 
        void RemoveAdvantage();
    }
}
