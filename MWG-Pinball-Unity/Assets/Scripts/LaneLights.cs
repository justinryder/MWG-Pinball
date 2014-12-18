using System;
using System.Collections.Generic;
using UnityEngine;

public class LaneLights : MonoBehaviour
{
  public TurnController TurnController;

  private Dictionary<Player, bool> isLit = new Dictionary<Player, bool>();

  private int points = 1000;

  public bool IsLit
  {
    get { return TurnController.CurrentPlayer != null && isLit[TurnController.CurrentPlayer]; }
  }

  public void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign TurnController to LaneLights");
    }

    TurnController.OnGameStart += TurnControllerOnOnGameStart;
  }

  public void Destroy()
  {
    TurnController.OnGameStart -= TurnControllerOnOnGameStart;
  }

  public void Reset()
  {
    isLit[TurnController.CurrentPlayer] = false;
  }

  public void Update()
  {
    if (TurnController.CurrentPlayer != null)
    {
      renderer.material.color = IsLit ? Color.green : Color.white;
      //renderer.material = renderer.materials[IsLit ? 0 : 1];
    }
  }

  private void TurnControllerOnOnGameStart(object sender, EventArgs eventArgs)
  {
    foreach (var player in TurnController.Players)
    {
      isLit.Add(player, false);
    }
  }

  private void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == "Ball")
    {
      if (!isLit[TurnController.CurrentPlayer])
      {
        isLit[TurnController.CurrentPlayer] = true;
        TurnController.CurrentPlayer.AddScore(points);
      }
    }
  }
}