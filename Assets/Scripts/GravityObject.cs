using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    // Gravitationskonstanten 
    [SerializeField] private float gravitationsKonstant = 0.1f;

    // Objektets massa 
    [SerializeField] private float _massa = 1f;

    // Lista över alla GravityObject-objekt i scenen
    public List<GravityObject> gravityObjects = new List<GravityObject>(); //Viktoriia Mikhailova bytat public List

    // Rigidbody-komponent för att hantera rörelse
    private Rigidbody2D Rigidbody2D; // Viktoriia Mikhailova: I changed - big "R"

    void Start()
    {
        // Hämta Rigidbody2D-komponenten
        Rigidbody2D = GetComponent<Rigidbody2D>();

        if (Rigidbody2D == null)
        {
            Debug.LogError("Rigidbody2D saknas på " + gameObject.name);
        }
    }

    void OnEnable()
    {
        // Lägg till objektet i listan när det aktiveras
        gravityObjects.Add(this);
    }

    void OnDisable()
    {
        // Ta bort objektet från listan när det inaktiveras
        gravityObjects.Remove(this);
    }

    void FixedUpdate()
    {
        // Applicera gravitationskraft från andra objekt
        foreach (var annatObjekt in gravityObjects)
        {
            if (annatObjekt != this)
            {
                AppliceraGravitationskraft(annatObjekt);
            }
        }
    }

    private void AppliceraGravitationskraft(GravityObject annatObjekt)
    {
        // Beräkna avståndsvektorn mellan objekten
        Vector2 riktning = annatObjekt.transform.position - transform.position;

        // Beräkna avståndets storlek
        float avstånd = riktning.magnitude;

        // Undvik division med 0
        if (avstånd == 0)
        {
            return;
        }

        // Normalisera riktningen
        riktning.Normalize();

        // Beräkna gravitationskraftens storlek med Newtons gravitationslag
        float kraft = gravitationsKonstant * (_massa * annatObjekt.massa) / (avstånd * avstånd);

        // Applicera kraften på objektets Rigidbody
        Vector2 gravitationsKraft = riktning * kraft;
        Rigidbody2D.AddForce(gravitationsKraft);
    }

    // Publik egenskap för att justera massan i andra skript
    public float massa
    {
        get { return _massa; }
        set { _massa = value; }
    }
}
