using System;

public class OnTurnStartEventArgs : EventArgs
{
  public OnTurnStartEventArgs(Player player)
  {
    Player = player;
  }

  public Player Player { get; private set; }
}