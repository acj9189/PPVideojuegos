using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClicToMov : MonoBehaviour {


	private NavMeshAgent jugador;
	public Camera Camara;
	private int DistanciaRayo;
	private bool Atacar;
	//private Armas arma;
	private ScriptEnemigo Enemigo; // se debe cambiar cuando se defina el enemigo
	private Vector3 Objetivo;

	//private 

	private int PuntosAtaque;
	private int PuntosDefensa;

	// Use this for initialization
	void Start () {
		this.jugador=GetComponent<NavMeshAgent> ();
		this.DistanciaRayo = 500;
		this.Atacar = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Atacar) {
			//float distance = Vector3.Distance (this.transform.position, this.Objetivo);
			//Debug.Log(distance + "distananbciA ENTRE OBJETIVO Y JUGADOR" );
			if(Vector3.Distance(this.transform.position,this.Objetivo) <= 22){

				this.Objetivo = this.transform.position;
				this.jugador.destination = Objetivo;

				this.GetComponent<Animator> ().SetInteger ("Pelear", 1);
				this.GetComponent<Animator> ().SetInteger("Caminar",0);
				this.GetComponent<Animator> ().SetInteger("Correr",0);
			
			}


		} else {


			if(Vector3.Distance(this.transform.position,this.Objetivo)<=0.5){

				this.Objetivo = this.transform.position;
				this.jugador.destination = Objetivo;
				this.GetComponent<Animator> ().SetInteger("Caminar",0);
				this.GetComponent<Animator> ().SetInteger("Correr",0);
			}
		}

		if(Input.GetMouseButtonDown(0)){
			Ray Rayo = this.Camara.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (Rayo, out hit, DistanciaRayo)) {
				this.Enemigo = null;
				GameObject PosEnemigo = hit.collider.gameObject;
				this.Enemigo =  PosEnemigo.GetComponent <ScriptEnemigo>() ;
				if (Enemigo == null) {
					Debug.Log (hit.point);
					this.Objetivo = hit.point;
					this.GetComponent<Animator> ().SetInteger ("Pelear", 0);
					this.GetComponent<Animator> ().SetInteger("Caminar",1);
					OrdenMover (hit.point);

					this.Atacar = false;

				} else {
					this.Objetivo = hit.point;
					this.GetComponent<Animator> ().SetInteger("Correr",1);
					this.transform.LookAt(this.Enemigo.transform.position );
					OrdenMover (Enemigo.transform.position);

					this.Atacar = true;
				}
			}
		}
	}

	public void OrdenMover(Vector3 Punto){
		//this.jugador.destination = Punto;
		this.transform.Translate(Punto);
	}
}
