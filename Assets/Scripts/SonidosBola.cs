using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosBola : MonoBehaviour
{
    public AudioSource rebote;
    public AudioSource reboteBloqueDuro;
    public AudioSource punto;
    public AudioSource pierde;
    public Vidas vidas;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("bloque"))
        {
            punto.Play();
        }
        if (other.gameObject.CompareTag("barra"))
        {
            rebote.Play();
        }
        if (other.gameObject.CompareTag("BloqueDuroOro") || other.gameObject.CompareTag("BloqueDuroHierro") || other.gameObject.CompareTag("Indestructible"))
        {
            reboteBloqueDuro.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("suelo"))
        {
            //if (GameObject.FindGameObjectsWithTag("bola").Length == 1)
            if (vidas.cantidadBolas == 1)
            {
                pierde.Play();
            } 
        }
    }
}
