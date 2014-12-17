using System.Collections.Generic;

using UnityEngine;
using System.Collections;

public class DropTargetManager : MonoBehaviour {

  public DropTargets DropTargetM;
  public DropTargets DropTargetW;
  public DropTargets DropTargetG;

  public int Bonus = 8000;

  public TurnController turnController;

  public Dictionary<Player, List<DropTargets>> DropTargetsMatchUp = new Dictionary<Player, List<DropTargets>>(); 

	// Use this for initialization
	void Start () {
	
	}

  private void Update()
  {
    // Update is called once per frame
    var dropTargets = new List<DropTargets>() { DropTargetM, DropTargetW, DropTargetG };

    if (turnController.CurrentPlayer != null)
    {
      if (!DropTargetsMatchUp.ContainsKey(turnController.CurrentPlayer))
      {
        DropTargetsMatchUp.Add(turnController.CurrentPlayer, dropTargets);
      }
      else
      {
        DropTargetsMatchUp[turnController.CurrentPlayer] = dropTargets;
      }
    }

    if (DropTargetM.Status && DropTargetW.Status && DropTargetG.Status)
    {
      //send bonus 
      var currentPlayer = turnController.CurrentPlayer;
      if (currentPlayer != null)
      {
        currentPlayer.AddScore(Bonus);
      }

      DropTargetM.transform.position = new Vector3(DropTargetM.transform.position.x, DropTargetM.transform.position.y + 100, DropTargetM.transform.position.z);
      DropTargetW.transform.position = new Vector3(DropTargetM.transform.position.x, DropTargetM.transform.position.y + 100, DropTargetM.transform.position.z);
      DropTargetG.transform.position = new Vector3(DropTargetM.transform.position.x, DropTargetM.transform.position.y + 100, DropTargetM.transform.position.z);
      DropTargetM.Status = false;
      DropTargetW.Status = false;
      DropTargetG.Status = false;
    }
  }
}
