using System;
using UnityEngine;
using System.Collections;
using GamepadInput;

public class GamepadController : MonoBehaviour
{
    public bool isLeft;

    public float armUpForce;
    public float armLeftRightFactor;
    public float armForwardBackwardFactor;

    public float legUpForce;
    public float legLeftRightFactor;
    public float legForwardBackwardFactor;

    private GamePad.Index _index = GamePad.Index.Any; // controller index
    private GamePad.Axis _arm;
    private GamePad.Axis _leg;
    private LimbController _limbController;

    private void Start()
    {
        _arm = isLeft ? GamePad.Axis.LeftStick : GamePad.Axis.RightStick;
        _leg = isLeft ? GamePad.Axis.RightStick : GamePad.Axis.LeftStick;
        _limbController = FindObjectOfType<LimbController>();
    }

    public void SetIndex(GamePad.Index idx)
    {
        _index = idx;
        Debug.Log("Index of GamePadController(" + isLeft + ") set to " + idx);
    }

	void FixedUpdate ()
	{
	    if (_index == GamePad.Index.Any) return;

	    // arm 2 axes
	    Vector2 armMovement = GamePad.GetAxis(_arm, _index);
        _limbController.AddForce(isLeft ? LimbController.Limb.LeftHand : LimbController.Limb.RightHand,
            isLeft ? new Vector3(armMovement.y * armLeftRightFactor,
                                armMovement.y > 0 ? armUpForce : 0,
                                -armMovement.x * armForwardBackwardFactor)
                    : new Vector3(-armMovement.y * armLeftRightFactor,
                                armMovement.y > 0 ? armUpForce : 0,
                                armMovement.x * armForwardBackwardFactor));

	    // leg 2 axes
	    Vector2 legMovement = GamePad.GetAxis(_leg, _index);
        _limbController.AddForce(isLeft ? LimbController.Limb.LeftFoot : LimbController.Limb.RightFoot,
            isLeft ? new Vector3(legMovement.y * legLeftRightFactor,
                                legMovement.y > 0 ? legUpForce : 0,
                                -legMovement.x * legForwardBackwardFactor)
                    : new Vector3(-legMovement.y * legLeftRightFactor,
                                legMovement.y > 0 ? legUpForce : 0,
                                legMovement.x * legForwardBackwardFactor));

	    // release button
	    foreach (GamePad.Button b in Enum.GetValues(typeof(GamePad.Button)))
	    {
	        if (GamePad.GetButtonDown(b, _index))
	            _limbController.Release(isLeft ? LimbController.Limb.LeftHand : LimbController.Limb.RightHand);
	    }
	}
}
