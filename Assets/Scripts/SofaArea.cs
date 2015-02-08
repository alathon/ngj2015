using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SofaArea : MonoBehaviour
{

    private TVController tv;

    public AudioSource babyScream;
    public Text sofaText;
    public Text remoteText;
    public Text doorText;
    public Text glassText;
    public Text tutorialText;
    public Text tvText;

    private void Start()
    {
        tv = GameObject.FindObjectOfType<TVController>();
        sofaText.enabled = false;
        remoteText.enabled = false;
        doorText.enabled = false;
        glassText.enabled = false;
        tutorialText.enabled = true;
        tvText.enabled = false;

        Invoke("DisableTutorial", 5);
    }

    private void DisableTutorial()
    {
        tutorialText.enabled = false;
        doorText.enabled = true;
        glassText.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            tv.OnCreepy();
            babyScream.Play();
            sofaText.enabled = true;
            remoteText.enabled = true;
            doorText.enabled = false;
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
            tv.OnNormal();
    }*/
}
