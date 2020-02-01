using UnityEngine;

public class TestThruster : MonoBehaviour, IThruster
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

            rb.AddForce(this.gameObject.transform.up * acceleration * m);
        }
    }

    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnAttach()
    {
        throw new System.NotImplementedException();
    }
}