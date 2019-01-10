using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public string nivelACargar;
    public float waitTime;

    //[ContextMenu("Activar Carga")] //para probar metodos sin tener que esperar a que suceda algo en el juego, directamente del inspector
    public void ActivarCarga()
    {
        Invoke("CargarNivel", waitTime);
    }

    void CargarNivel()
    {
        if (!EsUltimoNivel())
        {
            Vidas.vidas++;
        }
        SceneManager.LoadScene(nivelACargar);
    }

    public bool EsUltimoNivel()
    {
        return nivelACargar == "Portada"; //si nivelACargar es = a Portada se devolvera True sino se devuelve False
    }
}
