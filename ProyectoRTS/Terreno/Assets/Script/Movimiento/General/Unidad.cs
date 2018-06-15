using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unidad : MonoBehaviour {

	//esta es la parte que se va a cambiar creo
	private Plane PlanoUbicacion;
	public SeleccionCaja SelectCaja;
	public Camera PrinCamara;
	//fin 

    public List<MovTester> Testers;
	public List<MovTester> SelectUnidades;
///
	public Faccion faccion;
	public bool Seleccionando;

	public int distanciaRayo;

	// Use this for initialization
	void Start()
	{
		this.PlanoUbicacion.SetNormalAndPosition(Vector3.up, Vector3.zero);
		this.Seleccionando = false;
		distanciaRayo = 100000;
	}

////	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.Seleccionando = true;
			this.SelectCaja.Inicio(Input.mousePosition);
		
		}
			
////
		if (this.Seleccionando) {
			if (Input.GetAxis ("Mouse X") != 0 || Input.GetAxis ("Mouse Y") != 0) {
				//Arrastrando
				this.SelectCaja.Arrastre (Input.mousePosition);
				//seleccion unidades
				foreach (MovTester u in this.Testers) {
					Vector2 coordenadasScreen = this.PrinCamara.WorldToScreenPoint (u.transform.position);
					if (this.SelectCaja.Seleccion.Contains (coordenadasScreen)) {
						if (!u.EstaSeleccionado && u.UninJugador) {
							u.EstaSeleccionado = true;
							this.SelectUnidades.Add (u);
						}
					} else {
						if (u.EstaSeleccionado) {
							u.EstaSeleccionado = false;
							this.SelectUnidades.Remove (u);
						}
					}
				}

			}
			if (Input.GetMouseButtonUp(0)){
////				
				this.Seleccionando = false;
				this.SelectCaja.Fin();
				if (!this.SelectCaja.EsValido()){
////	
////				//limpiar unidades seleccionadas
					for (int i=0;i<this.SelectUnidades.Count;i++){
						this.SelectUnidades[i].EstaSeleccionado = false;
					}
					this.SelectUnidades.Clear();

					Ray Rayo = this.PrinCamara.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
////
					if (Physics.Raycast(Rayo,out hit, distanciaRayo)){
						GameObject go = hit.collider.gameObject;
						MovTester u = go.GetComponent<MovTester>();
						if (u != null && u.UninJugador){
							u.EstaSeleccionado = true;
							this.SelectUnidades.Add(u);
						}
					}
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			Ray rayo = PrinCamara.ScreenPointToRay(Input.mousePosition);

			RaycastHit distancia;
			if (Physics.Raycast (rayo, out distancia,distanciaRayo)) {
				
				Vector3 punto = distancia.point;
				Vector3 Vectorsuma = new Vector3 (0,0,10);
				foreach (MovTester u in this.SelectUnidades) {
					u.OrdenMov (punto);
					punto = punto + Vectorsuma;
				}
			}
		}
	}
	public virtual void RemoverUndad(MovTester u){
		this.Testers.Remove (u);
		this.SelectUnidades.Remove (u);
	}
}

