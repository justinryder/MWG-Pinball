using UnityEngine;
using System.Collections;

public class DropTargets : MonoBehaviour {

  public bool Status = false;

  public int Points = 500;

  public TurnController TurnController;

  void OnCollisionEnter(Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      if (contact.otherCollider.tag == "Ball")
      {
        Status = true;
        TurnController.CurrentPlayer.AddScore(Points);
        this.transform.position = new Vector3(transform.position.x, transform.position.y - 100, transform.position.z);
      }
    }
  }

  void Update()
  {
  }
}
