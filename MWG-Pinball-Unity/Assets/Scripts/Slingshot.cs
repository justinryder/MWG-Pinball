using UnityEngine;

public class Slingshot : MonoBehaviour
{
  public float Force = 100;

  public string BallTag = "Ball";

  public TurnController TurnController;

  private Vector3 ForceDirection
  {
    get { return transform.forward; }
  }

  public void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign TurnController to Slingshot!");
    }
  }

  public void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == BallTag)
    {
      collider.gameObject.rigidbody.AddForce(ForceDirection * Force);
      TurnController.CurrentPlayer.AddScore(10);
    }
  }

  public void OnDrawGizmos()
  {
    Gizmos.DrawLine(transform.position, transform.position + (ForceDirection * .2f));
  }
}