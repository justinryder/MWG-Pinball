public class Player
{
  public Player(int number, int balls)
  {
    Balls = balls;
    Number = number;
  }

  public int Balls { get; private set; }

  public int Number { get; private set; }

  public int Score { get; private set; }

  public void AddScore(int points)
  {
    Score += points;
  }

  public void AddExtraBall()
  {
    Balls++;
  }
}