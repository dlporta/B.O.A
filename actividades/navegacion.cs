using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Clase de navegacion de los 'Canvas'
/// </summary>
public class navegacion : MonoBehaviour
{

    public Button siguiente;
    public Text retroalimentacion;

    public Canvas [] nejer;//arreglo de los canvas

    public int nEscena = 1;
    public int limiteNScena;


    void Start()
    {
        verEscena();
    }
    /// <summary>
    /// desactiva los canvas segun el orden
    /// </summary>
    public void verEscena(){
        switch (nEscena)
        {
            case 1:
                siguiente.gameObject.SetActive(false);
                retroalimentacion.enabled = false;
                nejer[0].enabled = true;
                nejer[1].enabled = false;
                nejer[2].enabled = false;
                nejer[3].enabled = false;
                nejer[4].enabled = false;
                nejer[5].enabled = false;
                break;
            case 2:
                siguiente.gameObject.SetActive(false);
                retroalimentacion.enabled = false;
                nejer[0].enabled = false;
                nejer[1].enabled = true;
                nejer[2].enabled = false;
                nejer[3].enabled = false;
                nejer[4].enabled = false;
                nejer[5].enabled = false;
                break; 

            case 3:
                siguiente.gameObject.SetActive(false);
                retroalimentacion.enabled = false;
                nejer[0].enabled = false;
                nejer[1].enabled = false;
                nejer[2].enabled = true;
                nejer[3].enabled = false;
                nejer[4].enabled = false;
                nejer[5].enabled = false;
                break;

            case 4:
                siguiente.gameObject.SetActive(false);
                retroalimentacion.enabled = false;
                nejer[0].enabled = false;
                nejer[1].enabled = false;
                nejer[2].enabled = false;
                nejer[3].enabled = true;
                nejer[4].enabled = false;
                nejer[5].enabled = false;
                break;


            case 5:
                siguiente.gameObject.SetActive(false);
                retroalimentacion.enabled = false;
                nejer[0].enabled = false;
                nejer[1].enabled = false;
                nejer[2].enabled = false;
                nejer[3].enabled = false;
                nejer[4].enabled = true;
                nejer[5].enabled = false;
                break;

            case 6:
                siguiente.gameObject.SetActive(false);
                retroalimentacion.enabled = false;
                nejer[0].enabled = false;
                nejer[1].enabled = false;
                nejer[2].enabled = false;
                nejer[3].enabled = false;
                nejer[4].enabled = false;
                nejer[5].enabled = true;
                break;
            default:
                break;
        }
    }
/// <summary>
/// Realiza el avanse de los convas mediante n valor
/// </summary>
/// <remarks>nEscena:  valor de los canvas
/// limiteNScena: valor final de los canvas</remarks>
    public void avanzar(){
        if(nEscena<limiteNScena){
            nEscena++;
        }
        verEscena();
    }
}
