using UnityEngine;

public class HardTurner : MonoBehaviour, ITurner
{
    private Rigidbody2D rb;
    [SerializeField]
    private float modifier = 2;
    [SerializeField]
    private float angularDrag = 1.5f;
    [SerializeField]
    private float maxAngularVelocity = 3;

    public void Turn(float m)
    {
        if (Mathf.Abs(rb.angularVelocity) < maxAngularVelocity)
        {
            rb.AddTorque(m * modifier);
        }
        else
        {
            rb.angularVelocity = maxAngularVelocity * (rb.angularVelocity/Mathf.Abs(rb.angularVelocity));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = FindObjectOfType<ShipController>().GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.angularDrag = angularDrag;
            }
        }
    }

    public void OnAttach()
    {
        if (rb != null)
        {
            rb.angularDrag = angularDrag;
        }
    }
}
