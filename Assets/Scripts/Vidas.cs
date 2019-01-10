using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    public static int vidas = 20;
    public Text textoVidas; //referencia al texto de vidas del canvas
    public Bola bola; //referencia al script bola
    public Barra barra; //referencia al script barra
    public GameObject gameOver; //referencia al objeto GameOver del canvas
    public NextLevel nextLevel; //referencia al script para pasar al siguiente nivel
    public int cantidadBolas;

    void Start()
    {
        UpdateVidas();
    }   

    void UpdateVidas()
    {
        textoVidas.text = "Vidas: " + Vidas.vidas; //asignamos el texto mas la veriable que contiene la cantidad de vidas del player
    }

    public void PerderVida(Collider collider)
    {
        //if (GameObject.FindGameObjectsWithTag("bola").Length > 1)
        if (cantidadBolas > 1)
        {
            if (collider.gameObject.name == "Bola")
            {
                bola.enabled = false;
                //bola.DetenerMovimiento();
            }
            else
            {
                Destroy(collider.gameObject);
                cantidadBolas--;
            }   
        }
        if (GameObject.FindGameObjectsWithTag("bola").Length > 1 && cantidadBolas == 1)
        {
            if (collider.gameObject.name == "bola2" || collider.gameObject.name == "bola3")
            {
                Destroy(collider.gameObject);
            }
        }
        if (cantidadBolas == 1)
        {
            Vidas.vidas--;
            UpdateVidas();

            if (Vidas.vidas <= 0)
            {
                gameOver.SetActive(true);
                bola.DetenerMovimiento();
                barra.enabled = false;
                nextLevel.nivelACargar = "Portada";
                nextLevel.ActivarCarga();
            }
            else
            {
                barra.Reset();
                bola.enabled = true;
                bola.Reset();
                cantidadBolas = 1;
            }
        }
    }
}
