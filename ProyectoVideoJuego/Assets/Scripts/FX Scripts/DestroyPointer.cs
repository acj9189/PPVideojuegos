using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPointer : MonoBehaviour {

	private Transform player;

	void Start () {
		player = null;
	}

	void Update () {

		if (player==null && GameObject.FindGameObjectWithTag ("Player") != null) {
			player = GameObject.FindGameObjectWithTag ("Player").transform;
		}
		if(player!=null){
			if (Vector3.Distance (transform.position, player.position) <= 1f) {
				Destroy (gameObject);
			}	
		}
	}


} // class
