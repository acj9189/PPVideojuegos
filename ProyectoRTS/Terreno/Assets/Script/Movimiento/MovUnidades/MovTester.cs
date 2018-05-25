using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovTester : MonoBehaviour {

    public GameObject MarcSeleccion;
    protected bool seleccionado;

    public Unidad UnidadManager;

	public Faccion faccion;

	public bool UninJugador;

	public Renderer[] renderes;

    public bool EstaSeleccionado
    {
        get
        {
            return this.seleccionado;
        }
        set
        {
            //muestra u oculta el cubo 
            this.MarcSeleccion.SetActive(value);
            this.seleccionado = value;
        }
    }

    void Start()
    {
        this.EstaSeleccionado = false;

		this.UnidadManager = GameObject.FindObjectOfType<Unidad> ();

        this.UnidadManager.Testers.Add(this);

		foreach(Renderer r in renderes){
			r.material = this.faccion.materialColor;
		}

       this.Init();

    }

    void OnDestroy()
    {
        //cuando la unidad muere
		this.UnidadManager.RemoverUndad(this);
    }


	/// <summary>
	/// este metodo es como los metodos de la interfaces
	/// </summary>
	/// <param name="MundoPos">Mundo position.</param>
    public virtual void OrdenMov(Vector3 MundoPos)
    { }

	/// <summary>
	/// este metodo es como los metodos de la interfaces
	/// </summary>
    public virtual void Init()
    { }

}
