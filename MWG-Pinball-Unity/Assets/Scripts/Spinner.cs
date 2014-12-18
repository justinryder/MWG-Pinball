using UnityEngine;

public class Spinner : MonoBehaviour
{
  public TurnController turnController;

  public int spinPoints = 5;

  private float pointTimer = 0.5f;

  private Vector3 lastRotation;

  private void Update()
  {
    pointTimer -= Time.deltaTime;

    if (this.transform.rotation.eulerAngles != lastRotation && pointTimer <= 0)
    {
      turnController.CurrentPlayer.AddScore(spinPoints);
      pointTimer = 0.5f;
    }

    lastRotation = this.transform.rotation.eulerAngles;
  }
}