using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnController : MonoBehaviour
{
  #region Inspector Variables

  public DrainSensor DrainSensor;

  public PlungerController PlungerController;

  public int MenuWidth = 200;

  public int MenuHeight = 200;

  public int ScoreWidth = 200;

  public int ScoreHeight = 200;

  public int StartingBallCount = 3;

  public bool EnableDebugGUI = false;

  #endregion

  private List<Player> _players;

  private int _playerCount = 1;

  private int _currentPlayerIndex = -1;

  #region Events

  public event EventHandler<OnTurnStartEventArgs> OnTurnStart;

  public event EventHandler<EventArgs> OnGameStart; 

  public event EventHandler<EventArgs> OnGameOver;

  #endregion

  public List<Player> Players
  {
    get { return _players; }
  }

  public bool GameStarted
  {
    get { return _players != null; }
  }

  public Player CurrentPlayer
  {
    get { return GameStarted && _currentPlayerIndex > -1 ? _players[_currentPlayerIndex] : null; }
  }

  public void Start()
  {
    if (DrainSensor == null)
    {
      Debug.LogError("Assign the DrainSensor to the TurnController!");
    }

    if (PlungerController == null)
    {
      Debug.LogError("Assign the PlungerController to the TurnController!");
    }

    DrainSensor.OnBallDrained += DrainSensorOnOnBallDrained;
  }

  public void Destroy()
  {
    DrainSensor.OnBallDrained -= DrainSensorOnOnBallDrained;
  }

  public void NextTurn()
  {
    if (!GameStarted)
    {
      return;
    }

    // Only go to next turn if there are still players with balls left
    if (_players.Any(x => x.HasBalls))
    {
      do
      {
        _currentPlayerIndex++;
        if (_currentPlayerIndex == _players.Count)
        {
          _currentPlayerIndex = 0;
        }
      }
      while (!CurrentPlayer.HasBalls); // Skip players that are out of balls

      CurrentPlayer.UseBall();
      PlungerController.SpawnBall();

      if (OnTurnStart != null)
      {
        OnTurnStart(this, new OnTurnStartEventArgs(CurrentPlayer));
      }
    }
    else
    {
      EndGame();
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
        StartGame();
      }

      GUILayout.EndArea();
    }
    else
    {
      GUILayout.BeginArea(new Rect(10, 10, ScoreWidth, ScoreHeight));

      GUILayout.Label("Score");

      foreach (var player in _players)
      {
        GUILayout.Label(
          string.Format(
            "{0}Player {1} - Points: {2} Balls: {3} Extra Balls: {4}",
            CurrentPlayer == player ? "=> " : "",
            player.Number,
            player.Score,
            player.Balls,
            player.ExtraBalls));
      }

      if (EnableDebugGUI)
      {
        if (GUILayout.Button("Skip Turn"))
        {
          NextTurn();
        }

        if (GUILayout.Button("Use Current Player's Ball"))
        {
          CurrentPlayer.UseBall();
        }
      }

      GUILayout.EndArea();
    }
  }

  private void StartGame()
  {
    Debug.Log("Game Started");

    _players = Enumerable.Range(1, _playerCount).Select(x => new Player(x, StartingBallCount)).ToList();

    if (OnGameStart != null)
    {
      OnGameStart(this, new EventArgs());
    }

    NextTurn();
  }

  private void EndGame()
  {
    if (!GameStarted)
    {
      return;
    }

    Debug.Log("Game Over");

    _currentPlayerIndex = -1;

    if (OnGameOver != null)
    {
      OnGameOver(this, new EventArgs());
    }
  }

  private void DrainSensorOnOnBallDrained(object sender, EventArgs eventArgs)
  {
    if (CurrentPlayer.HasExtraBalls)
    {
      CurrentPlayer.UseExtraBall();
      PlungerController.SpawnBall();
    }
    else
    {
      NextTurn();
    }
  }
}