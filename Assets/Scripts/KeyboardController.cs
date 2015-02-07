using System;
using UnityEngine;
using System.Collections;
using GamepadInput;

public class KeyboardController : MonoBehaviour {
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

    private LimbController _limbController;

	private void Start () {
        _index = isLeft ? GamePad.Index.One : GamePad.Index.Two;
        _arm = isLeft ? GamePad.Axis.LeftStick : GamePad.Axis.RightStick;
        _leg = isLeft ? GamePad.Axis.RightStick : GamePad.Axis.LeftStick;
        _limbController = FindObjectOfType<LimbController>();
	}
	
	private void Update () {
        // arm 2 axes
	    Vector2 armMovement = Vector2.zero;
	    if (Input.GetKeyDown(isLeft ? KeyCode.A : KeyCode.J)) // left
	        armMovement.x = -1;
        if (Input.GetKeyDown(isLeft ? KeyCode.D : KeyCode.L)) // right
            armMovement.x = 1;
        if (Input.GetKeyDown(isLeft ? KeyCode.W : KeyCode.I)) // forward
            armMovement.y = -1;
        if (Input.GetKeyDown(isLeft ? KeyCode.S : KeyCode.K)) // backward
            armMovement.y = 1;

	    Vector2 legMovement = Vector2.zero;
	    if (Input.GetKeyDown(isLeft ? KeyCode.LeftShift : KeyCode.RightShift))
	    {
	        legMovement = armMovement;
	        armMovement = Vector2.zero;
	    }

        _limbController.AddForce(isLeft ? LimbController.Limb.LeftHand : LimbController.Limb.RightHand,
                                new Vector3(armMovement.x * armLeftRightFactor,
                                            armMovement != Vector2.zero ? armUpForce : 0,
                                            armMovement.y * armForwardBackwardFactor));

        // leg 2 axes
        _limbController.AddForce(isLeft ? LimbController.Limb.LeftFoot : LimbController.Limb.RightFoot,
                                new Vector3(legMovement.x * legLeftRightFactor,
                                            legMovement != Vector2.zero ? legUpForce : 0,
                                            legMovement.y * legForwardBackwardFactor));

        // release button
        if(Input.GetKeyDown(KeyCode.Space))
            _limbController.Release(isLeft ? LimbController.Limb.LeftHand : LimbController.Limb.RightHand);
	}
}
