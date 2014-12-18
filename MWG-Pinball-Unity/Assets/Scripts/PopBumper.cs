using UnityEngine;

public class PopBumper : MonoBehaviour
{
  public TurnController TurnController;

  public float Force = 100;

  public string BallTag = "Ball";

  public void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign the TurnController to the PopBumper!");
    }
  }

  public void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == BallTag)
    {
      var directionToBall = (collision.gameObject.transform.position - transform.position).normalized;
      collision.gameObject.rigidbody.AddForce(directionToBall * Force);

      if (TurnController.CurrentPlayer != null)
      {
        TurnController.CurrentPlayer.AddScore(100);
      }
    }
  }
}