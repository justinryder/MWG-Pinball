using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnController : MonoBehaviour
{
  #region Inspector Variables

  public int MenuWidth = 200;

  public int MenuHeight = 200;

  public int ScoreWidth = 200;

  public int ScoreHeight = 200;

  #endregion

  public event EventHandler<OnTurnStartEventArgs> OnTurnStart;

  private List<Player> _players;

  private int _playerCount = 1;

  private int _currentPlayerIndex = 0;

  public bool GameStarted
  {
    get { return _players != null; }
  }

  public Player CurrentPlayer
  {
    get { return GameStarted ? _players[_currentPlayerIndex] : null; }
  }

  public void NextTurn()
  {
    _currentPlayerIndex++;
    if (_currentPlayerIndex == _players.Count)
    {
      _currentPlayerIndex = 0;
    }

    if (OnTurnStart != null)
    {
      OnTurnStart(this, new OnTurnStartEventArgs(CurrentPlayer));
    }
  }

  public void OnGUI()
  {
    if (!GameStarted)
    {
      GUILayout.BeginArea(new Rect((Screen.width - MenuWidth) / 2, (Screen.height - MenuHeight) / 2, MenuWidth, MenuHeight));

      GUILayout.Label("Player count: " + _playerCount);

      _playerCount = (int)GUILayout.HorizontalSlider((int)_playerCount, 1, 4, GUI.skin.horizontalSlider, GUI.skin.horizontalSliderThumb);

      if (GUILayout.Button("Play"))
      {
        _players = Enumerable.Range(1, _playerCount).Select(x => new Player(x)).ToList();
      }

      GUILayout.EndArea();
    }
    else
    {
      GUILayout.BeginArea(new Rect(10, 10, ScoreWidth, ScoreHeight));

      GUILayout.Label("Score");

      foreach (var player in _players)
      {
        GUILayout.Label(string.Format("Player {0}: {1}{2}", player.Number, player.Score, CurrentPlayer == player ? " It's your turn!" : ""));
      }

      GUILayout.EndArea();
    }
  }
}