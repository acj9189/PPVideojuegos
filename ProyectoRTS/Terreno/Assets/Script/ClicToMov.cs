using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClicToMov : MonoBehaviour {


	private NavMeshAgent jugador;
	public Camera Camara;
	private int DistanciaRayo;
	private bool Atacar;
	private Armas arma;
	private MovTester Enemigo;
	private Vector3 Objetivo;

	private int PuntosAtaque;
	private int PuntosDefensa;

	// Use this for initialization
	void Start () {
		this.jugador=GetComponent<NavMeshAgent> ();
		this.DistanciaRayo = 200;
		this.Atacar = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(this.transform.position,this.Objetivo)<=0.5){
			if(!Atacar){
				this.Objetivo = this.transform.position;
				this.jugador.destination = Objetivo;
			}
		}


		if(Input.GetMouseButtonDown(0)){
			Ray Rayo = this.Camara.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast (Rayo, out hit, DistanciaRayo)) {
				GameObject PosEnemigo = hit.collider.gameObject;
				this.Enemigo=PosEnemigo.GetComponent<MovTester>();
				if (Enemigo == null) {
					Debug.Log (hit.point);
					this.Objetivo = hit.point;
					OrdenMover (hit.point);
					this.Atacar = false;
				} else {
					this.Objetivo = hit.point;
					OrdenMover (Enemigo.transform.position);
					this.Atacar = true;
				}
			}
		}
	}

	public void OrdenMover(Vector3 Punto){
		this.jugador.destination = Punto;
	}
}
