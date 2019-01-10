using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElementoInteractivo : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool pulsado;
    public bool arrastrado;

    public void OnPointerDown(PointerEventData eventData)
    {
        pulsado = true;
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pulsado = false;
        throw new System.NotImplementedException();
    }
}
