using UnityEngine;
using System.Collections;

public class SofaArea : MonoBehaviour
{

    private TVController tv;

    private void Start()
    {
        tv = GameObject.FindObjectOfType<TVController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.root.CompareTag("Player"))
            tv.OnCreepy();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
            tv.OnNormal();
    }
}
