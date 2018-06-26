using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovAldeano : MovTester {

	private NavMeshAgent agente;
	private Vector3 objetivo;

	private MovTester ActualEnemigo;
	public float MaxdistanciaCombate;
	public LayerMask Capa;

	private float tiempo;
	private float tiempoSalida;
	private bool huyendo;

	public GameObject UbicacionSegura;
	// Use this for initialization
	public override void Init () {
		this.huyendo = false;
		this.MaxdistanciaCombate = 100;
		this.tiempoSalida = 1f;
		this.agente = GetComponent<NavMeshAgent>();
	}

	public override void OrdenMov(Vector3 MundoPos)
	{
		this.GetComponent<Animator> ().SetInteger ("Caminar",1);
		this.agente.destination = MundoPos;
		this.objetivo = MundoPos;
		//this.agente.SetDestination(MundoPos);
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
						break;
					}
				}
			}
		}
	}

	void Update(){
		if(Vector3.Distance(this.transform.position,this.objetivo)<=0.5){
			this.objetivo = this.transform.position;
			this.agente.destination = this.objetivo;
			this.GetComponent<Animator> ().SetInteger ("Caminar",0);
		}

		this.tiempo += Time.deltaTime;
		if(this.tiempo>this.tiempoSalida){
			this.tiempo = 0;
			if(this.ActualEnemigo == null){
				this.CheckSurrounding ();
			}else {
				Debug.Log ("Enemigo Actual aldeano: "+this.ActualEnemigo.name);
				this.huyendo = true;
				//this.CheckSurrounding ();
				/*if (!this.huyendo) {
					this.objetivo = this.UbicacionSegura.transform.position;
					this.huyendo = true;
					this.GetComponent<NavMeshAgent> ().destination = this.objetivo;
					this.GetComponent<Animator> ().SetInteger ("Correr", 1);
					//this.objetivo.y = 0;
				}
				Debug.Log ("objetivo "+this.objetivo+ " this.ubicacion "+this.UbicacionSegura.transform.position );
				if(this.objetivo!= this.UbicacionSegura.transform.position){
					this.ActualEnemigo = null;
					this.huyendo = false;
					this.GetComponent<Animator> ().SetInteger ("Correr", 0);
				}
				float Distancia = Vector3.Distance (
					this.transform.position,
					this.objetivo
				);
				if (Distancia <= 0.5) {
					Destroy (this);
				}*/

			}

			if(this.huyendo){
				this.objetivo = this.UbicacionSegura.transform.position;	
				this.objetivo.y = 0;
				this.agente.destination = this.objetivo;
				this.GetComponent<Animator> ().SetInteger ("Correr",1);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Aldeano Colision "+other.name);
		
		if(other.name=="CentroComunitario"){
			Destroy (this);
			Destroy (other.gameObject);
		}
	}
	/*void OnCollisionEnter (Collision col)
	{
		Debug.Log ("Aldeano Hola");
		if(col.gameObject.name == "CentroComunitario")
		{
			Destroy(col.gameObject);
		}
	}*/
}
