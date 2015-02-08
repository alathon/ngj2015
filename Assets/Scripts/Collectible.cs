using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	private GameObject stuck;
	private Transform pastParent;
    private BoxCollider collider;

    void Awake()
    {
        this.collider = this.GetComponent<BoxCollider>();
    }

	public bool IsStuck() {
		return stuck != null;
	}

	public void StickTo(GameObject gObj) {
		this.collider.enabled = false;
		this.stuck = gObj;
		this.pastParent = this.transform.parent;
		this.transform.SetParent (gObj.transform);

        SofaArea sofa = FindObjectOfType<SofaArea>();

        // HARDCODED MUAHAHAHA
	    if (CompareTag("TVRemote"))
	    {
	        GameObject.FindObjectOfType<TVController>().OnWeird();
            
            sofa.babyScream.Stop();
	        sofa.remoteText.enabled = false;
	        sofa.sofaText.enabled = false;
	        sofa.tvText.enabled = true;
	    }
	    if (CompareTag("Glass"))
	        sofa.glassText.enabled = false;
	}

	public void Unstick() {
		if (this.pastParent != null) {
			this.transform.SetParent(this.pastParent);
		}
        this.stuck = null;
        this.collider.enabled = true;
	}
}