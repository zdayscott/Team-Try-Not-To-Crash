using UnityEngine;

public class MediumThruster : MonoBehaviour, IThruster
{
    [SerializeField]
    private float acceleration = 0;
    [SerializeField]
    private float maxSpeed = 0;

    private Rigidbody2D rb;


    public void Thrust(float m)
    {
        if (maxSpeed >= rb.velocity.magnitude)
        {
            if (m < 0)
            {
                m *= 0.75f;
            }

            rb.AddForce(rb.gameObject.transform.up * acceleration * m);
        }
    }

    private void Start()
    {
        var ship = FindObjectOfType<ShipController>();
        rb = ship.GetComponent<Rigidbody2D>();
    }

    public void OnAttach()
    {
        // Do Stuff
    }
}