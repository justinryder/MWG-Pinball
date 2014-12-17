using System.Runtime.InteropServices;

using UnityEngine;
using System.Collections;

public class LaneLights : MonoBehaviour
{
  public bool status = false;

  void OnCollisionEnter(Collision collision)
  {
    foreach (ContactPoint contact in collision.contacts)
    {
      if (contact.otherCollider.tag == "Ball")
      {
        if (status)
        {
          status = false;
        }
        else
        {
          status = true;
        }
      }
    }
  }

	// Use this for initialization
	void Start () 
  {
    
	}

  // Update is called once per frame
	void Update () 
  {

	}
}
