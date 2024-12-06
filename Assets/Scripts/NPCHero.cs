using UnityEngine;

public class NPCHero : MonoBehaviour
{
   GameObject[] balls;
    float Speed = 2; 
     // Aktuellt bollindex
     //Variabel ska peka på det boll som hero ska gå till härnäst. 
    //0 betyder första boll i arrayen, 1 betyder andra ball i arrayen, osv
        int currentBallIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Alla ball är taggade som balls. I detta fall läses fem balls in till en array
        //av spelobjekt
        balls = GameObject.FindGameObjectsWithTag("ball");

         //Kontrollera antalet bollar, de måste vara 5 och skriv length 5
         if (balls.Length != 5)
        {
            Debug.LogError("Bollar måste vara 5!");
        }
        else
        {
            // Välj random boll
            currentBallIndex = Random.Range(0, balls.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {

        //OM Avståndet mellan hero och balls är mindre än 0.5 ska vi uppdatera BallIndex, dvs. i praktiken
        //byta destionationen till det andra boll

        // Om hero når bollen, välj ny random boll
        if (Vector2.Distance(transform.position, balls[currentBallIndex].transform.position) < 0.5f)
        {
          // Välj random index nästa boll
            currentBallIndex = Random.Range(0, balls.Length);
        }

        //Skapar en vektor som går från hero till boll genom att subrathera
        //bolls positionsvektor med heros positionsvektor

         // Flytta mot den aktuella bollen
        Vector2 Direction = balls[currentBallIndex].transform.position - transform.position;

         //Normaliserar Direction-vektorn (längden blir nu 1, men riktningen samma som tidigare)
        Direction.Normalize();

         // Beräkna rörelsehastigheten
        //Skapar en ny vektor som definierar riktningen och hastigheten från hero till boll
        //Velocity-vektorn blir den normaliserade vektorn multiplicerat med en skalär för speed/hastighet
        Vector2 Velocity = Direction * Speed; 

        //Flytta hero
        //Till slut adderar vi Velocit vektorn med heros positionsvektor för varje frame för att få den
        //att röra sej mot boll. Vi multiplicerar med time.deltaTime för att skala ner hastigheten att motsvara
        //enhter per sekunder i stället för enheter per frame

        transform.Translate(Velocity * Time.deltaTime); 

    }

    void OnCollisionEnter2D(Collision2D collision) // Hantera kollision med Monstr
    {
        if (collision.gameObject.CompareTag("monstr"))
        {
            Debug.Log("Hero kolliderade med Monstr!");
        }
    }
}
