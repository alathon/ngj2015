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

    private GamePad.Index _index; // controller index
    private GamePad.Axis _arm;
    private GamePad.Axis _leg;

    public LimbController limbController;

    private void Start()
    {
        _index = isLeft ? GamePad.Index.One : GamePad.Index.Two;
        _arm = isLeft ? GamePad.Axis.LeftStick : GamePad.Axis.RightStick;
        _leg = isLeft ? GamePad.Axis.RightStick : GamePad.Axis.LeftStick;
    }

	void FixedUpdate () {
	    // arm 2 axes
	    Vector2 armMovement = GamePad.GetAxis(_arm, _index);
        limbController.AddForce(isLeft ? LimbController.Limb.LeftHand : LimbController.Limb.RightHand,
            isLeft ? new Vector3(-armMovement.y * armLeftRightFactor,
                                armUpForce,
                                -armMovement.x * armForwardBackwardFactor)
                    : new Vector3(armMovement.y * armLeftRightFactor,
                                armUpForce,
                                armMovement.x * armForwardBackwardFactor));

	    // leg 2 axes
	    Vector2 legMovement = GamePad.GetAxis(_leg, _index);
        limbController.AddForce(isLeft ? LimbController.Limb.LeftFoot : LimbController.Limb.RightFoot,
            isLeft ? new Vector3(-legMovement.y * legLeftRightFactor,
                                legUpForce,
                                -legMovement.x * legForwardBackwardFactor)
                    : new Vector3(legMovement.y * legLeftRightFactor,
                                legUpForce,
                                legMovement.x * legForwardBackwardFactor));

	    // release button
	    foreach (GamePad.Button b in Enum.GetValues(typeof(GamePad.Button)))
	    {
	        if (GamePad.GetButtonDown(b, _index))
	            ; // TODO
	    }
	}
}
