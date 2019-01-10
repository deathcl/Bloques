using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public GameObject efectoPaticulas; //creamos un objeto para instanciar el efecto de particulas en la colision
    public Puntos puntos;
    private int hitsBloqueDuroOro = 2;
    private int hitsBloqueDuroHierro = 4;
    private int hitsIndestructible = 99999;
    private int cantidadPuntos = 1;
    private Renderer colorCubo;
    private bool pintarRandom = true;
    private float waitTime = 0.01f;
    public GameObject prefab;
    public Bola bola;
    public Vidas vidas;

    void FixedUpdate()
    {
        if (gameObject.CompareTag("BloqueArcoiris"))
        {
            Invoke("CambiaColorBloque", waitTime);
        }
    }

    void CambiaColorBloque()
    {
        colorCubo = gameObject.GetComponent<Renderer>();
        colorCubo.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    void OnCollisionEnter()
    {
        if (gameObject.CompareTag("BloqueDuroOro") && hitsBloqueDuroOro > 0)
        {
            hitsBloqueDuroOro--;
            cantidadPuntos = 2;
        }
        else if (gameObject.CompareTag("BloqueDuroHierro") && hitsBloqueDuroHierro > 0)
        {
            hitsBloqueDuroHierro--;
            cantidadPuntos = 4;
        }
        else if (gameObject.CompareTag("Indestructible") && hitsIndestructible > 0)
        {
            hitsIndestructible--;
        }
        else if (gameObject.CompareTag("BloqueArcoiris"))
        {
            DestruirBloque();
            GameObject bola2 = Instantiate(prefab, bola.transform.position, Quaternion.identity);
            bola2.name = "bola2";
            bola2.GetComponent<Rigidbody>().isKinematic = false;
            bola2.GetComponent<Rigidbody>().AddForce(new Vector3(bola.velocidadInicial, bola.velocidadInicial, 0));

            GameObject bola3 = Instantiate(prefab, bola.transform.position, Quaternion.identity);
            bola3.name = "bola3";
            bola3.GetComponent<Rigidbody>().isKinematic = false;
            bola3.GetComponent<Rigidbody>().AddForce(new Vector3(bola.velocidadInicial, bola.velocidadInicial, 0));

            vidas.cantidadBolas = 3;
        }
        else
        {
            DestruirBloque();
        }
    }

    void DestruirBloque()
    {
        Destroy(gameObject); //destruimos el bloque que colisiono con la bola
        transform.SetParent(null);
        Instantiate(efectoPaticulas, transform.position, Quaternion.identity);
        //instanciamos el objeto de particulas, quaternion.identity es valor default de rotacion
        puntos.GanaPuntos(cantidadPuntos);
    }
}
