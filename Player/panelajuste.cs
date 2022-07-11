using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase del panel de ajuste.
/// </summary>
public class panelajuste : MonoBehaviour
{
    public GameObject panelajustes;
/// <summary>
/// activa el panel
/// </summary>
    public void activarpanel()
    {
        panelajustes.SetActive(true);
    }
/// <summary>
/// desativa el panel
/// </summary>
    public void desactivarpanel()
    {
        panelajustes.SetActive(false);
    }
}
