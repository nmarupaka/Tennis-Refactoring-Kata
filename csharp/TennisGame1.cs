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

      /// <summary>
      /// WonPoint
      /// </summary>
      /// <param name="playerName"></param>
      public void WonPoint(string playerName)
      {
          //checks which player it is and addpoint
          if (_player1.Name == playerName)
          {
              _player1.AddPoint();
          }
          else if (_player2.Name == playerName)
          {
              _player2.AddPoint();
          }

          //check if player1 and player2 score points are same and if the scorepoints is 
          //advantage then remove one point less from both players as both cannot be Advantage
          if (_player1.ScoredPoints == _player2.ScoredPoints && (int)_player1.ScoredPoints == (int)Points.Advantage)
          {
              _player1.RemoveAdvantage();
              _player2.RemoveAdvantage();
          }
          else if (_player1.ScoredPoints == Points.Advantage && (int)_player2.ScoredPoints < (int)Points.Forty)
          {
              // game is won by player1 to have won at least four points in total and at least two points more than the player2
              _player1.AddPoint();
          }
          else if (_player2.ScoredPoints == Points.Advantage && (int)_player1.ScoredPoints < (int)Points.Forty)
          {
              // game is won by player2 to have won at least four points in total and at least two points more than the player1
              _player2.AddPoint();
          }
      }

      /// <summary>
      /// GetScore
      /// </summary>
      /// <returns></returns>
      public string GetScore()
      {
          string score;
          if (_player1.ScoredPoints == _player2.ScoredPoints && _player1.ScoredPoints != Points.Forty && _player1.ScoredPoints != Points.Advantage && _player1.ScoredPoints != Points.Win)
          {
              //to display scores if both are equal and 
              score = string.Format("{0}-All", _player1.ScoredPoints.ToString());
          }
          else if (_player1.ScoredPoints == _player2.ScoredPoints && _player1.ScoredPoints == Points.Forty)
          {
              //at least three points have been scored by each player, and the scores are equal, the score is "Deuce".
              score = "Deuce";
          }
          else if (_player1.ScoredPoints == Points.Advantage || _player2.ScoredPoints == Points.Advantage)
          {
              //three points have been scored by each side and a player has one more point than his opponent, the score of the game is "Advantage"
              score = string.Format("Advantage {0}", (_player1.ScoredPoints == Points.Advantage) ? _player1.Name : _player2.Name);
          }
          else if (_player1.ScoredPoints == Points.Win || _player2.ScoredPoints == Points.Win)
          {
              // the score of the game is "Win"
              score = string.Format("Win for {0}", (_player1.ScoredPoints == Points.Win) ? _player1.Name : _player2.Name);
          }
          else
          {
              //score of each game
              score = string.Format("{0}-{1}", _player1.ScoredPoints, _player2.ScoredPoints);
          }
          return score;
      }
  }

}

