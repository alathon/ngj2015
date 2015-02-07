using System;
using GamepadInput;
using UnityEngine;
using System.Collections;

public class FindLeftController : MonoBehaviour
{
    [SerializeField] public GamepadController LeftController;
    [SerializeField] public GamepadController RightController;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        // release button
        foreach (GamePad.Button b in Enum.GetValues(typeof(GamePad.Button)))
        {
            if (GamePad.GetButtonDown(b, GamePad.Index.One))
            {
                LeftController.SetIndex(GamePad.Index.One);
                RightController.SetIndex(GamePad.Index.Two);
                DestroyImmediate(this.gameObject);
            }
            else if (GamePad.GetButtonDown(b, GamePad.Index.Two))
            {
                LeftController.SetIndex(GamePad.Index.Two);
                RightController.SetIndex(GamePad.Index.One);
                DestroyImmediate(this.gameObject);
            }
        }
    }
}
