using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Vector2 PushForce; // Kraft appliceras kontinuerligt för att flytta /röra sig

    public Vector2 JumpForce; // Kraft som appliceras när yumping

    Vector2 Velocity;

    Rigidbody2D PhysicsEngine;

    bool OnGround = false; //Kontrollera om Monstr är on the ground

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        //Hämtar en referens till spelobjektets Rigidbody2D-komponent
        PhysicsEngine = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Utsätter Monstr för en kontinuerlig "push-kraft" rakt till höger
        PhysicsEngine.AddForce(PushForce);

     if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            //Utsätter Monstr för en impulskraft rakt uppåt. 
            //Hoppa impuls
            PhysicsEngine.AddForce(JumpForce, ForceMode2D.Impulse);
            OnGround = false;  // Nu är Monstr i luften
        }     
    }

    //Anropas av spelmotorn när i detta fall Monstrs collider kör in i ett annat spelobjekts collid
    private void OnCollisionEnter2D(Collision2D c)
    {
        //if -satsen blir true om spelobjektet som hänger ihop med den collider vi krockat med heter "background"
        if (c.gameObject.name == "background")
        {
            OnGround = true;
        }
        //Debug.Log("Landade");
    }

    //Denna metod kallas när objektet kommer ut ur kollision
    private void OnCollisionExit2D(Collision2D c)
    {
    if (c.gameObject.name == "background")
            {
                OnGround = false;
            }
    }
    // Denna metod anropas när triggerkollideren träffas
    private void OnTriggerEnter2D(Collider2D c)
    {
         Debug.Log("I MÅL");
    }
}

