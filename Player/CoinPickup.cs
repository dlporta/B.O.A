using UnityEngine;
/// <summary>
/// Clase recolectora de monedas.
/// </summary>
public class CoinPickup : MonoBehaviour {
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            AudioManager.instance.PlaySFX(1);
            Destroy(gameObject);
        }
    }
}
