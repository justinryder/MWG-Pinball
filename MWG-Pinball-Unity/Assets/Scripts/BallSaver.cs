using UnityEngine;

public class BallSaver : MonoBehaviour
{
  private bool holdBall = true;

  private GameObject ball;

  public TurnController TurnController;

  private float holdTimer = 1.5f;

  private void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign TurnController to BallSaver!");
    }
  }

  private void OnTriggerEnter(Collider collision)
  {
    if (collision.gameObject.tag == "Ball")
    {
      collision.rigidbody.velocity = new Vector3(0, 0, 0);
      collision.rigidbody.position = this.transform.position;
      holdBall = true;
      ball = collision.gameObject;
      TurnController.CurrentPlayer.AddScore(5000);
    }
  }

  private void OnTriggerStay(Collider collision)
  {
    if (collision.gameObject.tag == "Ball")
    {
      if (holdBall)
      {
        collision.rigidbody.velocity = new Vector3(0, 0, 0);
        collision.gameObject.transform.position = this.transform.position;
      }
    }
  }

  private void Update()
  {
    if (holdBall && ball != null)
    {
      holdTimer -= Time.deltaTime;
      if (holdTimer <= 0)
      {
        holdBall = false;
        ball.rigidbody.AddForce(new Vector3(-0.5f, 0, -0.5f));
        ball = null;
      }
    }
  }
}