using UnityEngine;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Jim")) // Ensure the player has the tag "Player"
        {
            Globals.jimHealth = 0;
            Debug.Log("Jim fell into the void!");

        } else
        {
            Globals.jonHealth = 0;
            Debug.Log("Jon fell into the void!");
        }
        KillPlayer(other.gameObject);
    }

    void KillPlayer(GameObject player)
    {
        // Example: Reset player position
        Globals.win = true;
        Debug.Log("player died");
    }

    
}