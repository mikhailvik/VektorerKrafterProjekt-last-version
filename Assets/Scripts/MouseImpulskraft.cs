using UnityEngine;

public class MouseImpulskraft : MonoBehaviour
{
    private Vector2 mouseDownPosition;

    private bool mousePressed = false;

    private Rigidbody2D rigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
   {
         //Hämtar en referens till spelobjektets Rigidbody2D-komponent
        rigidBody = GetComponent<Rigidbody2D>();
    }       

    // Update anropas en gång per frame
    void Update()
    { 
        //När museknappen är nedtryckt, gå till startpositionen /track the initial position
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Lagra muse-positionen i världskoordinater
            mousePressed = true;
        }
         // Medan musknappen hålls nedtryckt, beräkna kraftvektorn
        if (mousePressed)
        {
            Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Lagra muse-positionen i världskoordinater
            Vector2 direction = currentMousePosition - mouseDownPosition; //Vektor från startpositionen till den aktuella
            float distance = direction.magnitude; //Avstånd bestämmer storleken på kraften

            //Mata ut kraften och corner i Debug log
            float corner = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Beräkna corner i grader
            Debug.Log("Force: " + distance + " Н, Corner: " + corner + "°");
        }

        // När musknappen släpps, applicera impuls
        if (Input.GetMouseButtonUp(0) && mousePressed)
        {
            Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = currentMousePosition - mouseDownPosition;
            float distance = direction.magnitude;
            float amountOfForce = distance * 10f; //Skala styrkan (kan justera efter behov)

            rigidBody.AddForce(direction.normalized * amountOfForce, ForceMode2D.Impulse); //Applicera impulskraft

            mousePressed = false; // Återställ dragtillståndet
        }
    }
}





