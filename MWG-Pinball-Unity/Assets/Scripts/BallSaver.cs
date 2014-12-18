using UnityEngine;
using System.Collections;

public class BallSaver : MonoBehaviour
{

  private bool holdBall = false;

  private GameObject ball;

  public TurnController TurnController;

  private float holdTimer = 1.5f;

  // Use this for initialization
  private void Start()
  {

  }

  private void OnCollisionEnter(Collision collision)
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

  private void OnCollisionStay(Collision collision)
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

  // Update is called once per frame
  private void Update()
  {
    if (holdBall)
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