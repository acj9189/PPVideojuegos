using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Proyectil : MonoBehaviour {

	public float velocidad = 8;
	public Armas arma;
	public float duracion = 10;

	void Start(){
		Destroy (this.gameObject,this.duracion);
		GetComponent<Rigidbody> ().velocity= this.transform.forward * this.velocidad;
	}

	void OnCollisionEnter(){
		Unidad u = gameObject.GetComponent<Unidad> ();
		if (u != null && u.tag=="Enemigo") {
			Debug.Log ("Enemigo "+u.name);
			this.arma.OnProyectilCollision (this,u);
		} 

		/*else {
			Destroy (this.gameObject);
		
		}*/
			
	}
}
