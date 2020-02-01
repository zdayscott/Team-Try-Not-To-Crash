using UnityEngine;

public class EasyTurner : MonoBehaviour, ITurner
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
            rb = FindObjectOfType<ShipController>().GetComponent<Rigidbody2D>();
            if (rb != null)
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
