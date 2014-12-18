using UnityEngine;
using System.Collections;

public class BallSaver : MonoBehaviour
{

  private bool holdBall = false;

  private GameObject ball;

  public TurnController TurnController;

  private float holdTimer = 1.5f;
	// Use this for initialization
	void Start () {
	
	}

  void OnCollisionEnter(Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      if (contact.otherCollider.tag == "Ball")
      {
        contact.otherCollider.rigidbody.velocity = new Vector3(0, 0, 0);
        contact.otherCollider.rigidbody.position = this.transform.position;
        holdBall = true;
        ball = contact.otherCollider.gameObject;
        TurnController.CurrentPlayer.AddScore(5000);
        
      }
    }
  }

  void OnCollisionStay(Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      if (contact.otherCollider.tag == "Ball")
      {
        if (holdBall)
        {
          contact.otherCollider.rigidbody.velocity = new Vector3(0, 0, 0);
          contact.otherCollider.gameObject.transform.position = this.transform.position;
        }
      }
    }
  }
	
	// Update is called once per frame
	void Update () {

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
