using UnityEngine;
using System.Collections;

public class PlungerController : MonoBehaviour
{
  public float Force = 5;
  public float SpringForce = .05f;

  private Vector3 Maxsize;
  private Vector3 Minsize;

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
      //Make sure that we can never get bigger than we can:
      var OriginalSize = transform.localScale; 
      Debug.Log("Original:" + OriginalSize);
      transform.localScale += amount * Time.deltaTime * Force;
      var NewSize = transform.localScale;   
      Debug.Log("NewSize:" + NewSize);
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
      //TODO: Spawn that bad boy!
  }
}