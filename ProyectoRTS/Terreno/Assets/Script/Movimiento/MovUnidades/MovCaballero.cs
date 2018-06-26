using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovCaballero : MovTester {

	private NavMeshAgent agente;

	//deteccion de esnemigos
	private MovTester ActualEnemigo;
	public float MaxdistanciaCombate;
	public LayerMask Capa;

	private float tiempo;
	private float tiempoSalida;

	private Vector3 objetivo;
	private bool pelear;

	// Use this for initialization
	public override void Init () {
		this.agente = GetComponent<NavMeshAgent>();
		this.MaxdistanciaCombate = 100;
		this.tiempoSalida = 1f;
		this.pelear = false;
	}

	public override void OrdenMov(Vector3 MundoPos)
	{
		this.agente.SetDestination(MundoPos);
		this.objetivo = MundoPos;
		this.GetComponent<Animator> ().SetInteger("Caminar",1);
	}

	public void CheckSurrounding(){

		Collider[] UnidadesCercanas=Physics.OverlapSphere(
			this.transform.position,
			this.MaxdistanciaCombate,
			this.Capa
		);

		for (int i = 0; i < UnidadesCercanas.Length; i++) {
			if (UnidadesCercanas [i].gameObject != this.gameObject) {
				MovTester posibleEnemigo = UnidadesCercanas [i].GetComponent<MovTester> ();
				if(posibleEnemigo!=null){
					if (posibleEnemigo.faccion.name != this.faccion.name) {
						this.ActualEnemigo = posibleEnemigo;

					}
				}
			}
		}
	}

	void Update(){
		float distancia = Vector3.Distance (this.transform.position,this.objetivo);
		if(distancia>this.MaxdistanciaCombate){
			this.ActualEnemigo = null;
		}

		if (!this.pelear) {
			if (distancia <= 0.5) {
				this.objetivo = this.transform.position;
				this.agente.destination = this.objetivo;
				this.GetComponent<Animator> ().SetInteger ("Caminar", 0);
			}
		} else {
			if (distancia <= 20) {
				Debug.Log ("Distancia "+distancia);
				this.objetivo = this.transform.position;
				this.agente.destination = this.objetivo;
				this.GetComponent<Animator> ().SetInteger ("Pelear", 1);
			}
		}

		this.tiempo += Time.deltaTime;
		if (this.tiempo > this.tiempoSalida) {
			this.tiempo = 0;
			if (this.ActualEnemigo == null) {
				this.CheckSurrounding ();
			} else {
				if(!this.pelear){
					Debug.Log ("--------Enemigo pos "+this.ActualEnemigo.transform.position);
				}
				this.pelear = true;
				Debug.Log ("Jugador pos " +this.transform.position);
			}
		}

		if(this.pelear && this.GetComponent<Animator>().GetInteger("Pelear")==0){
			this.GetComponent<Animator> ().SetInteger("Correr",1);
			this.objetivo = this.ActualEnemigo.transform.position;

			//float distance = Vector3.Distance (this.transform.position,this.objetivo);
			this.agente.destination = this.objetivo;

		}
	}
}
