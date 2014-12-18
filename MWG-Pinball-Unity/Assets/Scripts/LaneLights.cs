using System;
using System.Collections.Generic;
using UnityEngine;

public class LaneLights : MonoBehaviour
{
  public TurnController TurnController;

  public Renderer OnRenderer;

  public Renderer OffRenderer;

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
      Debug.LogError("Assign TurnController to LaneLights!");
    }

    if (OnRenderer == null)
    {
      Debug.LogError("Assign OnRenderer to LaneLights!");
    }

    if (OffRenderer == null)
    {
      Debug.LogError("Assign OffRenderer to LaneLights!");
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
    OffRenderer.gameObject.active = !IsLit;
    OnRenderer.gameObject.active = IsLit;
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