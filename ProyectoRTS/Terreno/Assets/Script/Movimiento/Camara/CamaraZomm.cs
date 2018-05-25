using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraZomm : MonoBehaviour {

    public Camera sceneCamera;
    public float minSize = 8;
    public float maxSize = 16;

    private float currentSize;

    // ================================
    void Start()
    {
        this.currentSize = this.sceneCamera.orthographicSize;
    }

    // ================================
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            this.currentSize -= Input.mouseScrollDelta.y;

            this.currentSize = Mathf.Clamp(this.currentSize, this.minSize, this.maxSize);

            this.sceneCamera.orthographicSize = this.currentSize;
        }
    }
}
