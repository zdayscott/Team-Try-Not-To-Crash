using UnityEngine;

public class MediumTurner : MonoBehaviour, ITurner
{
    private Rigidbody2D rb;
    [SerializeField]
    private float modifier = 2;
    [SerializeField]
    private float angularDrag = 1.5f;

    public void Turn(float m)
    {
        rb.AddTorque(m * modifier);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.angularDrag = angularDrag;
        }
    }
}
