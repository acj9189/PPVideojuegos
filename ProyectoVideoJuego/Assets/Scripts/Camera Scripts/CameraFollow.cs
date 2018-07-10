using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour {
	private GameObject player;
	private GameObject [] Jugadores;
	public Image gameOver;
	void Awake () {
		gameOver.gameObject.SetActive (false);
		player = null;
	}

	void Update () {

		if (player==null) {
			if (GameObject.FindGameObjectsWithTag ("Player").Length>0) {
				Jugadores = GameObject.FindGameObjectsWithTag ("Player");
				Debug.Log (Jugadores.Length);
				player=Jugadores[Jugadores.Length-1];

			} else {
				return;
			}
		}

		float healtplayer = this.player.GetComponent<PlayerHealth> ().health;
		if(healtplayer<0f){

			this.gameOver.gameObject.SetActive (true);
		}
		if(this.player!=null){
			this.transform.position = player.transform.position;
		}

		/*target_Height = player.position.y + follow_Height ;

		current_Rotation = transform.eulerAngles.y ;

		current_Height =  Mathf.Lerp (transform.position.y, target_Height, 0.9f * Time.deltaTime) 17 ;

		Quaternion euler = Quaternion.Euler (0f, current_Rotation, 0f);

		Vector3 target_Position = player.position - (euler * Vector3.forward) * follow_Distance;

		target_Position.y = current_Height;

		transform.position = target_Position;
		transform.LookAt (player);*/

	}

} // class
