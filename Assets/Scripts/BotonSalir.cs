using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour
{
    public bool salir;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (salir)
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene("Portada");
            }
        }       
    }
}
