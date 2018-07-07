using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public float follow_Height = 8f;
	public float follow_Distance = 6f;

	private Transform player;

	private bool jugador;

	private float target_Height;
	private float current_Height;
	private float current_Rotation;

	void Awake () {
		this.jugador = false;
		player = null;
		//this.transform.position = this.jugadorASeguir.transform.position; 
	}

	void Update () {

		if(!this.jugador){
			if(this.player==null){
				player = GameObject.FindGameObjectWithTag ("Player").transform;
			}
			if (this.player != null) {
				this.jugador = true;
			}
				
		}
		/*target_Height = player.position.y + follow_Height ;

		current_Rotation = transform.eulerAngles.y ;

		current_Height =  Mathf.Lerp (transform.position.y, target_Height, 0.9f * Time.deltaTime) 17 ;

		Quaternion euler = Quaternion.Euler (0f, current_Rotation, 0f);

		Vector3 target_Position = player.position - (euler * Vector3.forward) * follow_Distance;

		target_Position.y = current_Height;

		transform.position = target_Position;
		transform.LookAt (player);*/

		this.transform.position = player.position;
	}

} // class






































