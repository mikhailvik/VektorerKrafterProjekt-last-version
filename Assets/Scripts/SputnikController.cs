using UnityEngine;

public class SputnikController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Rörelsehastighet - hur snabbt Sputnik rör sig
    private Rigidbody2D rb; // Referens till Rigidbody2D-komponenten som används för fysikberäkningar

    void Start()
    {
        // Hämta Rigidbody2D-komponenten som är kopplad till objektet
        rb = GetComponent<Rigidbody2D>();
        
        // Kontrollera om Rigidbody2D inte är kopplat till objektet
        if (rb == null)
        {
            // Om Rigidbody2D saknas, visa ett felmeddelande
            Debug.LogError("Rigidbody2D saknas på Sputnik.");
        }
    }

    void FixedUpdate()
    {
        // Skapa variabler för att hålla reda på rörelsen i X och Y riktning
        float moveX = 0f;
        float moveY = 0f;

        // Kolla om användaren trycker på piltangenterna för att röra Sputnik
        if (Input.GetKey(KeyCode.UpArrow)) moveY = moveSpeed; // Om upp-pilen trycks, sätt Y-rörelsen till positiv hastighet
        if (Input.GetKey(KeyCode.DownArrow)) moveY = -moveSpeed; // Om ner-pilen trycks, sätt Y-rörelsen till negativ hastighet
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -moveSpeed; // Om vänster-pilen trycks, sätt X-rörelsen till negativ hastighet
        if (Input.GetKey(KeyCode.RightArrow)) moveX = moveSpeed; // Om höger-pilen trycks, sätt X-rörelsen till positiv hastighet

        // Skapa en rörelsevektor baserat på inputen från användaren
        Vector2 movement = new Vector2(moveX, moveY);
        
        // Applicera rörelsekraften på objektets Rigidbody2D
        rb.AddForce(movement);

        // Applicera friktion på objektet
        ApplyFriction();
    }

    private void ApplyFriction()
    {
        // Hämta objektets aktuella hastighet
        Vector2 velocity = rb.linearVelocity; // Här används 'velocity' istället för 'linearVelocity' eftersom det är den korrekta metoden i Rigidbody2D
        float speed = velocity.magnitude; // Beräkna hastigheten (storleken på hastighetsvektorn)

        // Om hastigheten är större än 0.1 (för att säkerställa att objektet rör sig)
        if (speed > 0.1f)
        {
            // Skapa en friktionskraft som motverkar rörelsen
            Vector2 frictionForce = -velocity.normalized * 0.1f; // Här minskar vi hastigheten genom att applicera en friktion (ett litet värde för att minska rörelsen)

            // Applicera friktionskraften på Rigidbody2D-komponenten
            rb.AddForce(frictionForce);
        }
    }
}