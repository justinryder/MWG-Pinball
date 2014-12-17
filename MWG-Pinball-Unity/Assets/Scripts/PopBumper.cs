using UnityEngine;
using System.Collections;

public class PopBumper : MonoBehaviour
{
  public float Force = 100;

  public string BallTag = "Ball";

  public void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == BallTag)
    {
      var directionToBall = (collision.gameObject.transform.position - transform.position).normalized;
      collision.gameObject.rigidbody.AddForce(directionToBall * Force);
    }
  }
}