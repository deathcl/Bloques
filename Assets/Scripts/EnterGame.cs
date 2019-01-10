using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    public ElementoInteractivo clickPantalla;

    void Update()
    {
        if (Input.GetButtonDown("Jump") || clickPantalla.pulsado)
        {
            Vidas.vidas = 5;
            Puntos.puntos = 0;
            SceneManager.LoadScene("nivel1");
        }
    }
}
