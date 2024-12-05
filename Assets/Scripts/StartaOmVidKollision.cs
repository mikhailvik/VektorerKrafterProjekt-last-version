using UnityEngine;
using UnityEngine.SceneManagement; // Behövs för att ladda om scenen

public class StartaOmVidKollision : MonoBehaviour
{
    // Denna metod aktiveras automatiskt när en kollision sker
  
      void OnCollisionEnter2D(Collision2D kollision) // Viktoriia Mikhailova bytte -> OnCollisionEnter2D
    {
        // Kontrollera om det krockade objektet har namnet "monstr"

       // if (kollision.gameObject.name == "Monstr") Viktoriia Mikhailova bytte ->
        if (kollision.gameObject.CompareTag("monstr") || kollision.gameObject.CompareTag("ball") || kollision.gameObject.CompareTag("hero"))
        {

            // Skriv ut ett meddelande i konsolen för att verifiera kollisionen
            Debug.Log("Kollision med monstr!");

            // Ladda om den aktuella scenen
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

