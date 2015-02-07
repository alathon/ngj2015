using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LimbController : MonoBehaviour
{
    public enum Limb
    {
        LeftHand,
        RightHand,
        LeftFoot,
        RightFoot
    }

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftFoot;
    [SerializeField] private GameObject rightFoot;

    private Dictionary<Limb, GameObject> limbToGameObj;

    private void Verify()
    {
        if (leftHand == null || leftHand.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Left hand gameObject null, OR left hand gameObject has no rigidbody component!");
        }

        if (rightHand == null || rightHand.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Right hand gameObject null, OR right hand gameObject has no rigidbody component!");
        }

        if (leftFoot == null || leftFoot.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Left foot gameObject null, OR left leg gameObject has no rigidbody component!");
        }

        if (rightFoot == null || rightFoot.GetComponent<Rigidbody>() == null)
        {
            Debug.LogError("Right foot gameObject null, OR right foot gameObject has no rigidbody component!");
        }
    }

    public void Release(Limb hand)
    {
        
    }

    void Awake()
    {
        this.limbToGameObj = new Dictionary<Limb, GameObject>()
        {
            {Limb.LeftHand, leftHand},
            {Limb.RightHand, rightHand},
            {Limb.LeftFoot, leftFoot},
            {Limb.RightFoot, rightFoot}
        };

        Verify();
    }

    void Reset()
    {
        Verify();
    }

    public void AddForce(Limb limb, Vector3 force)
    {
        this.limbToGameObj[limb].rigidbody.AddForce(force);
    }
}