using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Clase verificadora de la Seleccion Unica.
/// </summary>
public class su1 : MonoBehaviour
{
    public Text retroalimentacion;
    public Button verdadero;
    public Button falso1;
    public Button falso2;
    public Button falso3;
    public Button siguiente;

    public void respverdadero()
    {
       
        siguiente.gameObject.SetActive(true);
        retroalimentacion.enabled = true;
        retroalimentacion.text = "Correcto";
        verdadero.interactable = !verdadero.interactable;
        falso1.interactable = !falso1.interactable;
        falso2.interactable = !falso2.interactable;
        falso3.interactable = !falso3.interactable;
    }

    public void respfalsa()
    {
        siguiente.gameObject.SetActive(true);
        retroalimentacion.enabled = true;
        retroalimentacion.text = "Incorrecto";
        verdadero.interactable = !verdadero.interactable;
        falso1.interactable = !falso1.interactable;
        falso2.interactable = !falso2.interactable;
        falso3.interactable = !falso3.interactable;
    }

}