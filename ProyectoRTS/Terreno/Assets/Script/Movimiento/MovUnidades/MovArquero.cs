using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovArquero : MovTester {

	public float MaxdistanciaCombate=100;
	public LayerMask Capa;

	private NavMeshAgent agente;
	private float tiempo;
	private float tiempoSalida;
	private Armas arma;
	private MovTester ActualEnemigo;

	//adicionadas
	private Vector3 posicion;
	private bool caminata=false;
	// Use this for initialization
	public override void Init () {
		this.agente = GetComponent<NavMeshAgent>();
		this.tiempoSalida=1f;
		this.arma = GetComponent<Armas> ();
	}

	public override void OrdenMov(Vector3 MundoPos){
		this.GetComponent<Animator> ().SetInteger ("Caminar",1);
		this.agente.SetDestination(MundoPos);
		this.caminata = true;
		this.posicion = MundoPos;
	}

	void Update(){

		if(Vector3.Distance(this.transform.position,this.posicion)<0.4f){
			this.agente.SetDestination(this.transform.position);
			this.GetComponent<Animator> ().SetInteger ("Caminar",0);
			this.caminata = false;
		}


		this.tiempo += Time.deltaTime;

		//Buqueda Enemigo
		if(this.tiempo>this.tiempoSalida){
			this.tiempo = 0;
			if(this.ActualEnemigo == null){
				this.CheckSurrounding ();
			}else {
				//this.CheckSurrounding ();
				float Distancia = Vector3.Distance (
					this.transform.position,
					this.ActualEnemigo.transform.position
				);

				if(Distancia>this.MaxdistanciaCombate){
					this.ActualEnemigo = null;
				}
			}
		}

		/*if( this.ActualEnemigo != null){
			Vector3 Objetivo = this.ActualEnemigo.transform.position;
			this.transform.LookAt (Objetivo);
			this.transform.Rotate (45,0,0);
			if (this.arma.isRedy) {
				this.GetComponent<Animator> ().SetInteger ("Pelea",1);
				this.arma.dispara ();
				this.agente.SetDestination (this.transform.position);
				this.GetComponent<Animator> ().SetInteger ("Caminar",0);
			}
		}*/
	
	}


	//metodo que busca los enemigos
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
					if (posibleEnemigo.faccion != this.faccion) {
						this.ActualEnemigo = posibleEnemigo;
					}
				}
			}
		}
	}
}
