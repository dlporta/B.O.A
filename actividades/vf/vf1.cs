using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Clase Verificadora del verdadero falso
/// </summary>
public class vf1 : MonoBehaviour
{
    public Button verdadero;
    public Button falso;
    public Button siguiente;
    public Text retroalimentacion;


    public void respverdadero()
    {
        siguiente.gameObject.SetActive(true);
        retroalimentacion.enabled = true;
        retroalimentacion.text = "Correcto";
        verdadero.interactable = !verdadero.interactable;
        falso.interactable = !falso.interactable;
    }

    public void respfalsa()
    {
        siguiente.gameObject.SetActive(true);
        retroalimentacion.enabled = true;
        retroalimentacion.text = "Incorrecto";
        verdadero.interactable = !verdadero.interactable;
        falso.interactable = !falso.interactable;
    }
}
