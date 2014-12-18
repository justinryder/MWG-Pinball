using UnityEngine;

public class PopBumper : MonoBehaviour
{
  public TurnController TurnController;

  public GameObject Light;

  public float Force = 100;

  public string BallTag = "Ball";

  public float FlashDuration = 0.5f;

  private float _lastHitTime;

  public void Start()
  {
    if (TurnController == null)
    {
      Debug.LogError("Assign the TurnController to the PopBumper!");
    }

    if (Light == null)
    {
      Debug.LogError("Assign the Light to the PopBumper!");
    }

    Light.SetActive(false);
  }

  public void Update()
  {
    if (Time.time > _lastHitTime + FlashDuration)
    {
      Light.SetActive(false);
    }
  }

  public void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == BallTag)
    {
      var directionToBall = (collision.gameObject.transform.position - transform.position).normalized;
      collision.gameObject.rigidbody.AddForce(directionToBall * Force);

      TurnController.CurrentPlayer.AddScore(100);

      Light.SetActive(true);
      _lastHitTime = Time.time;
    }
  }
}