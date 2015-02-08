using UnityEngine;
using System.Collections;

public class TVController : MonoBehaviour
{

    public AudioClip waltzClip;
    public AudioClip creepyClip;
    public AudioClip weirdClip;

    public Texture2D normalChickenTexture;
    public Texture2D creepyChickenTexture;
    public Texture2D bakedChickenTexture;

    public Material tvScreenMat;

    // Use this for initialization
	void Start ()
	{
	    audio.clip = waltzClip;
	    audio.loop = true;
        audio.Play();
	    tvScreenMat.mainTexture = normalChickenTexture;
	}

    public void OnNormal()
    {
        audio.clip = waltzClip; // TODO: fade
        audio.Play();
        tvScreenMat.mainTexture = normalChickenTexture;
    }

    public void OnCreepy()
    {
        audio.clip = creepyClip; // TODO: fade
        audio.Play();
        tvScreenMat.mainTexture = creepyChickenTexture;
    }

    public void OnWeird()
    {
        audio.clip = weirdClip; // TODO: fade
        audio.Play();
        tvScreenMat.mainTexture = bakedChickenTexture;
    }
}
