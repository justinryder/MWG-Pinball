using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

using Assets.Scripts.Enum;
using UnityEngine;

namespace Assets.Scripts
{
  public class FlipperController : MonoBehaviour
  {
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed. Suppression is OK here.")]
    public FlipperSide FlipperSide;
    private Vector3 _initalLeftLimit = new Vector3(10, 140, 270);
    private Vector3 _rotateLeftLimit = new Vector3(0, 220, 0);

    private bool _flipDownLeft = false;
    private bool _flipDownRight = false;

    public float restPositionLeft = 25f;
    public float pressedPositionLeft = 75f;

    public float restPositionRight = -25f;
    public float pressedPositionRight = -75f;

    public float FlipperStrength = 100f;
    public float FlipperDamper = 1f;

    public JointSpring spring = new JointSpring();

    void Awake()
    {
      hingeJoint.useSpring = true;
    }

    // Update is called once per frame
    private void Update()
    {
      JointSpring spring = new JointSpring();

      spring.spring = this.FlipperStrength;
      spring.damper = this.FlipperDamper;

      if (FlipperSide == FlipperSide.Left)
      {
        if (_flipDownLeft)
        {
          spring.targetPosition = pressedPositionLeft;
        }
        else
        {
          spring.targetPosition = restPositionLeft;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
          _flipDownLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
          _flipDownLeft = false;
        }
      }

      if (FlipperSide == FlipperSide.Right)
      {
        if (_flipDownRight)
        {
          spring.targetPosition = pressedPositionRight;
        }
        else
        {
          spring.targetPosition = restPositionRight;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
          _flipDownRight = true;
        }

        if (Input.GetKeyUp(KeyCode.M))
        {
          _flipDownRight = false;
        }
      }

      hingeJoint.spring = spring;
    }
  }
}