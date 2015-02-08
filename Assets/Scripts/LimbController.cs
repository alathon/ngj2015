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
        RightFoot,
        Spine,
        Head
    }

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftFoot;
    [SerializeField] private GameObject rightFoot;
    [SerializeField]
    private GameObject spine;
    [SerializeField]
    private GameObject head;

    private ConstantForce torsoForce;

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
        this.limbToGameObj[hand].GetComponent<Grabber>().Drop();
    }

    void Awake()
    {
        
        this.limbToGameObj = new Dictionary<Limb, GameObject>()
        {
            {Limb.LeftHand, leftHand},
            {Limb.RightHand, rightHand},
            {Limb.LeftFoot, leftFoot},
            {Limb.RightFoot, rightFoot},
            {Limb.Spine, spine},
            {Limb.Head, head}
        };

        this.torsoForce = this.limbToGameObj[Limb.Spine].GetComponent<ConstantForce>();

        Verify();
    }

    void Update()
    {
        
    }

    void Reset()
    {
        Verify();
    }

    public void AddForce(Limb limb, Vector3 force)
    {
        //this.limbToGameObj[Limb.Spine].rigidbody.AddForce(new Vector3(0, -force.y, 0));
        //this.torsoForce.force = new Vector3(this.torsoForce.force.x, this.torsoForce.force.y - force.y, this.torsoForce.force.z);
        this.limbToGameObj[limb].rigidbody.AddForce(force);
    }
}