using UnityEngine;

public class Friction : MonoBehaviour
{
    public float StaticFriction; // Maximal statisk friktion
    public float KineticFriction; // Friktion under rörelse

    Rigidbody2D physics;

    Vector2 FrictionForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        FrictionForce = new Vector2(0, 0);
    }

    // Update is called once per frame
    public void ApplyForce(Vector2 Force)
    {
        float Fmax = StaticFriction * physics.mass * 9.82f;
        Debug.Log(physics.linearVelocity);
        
        if(Force.magnitude < Fmax && physics.linearVelocity.magnitude < 0.1f)
        {
            FrictionForce.x = -Force.x;
        

        physics.linearVelocity = new Vector2(0, 0);
        }
        if (physics.linearVelocity.magnitude >= 0.1f)
        {
            FrictionForce.x = physics.mass * 9.82f * KineticFriction;
            
            if (physics.linearVelocity.x > 0)
            FrictionForce.x *= -1;
        }
           
        
        //beräkna friktionen

        Vector2 ResultingForce = FrictionForce + Force;

        physics.AddForce(ResultingForce);
    }
}