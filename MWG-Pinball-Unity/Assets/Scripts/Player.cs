public class Player
{
  public Player(int number, int balls)
  {
    Balls = balls;
    Number = number;
  }

  public int Balls { get; private set; }

  public int ExtraBalls { get; private set; }

  public bool HasBalls
  {
    get { return Balls > 0; }
  }

  public bool HasExtraBalls
  {
    get { return ExtraBalls > 0; }
  }

  public int Number { get; private set; }

  public int Score { get; private set; }

  public void AddScore(int points)
  {
    Score += points;
  }

  public void AddExtraBall()
  {
    ExtraBalls++;
  }

  public void UseBall()
  {
    Balls--;
  }

  public void UseExtraBall()
  {
    ExtraBalls--;
  }
}