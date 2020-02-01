using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rb;

    public void MoveProjectile(Transform p)
    {
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = this.transform.up * speed;
    }
}
