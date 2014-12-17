using System.Collections.Generic;
using UnityEngine;

public class LineLightsManager : MonoBehaviour
{

  public LaneLights LaneLightM;
  public LaneLights LaneLightW;
  public LaneLights LaneLightG;

  public int Bonus = 8000;

  public TurnController turnController;

  public Dictionary<Player, List<LaneLights>> LanePlayerMatchUp = new Dictionary<Player, List<LaneLights>>();


  // Use this for initialization
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    var lights = new List<LaneLights>() { LaneLightM, LaneLightW, LaneLightG };

    if (turnController.CurrentPlayer != null)
    {
      if (!LanePlayerMatchUp.ContainsKey(turnController.CurrentPlayer))
      {
        LanePlayerMatchUp.Add(turnController.CurrentPlayer, lights);
      }
      else
      {
        LanePlayerMatchUp[turnController.CurrentPlayer] = lights;
      }
    }

    if (LaneLightM.status && LaneLightW.status && LaneLightG.status)
    {
      //send bonus 
      var currentPlayer = turnController.CurrentPlayer;
      if (currentPlayer != null)
      {
        currentPlayer.AddScore(Bonus);
      }
      LaneLightM.status = false;
      LaneLightW.status = false;
      LaneLightG.status = false;
    }
  }
}
