using UnityEngine;
using System.Collections;

public class PlungerController : MonoBehaviour
{

  // Use this for initialization
  private void Start()
  {

  }

  // Update is called once per frame
  private void Update()
  {
      Vector3 input = new Vector3(0, Input.GetAxis("Vertical"), 0);
      transform.position += input * Time.deltaTime;
  }

  public void SpawnBall()
  {
      //TODO: Spawn that bad boy!
  }
}