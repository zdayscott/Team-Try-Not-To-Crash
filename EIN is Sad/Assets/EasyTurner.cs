using UnityEngine;

public class EasyTurner : MonoBehaviour, ITurner
{
    private Rigidbody2D rb;

    public void Turn(float m)
    {
        rb.AddTorque(m); 
    }

    // Start is called before the first frame update
    void Start()
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }
}
