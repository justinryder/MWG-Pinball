using UnityEngine;

public class PlungerController : MonoBehaviour
{
  public float Force = 5;
  public float BallForceMultiplier = 200;
  public float SpringForce = 0.04f;
  public GameObject PinballPreFab;

  private Vector3 Maxsize;
  private Vector3 Minsize;
  private GameObject ball;

  // Use this for initialization
  private void Start()
  {
      Maxsize = transform.localScale;
      Minsize = transform.localScale / 3;
  }

  // Update is called once per frame
  private void Update()
  {
      Vector3 input = new Vector3(0, Input.GetAxis("Vertical"), 0);
      Scale(input * Time.deltaTime * Force);
      Spring();
      FlingBall();
  }

  public void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Ball")
    {
      Debug.Log("You suck, the plunger caught the ball.");
      ball = collision.gameObject;
    }
  }

  private void FlingBall()
  {
      var delta = Maxsize.y - transform.localScale.y;

      if (Input.GetKeyUp("down") && ball != null)
      {
        ball.rigidbody.AddForce(transform.up * BallForceMultiplier * delta);
        ball = null;
      }
  }

  private void Spring()
  {
      if (!Input.GetButton("Vertical"))
      {
          var amount = new Vector3(0, SpringForce, 0);
          transform.localScale += amount;
      }
  }

  private void Scale(Vector3 amount)
  {
      //Make sure that we can never get bigger than we can
      transform.localScale += amount * Time.deltaTime * Force;
      var NewSize = transform.localScale;   
      if (NewSize.y < Minsize.y)
      {
          transform.localScale = new Vector3(transform.localScale.x, Minsize.y, transform.localScale.z);
      }
      if (NewSize.y > Maxsize.y)
      {
          transform.localScale = new Vector3(transform.localScale.x, Maxsize.y, transform.localScale.z);
      }
  }

  public void SpawnBall()
  {
    ball = (GameObject)Instantiate(PinballPreFab, transform.position + (transform.up * .4f), Quaternion.identity);
  }
}