using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    float fovInicial = 170f;
    float fovFinal = 60f;
    float fovSpeed = 1f;
    public Camera miCamara;
    public Barra barra;
    public Bola bola;

    void Start()
    {
        miCamara.fieldOfView = fovInicial;
    }

    void FixedUpdate()
    {
        barra.enabled = false;
        bola.enabled = false;

        if (miCamara.fieldOfView > fovFinal)
        {
            miCamara.fieldOfView -= fovSpeed;
        }

        if (miCamara.fieldOfView == fovFinal)
        {
            barra.enabled = true;
            bola.enabled = true;
        }
    }
}
