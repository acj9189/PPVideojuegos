using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamara : MonoBehaviour {

    // Use this for initialization

    public GameObject jugadorASeguir;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = this.jugadorASeguir.transform.position; 
		//Debug.Log(this.posicionJugador.transform.position);
		//this.transform.position.Set(this.posicionJugador.transform.position.x, 100, this.posicionJugador.transform.position.z);

	


    }
}
