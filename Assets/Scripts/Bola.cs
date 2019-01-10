using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Rigidbody rig; //creamos una variable tipo rigitbody
    public float velocidadInicial = 600f; //creamos la variable para la velocidad de la pelota con un valor predeterminado
    bool inGame = false; //creamos una variable logica para saber si estamos jugando o la bola esta parada sobre la barra
    Vector3 posicionIncial; //creamos variable para saber la posicion inicial de nuestra bola para luego poder resetearla al perder
    public Transform barra; //creamos una variable de tipo transform para hacer la referencia a barra que es el padre de bola y volver a ponerla como hija
    public ElementoInteractivo clickPantalla;
        
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>(); //asignamos el componente rigitbody que tiene bola a la variable tipo rigitbody rig
        //barra = GetComponentInParent<Transform>(); //asignamos a la variable para que tome el objeto que tiene como padre
        posicionIncial = transform.position; //guardamos la posicion inicial de la bola
    }

    public void Reset() //metodo para resetear la bola cuando cae al suelo
    {
        transform.position = posicionIncial; //resetamos la posicion inicial de la bola al perder
        transform.SetParent(barra); //volvemos a dejar como hija la bola de barra
        inGame = false;
        DetenerMovimiento();
    }

    public void DetenerMovimiento()
    {
        rig.isKinematic = true; //volvemos el kinematic a verdadero ya que queremos que sea la barra la que controle a la bola
        rig.velocity = Vector3.zero; //le quitamos toda velocidad fuerza a la bola
    }

    // Update is called once per frame
    void Update()
    {
        if(!inGame && (Input.GetButtonDown("Jump") || clickPantalla.pulsado)) //si no estamos en juego y pulsamos la tecla espacio
        {
            inGame = true;
            transform.SetParent(null); //sacamos a la bola como hija de barra
            rig.isKinematic = false; //sacamos el valor kinematic ya que no lo necesitamos al no ser hija de barra
            rig.AddForce(new Vector3(velocidadInicial, velocidadInicial, 0)); //le añadimos una fuerza para que la bola comienze a rebotar
        }
    }
}
