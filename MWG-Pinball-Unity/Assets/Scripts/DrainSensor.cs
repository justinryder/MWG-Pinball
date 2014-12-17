using System;
using UnityEngine;

public class DrainSensor : MonoBehaviour
{
  public string BallTag = "Ball";

  public event EventHandler<EventArgs> OnBallDrained;

  public void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == BallTag)
    {
      Destroy(collider.gameObject);

      if (OnBallDrained != null)
      {
        OnBallDrained(this, new EventArgs());
      }
    }
  }
}