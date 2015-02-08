using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    private Vector3 startDist;

    private void Start()
    {
        startDist = player.position - transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	    transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z - startDist.z);
	}
}
