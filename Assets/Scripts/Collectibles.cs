using UnityEngine;


public class Collectibles : MonoBehaviour
{
  
    // Funktion som körs när spelaren kolliderar med objektet
    private void OnCollisionEnter2D(Collision2D other)
    { 
             Debug.Log("Player collided with collectible: " + gameObject.name);
        // Kontrollera om det är spelaren som kolliderar
        if (other.gameObject.tag == "monstr")
        {

         
            // Dölj eller förstör objektet
            Destroy (gameObject);
        }
    }
}
