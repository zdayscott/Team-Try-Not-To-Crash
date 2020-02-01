using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMover : MonoBehaviour
{
    private GameObject rock;
    private float xInitForce = 1f;
    private float yInitForce = 1f;
    private float maxRotation;
    private float rotZ;
    private Rigidbody2D rb;
    private int _generation = 0;

    // Start is called before the first frame update
    void Start()
    {
        rock = this.gameObject;
        rb = rock.GetComponent<Rigidbody2D>();
        maxRotation = 25f;
        rotZ = Random.Range(-maxRotation, maxRotation);

        float speedY = Random.Range(200f, 800f);
        int selectorY = Random.Range(0, 2);

        float dirY = 0;
        if (selectorY == 1)
        {
            dirY = -1;
        }
        else
        {
            dirY = 1;
        }
        float finalSpeedY = speedY * dirY;
        float xSpeed = Random.Range(-100, 100);
        float ySpeed = Random.Range(-100, 100);
        rb.AddForce(new Vector3(1f * xSpeed, 1f * ySpeed, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        rock.transform.Rotate(new Vector3(0f, 0f, rotZ) * Time.deltaTime);
        //checkPosition();
        float dynamicMaxSpeed = 3f;
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -dynamicMaxSpeed, dynamicMaxSpeed), Mathf.Clamp(rb.velocity.y, -dynamicMaxSpeed, dynamicMaxSpeed));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.tag == "Boarder")
        {
            Destroy(this.gameObject);
        }
    }

}
