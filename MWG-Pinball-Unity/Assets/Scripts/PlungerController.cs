using UnityEngine;
using System.Collections;

public class PlungerController : MonoBehaviour
{
  public float Force = 5;

  private Vector3 Maxsize;
  private Vector3 Minsize;

  // Use this for initialization
  private void Start()
  {
      Maxsize = collider.bounds.size;
      Minsize = collider.bounds.size / 2;
  }

  // Update is called once per frame
  private void Update()
  {
      Vector3 input = new Vector3(0, Input.GetAxis("Vertical"), 0);
      this.rigidbody.AddForce(input * Time.deltaTime * Force);

      //transform.position += input * Time.deltaTime
  }

  private void Scale(Vector3 amount)
  {
      //Make sure that we can never get bigger than we can:
      var OriginalSize = transform.localScale;
      Debug.Log("Original:" + OriginalSize);
      var NewSize = transform.localScale += amount * Time.deltaTime;
      Debug.Log("New:" + NewSize);
      //if (NewSize < Minsize) {
      //    var newSize = 
      //    }
  }

  public void SpawnBall()
  {
      //TODO: Spawn that bad boy!
  }
}