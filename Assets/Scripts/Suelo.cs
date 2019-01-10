using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suelo : MonoBehaviour
{
    public Vidas vidas; //creamos una variable para hacer referencia al script Vidas y usar sus metodos

    private void OnTriggerEnter(Collider collider)
    {
        vidas.PerderVida(collider);
    }
}
