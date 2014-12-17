public class Player
{
  public Player(int number)
  {
    Number = number;
  }

  public int Number { get; private set; }

  public int Score { get; private set; }

  public void AddScore(int points)
  {
    Score += points;
  }
}