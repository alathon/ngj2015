using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
	private GameObject stuck;
	private Transform pastParent;

	public bool IsStuck() {
		return stuck != null;
	}

	public void StickTo(GameObject gObj) {
		this.GetComponent<BoxCollider> ().isTrigger = true;
		this.stuck = gObj;
		this.pastParent = this.transform.parent;
		this.transform.SetParent (gObj.transform);

	}

	public void Unstick() {
		this.stuck = null;
		this.GetComponent<BoxCollider> ().isTrigger = false;
		if (this.pastParent != null) {
			this.transform.SetParent(this.pastParent);
		}
	}
}