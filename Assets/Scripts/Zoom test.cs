using UnityEngine;

public class Zoom : MonoBehaviour
{
    Camera Camera;

    public float ZoomSpeed;
    
	// Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            Camera.orthographicSize-=ZoomSpeed;
        }

        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            Camera.orthographicSize+=ZoomSpeed;
        }
    }
}
