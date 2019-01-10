using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barra : MonoBehaviour
{
    public float velocidad = 30f;
    float moveSpeed = 30f; //30 para ocuparlo con PC
    Vector3 posicionInicial;
    public ElementoInteractivo botonIzquierda;
    public ElementoInteractivo botonDerecha;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        //esta linea evalua con 2 if si se esta pulsando el tactil izqui o derch
        float direccion = botonIzquierda.pulsado ? -1 : (botonDerecha.pulsado ? 1 : Input.GetAxisRaw("Horizontal"));

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 TouchPosition = Input.GetTouch(0).deltaPosition;
            transform.Translate(TouchPosition.x * moveSpeed * Time.deltaTime, 0, 0);
        }

        //float tecladoHorizontal = Input.GetAxisRaw("Horizontal");
        float posX = transform.position.x + (direccion * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(posX,-8,8), transform.position.y, transform.position.z);
    }

    //con este metodo hacemos que la barra vuelva a la posicion inicial luego de que la bola caiga
    public void Reset()
    {
        transform.position = posicionInicial;
    }
}
