using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public static int puntos = 0;
    public Text textoPuntos;
    public GameObject levelComplete;
    public GameObject gameComplete;
    public NextLevel nextLevel;
    public Bola bola;
    public Barra barra;
    public Transform contenedorBloques;

    void Start()
    {
        UpdatePuntos();
    }

    void UpdatePuntos()
    {
        textoPuntos.text = "Puntos: " + Puntos.puntos; //asignamos el texto mas la veriable que contiene la cantidad de puntos
    }

    public void GanaPuntos(int cantidad)
    {
        Puntos.puntos = Puntos.puntos + cantidad;
        UpdatePuntos();
        if(contenedorBloques.childCount <= 0)
        {
            bola.DetenerMovimiento();
            barra.enabled = false;
            if (nextLevel.EsUltimoNivel())
            {
                gameComplete.SetActive(true);
            }
            else
            {
                levelComplete.SetActive(true);
            }
            nextLevel.ActivarCarga();
        }
    }
}
