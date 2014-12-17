using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour
{
  public float Force = 100;

  public string BallTag = "Ball";

  private Vector3 ForceDirection
  {
    get { return transform.forward; }
  }

  public void OnTriggerEnter(Collider collider)
  {
    if (collider.gameObject.tag == BallTag)
    {
      collider.gameObject.rigidbody.AddForce(ForceDirection * Force);
    }
  }

  public void OnDrawGizmos()
  {
    Gizmos.DrawLine(transform.position, transform.position + (ForceDirection * .2f));
  }
}