using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionCaja : MonoBehaviour {

    public Rect Seleccion;

    private new RectTransform transform;

    private Vector3 MouuseStart;

    private float tamañoMinimo;

	// Use this for initialization
	void Start () {
        this.Seleccion.Set(0,0,0,0);

        this.transform = GetComponent<RectTransform>();
        this.transform.gameObject.SetActive(false);

        this.tamañoMinimo = (Screen.width*0.05f+ Screen.height*0.05f)/2f;
	}
	
    public bool EsValido()
    {
        return this.Seleccion.size.magnitude > this.tamañoMinimo;
    }

    public void Inicio(Vector3 mousePos)
    {
        this.MouuseStart = mousePos;
        this.Seleccion.Set(mousePos.x,mousePos.y,0,0);

        this.transform.gameObject.SetActive(true);
        this.transform.offsetMin = this.Seleccion.min;
        this.transform.offsetMax = this.Seleccion.max;
    }

    public void Arrastre(Vector3 MousePos)
    {
        if (MousePos.x<this.MouuseStart.x)
        {
            this.Seleccion.xMin = MousePos.x;
            this.Seleccion.xMax = this.MouuseStart.x;
        }
        else
        {
            this.Seleccion.xMin = this.MouuseStart.x;
            this.Seleccion.xMax = MousePos.x;
        }

        if (MousePos.y < this.MouuseStart.y)
        {
            this.Seleccion.yMin = MousePos.y;
            this.Seleccion.yMax = this.MouuseStart.y;
        }
        else
        {
            this.Seleccion.yMin = this.MouuseStart.y;
            this.Seleccion.yMax = MousePos.y;
        }

        this.transform.offsetMin = this.Seleccion.min;
        this.transform.offsetMax = this.Seleccion.max;
    }

    public void Fin()
    {
        this.transform.gameObject.SetActive(false);
    }
}
