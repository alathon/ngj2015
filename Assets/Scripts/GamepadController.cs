using UnityEngine;
using System.Collections;
using GamepadInput;

public class GamepadController : MonoBehaviour
{
    public bool isLeft;

    private GamePad.Index index; // controller index
    private GamePad.Axis arm;
    private GamePad.Axis leg;

    private void Start()
    {
        index = isLeft ? GamePad.Index.One : GamePad.Index.Two;
        arm = isLeft ? GamePad.Axis.LeftStick : GamePad.Axis.RightStick;
        leg = isLeft ? GamePad.Axis.RightStick : GamePad.Axis.LeftStick;
    }

	void Update () {
	    // arm 2 axes
	    Vector2 armMovement = GamePad.GetAxis(arm, index);

	    // leg 2 axes
	    Vector2 legMovement = GamePad.GetAxis(leg, index);

	    // grab/release button
	}
}
