using System;
using NUnit.Framework;

namespace Tennis
{
  public class TennisGame1 : TennisGame
  {
      IPlayer _player1;
      IPlayer _player2;

      public TennisGame1(IPlayer player1, IPlayer player2)
      {
          this._player1 = player1;
          this._player2 = player2;
      }

      //
      public void WonPoint(string playerName)
      {
          //checks which player it is
          if (_player1.Name == playerName)
          {
              _player1.AddPoint();
          }
          else if (_player2.Name == playerName)
          {
              _player2.AddPoint();
          }

          //check if player1 and players score points are same and if the scorepoints is 
          //advantage then remove one point less from both palyers
          if (_player1.ScoredPoints == _player2.ScoredPoints && (int)_player1.ScoredPoints == (int)Points.Advantage)
          {
              _player1.RemoveAdvantage();
              _player2.RemoveAdvantage();
          }
          else if (_player1.ScoredPoints == Points.Advantage && (int)_player2.ScoredPoints < (int)Points.Forty)
          {
              //if player1 scorepoint 
              _player1.AddPoint();
          }
          else if (_player2.ScoredPoints == Points.Advantage && (int)_player1.ScoredPoints < (int)Points.Forty)
          {
              _player2.AddPoint();
          }
      }

      public string GetScore()
      {
          string score;
          if (_player1.ScoredPoints == _player2.ScoredPoints && _player1.ScoredPoints != Points.Forty)
          {
              score = string.Format("{0}-All", _player1.ScoredPoints.ToString());
          }
          else if (_player1.ScoredPoints == _player2.ScoredPoints)
          {
              score = "Deuce";
          }
          else if (_player1.ScoredPoints == Points.Advantage || _player2.ScoredPoints == Points.Advantage)
          {
              score = string.Format("Advantage for {0}", _player1.Name);
          }
          else
          {
              score = string.Format("{0}-{1}", _player1.ScoredPoints, _player2.ScoredPoints);
          }
          return score;
      }
  }

}

