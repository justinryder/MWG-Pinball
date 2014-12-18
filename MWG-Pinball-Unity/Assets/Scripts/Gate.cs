using UnityEngine;

public class Gate : MonoBehaviour
{
  public TurnController TurnController;

  public string BallTag = "Ball";

  public void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign TurnController to Gate!");
    }

    TurnController.OnTurnStart += TurnControllerOnOnTurnStart;
  }

  public void Destroy()
  {
    TurnController.OnTurnStart -= TurnControllerOnOnTurnStart;
  }

  public void OnTriggerExit()
  {
    collider.isTrigger = false;
  }

  private void TurnControllerOnOnTurnStart(object sender, OnTurnStartEventArgs onTurnStartEventArgs)
  {
    collider.isTrigger = true;
  }
}