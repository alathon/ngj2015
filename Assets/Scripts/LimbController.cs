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

    public void AddForce(Limb limb, Vector3 force)
    {

    }
}
