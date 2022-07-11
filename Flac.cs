using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// clase que permite el cambio de escena en el juego
/// </summary>
/// <remarks>Llegados a un determinado punto en el mapa 
/// se realisara el cambio de nivel</remarks>
public class Flac : MonoBehaviour
{
    public int cambio_de_nivel;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(cambio_de_nivel);
        }
    }
}
