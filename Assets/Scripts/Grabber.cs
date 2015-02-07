using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour {
	[SerializeField]
	public GameObject test;

	public Collectible collectible;

	public void OnCollisionEnter(Collision col) {
		var coll = col.gameObject.GetComponent<Collectible> ();
		if (coll) {
			this.Collect(coll);
		}
	}

	private void Collect(Collectible coll) {
		coll.StickTo (this.gameObject);
		this.collectible = coll;
	}

	public void Drop() {
	    if (this.collectible == null) return;

	    this.collectible.Unstick ();
	    this.rigidbody.AddExplosionForce (10, this.transform.position, 1f);
	    this.collectible = null;
	}
}