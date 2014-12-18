using UnityEngine;

public class LineLightsManager : MonoBehaviour
{

  public LaneLights LaneLightM;
  public LaneLights LaneLightW;
  public LaneLights LaneLightG;

  public int Bonus = 10000;

  public TurnController TurnController;

  public void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign TurnController to LineLightsManager");
    }
  }

  public void Update()
  {
    if (LaneLightM.IsLit && LaneLightW.IsLit && LaneLightG.IsLit)
    {
      TurnController.CurrentPlayer.AddScore(Bonus);

      LaneLightM.Reset();
      LaneLightW.Reset();
      LaneLightG.Reset();
    }
  }
}