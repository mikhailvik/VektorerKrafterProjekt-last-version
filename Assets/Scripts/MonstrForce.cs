using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector2 PushForce; // Kraft som appliceras kontinuerligt för att flytta objektet åt höger
    public Vector2 JumpForce; // Kraft som appliceras vid hopp

    public Rigidbody2D PhysicsEngine; // Referens till Rigidbody2D-komponenten
    public Friction FrictionEngine; // Referens till Friction-komponenten
    public bool OnGround = false; // Är objektet på marken?

    // Start anropas en gång innan den första uppdateringsramen
    void Start()
    {
        // Hämtar Rigidbody2D-komponenten om den inte har angetts i Inspector
        if (PhysicsEngine == null)
            PhysicsEngine = GetComponent<Rigidbody2D>();

        // Hämtar Friction-komponenten om den inte har angetts i Inspector
        if (FrictionEngine == null)
            FrictionEngine = GetComponent<Friction>();
    }

    // Update anropas en gång per bildruta
    void Update()
    {
        if (OnGround)
        {
            // Applicerar PushForce med hjälp av Friction-komponenten
            FrictionEngine.ApplyForce(PushForce);
        }

        // Hoppfunktion
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            // Applicerar impuls för hopp
            PhysicsEngine.AddForce(JumpForce, ForceMode2D.Impulse);
            OnGround = false; // Objektet är nu i luften
        }
    }

    // Anropas när objektets collider träffar ett annat objekt
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.name == "background")
        {
            OnGround = true; // Objektet är nu på marken
        }
    }

    // Anropas när objektets collider lämnar ett annat objekt
    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.name == "background")
        {
            OnGround = false; // Objektet är inte längre på marken
        }
    }

    // Anropas när ett trigger-kollisionsområde träffas
    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("I MÅL");
    }
}

