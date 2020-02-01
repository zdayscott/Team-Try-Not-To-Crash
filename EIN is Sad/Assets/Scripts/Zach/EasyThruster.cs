using UnityEngine;

public class EasyThruster : MonoBehaviour, IThruster
{
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;

    private Rigidbody2D rb;


    public void Thrust()
    {
        if(maxSpeed >= rb.velocity.magnitude)
        {
            rb.AddForce(this.gameObject.transform.up * acceleration);
        }

    }

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }
}
