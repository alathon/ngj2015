using UnityEngine;
using System.Collections;

public class Grabber : MonoBehaviour {
	[SerializeField]
	public GameObject test;

	public Collectible collectible;

	public void OnCollisionEnter(Collision col) {
		Collectible coll = col.gameObject.GetComponent<Collectible> ();
		if (coll) {
			this.Collect(coll);
		}
	}

	private void Collect(Collectible coll) {
		coll.StickTo (this.gameObject);
		this.collectible = coll;
	}

	public void Drop() {
		if (this.collectible != null) {
			this.collectible.Unstick ();
			this.rigidbody.AddExplosionForce (10, this.transform.position, 1f);
			this.collectible = null;
		}
		
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.A)) {
			this.Collect(test.GetComponent<Collectible>());
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			this.Drop ();
		}
	}
}