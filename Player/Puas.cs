using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Clase para creae daño al personje
/// </summary>
public class Puas : MonoBehaviour
{
   public int daño;
   public GameObject player;

   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Player")
       {
            player.GetComponent<Player>().vidaplayer -= daño;
       }
   }
}
