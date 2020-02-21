using UnityEngine;


public class AstroidMover : MonoBehaviour
{
    private GameObject rock;
    private GameObject healthBar;
    private float xInitForce = 1f;
    private float yInitForce = 1f;
    private float maxRotation;
    private float rotZ;
    private Rigidbody2D rb;
    private int _generation = 0;

    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private GameObject Explosion;
    [SerializeField]
    private GameObject[] ShipPickups;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("Health");
        
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
        float xSpeed = Random.Range(10, 100);
        float ySpeed = Random.Range(-100, 100);
        //rb.AddForce(transform.forward * xSpeed);
        

        GetComponentInChildren<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)];

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * Random.Range(30,100));
    }

    // Update is called once per frame
    void Update()
    {
        rock.transform.Rotate(new Vector3(0f, 0f, rotZ) * Time.deltaTime);
        //float dynamicMaxSpeed = 3f;
        //rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -dynamicMaxSpeed, dynamicMaxSpeed), Mathf.Clamp(rb.velocity.y, -dynamicMaxSpeed, dynamicMaxSpeed));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Boarder")
        {
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Projectile")
        {
            if (this.transform.localScale.x <= 1)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                ScoreManager.instance.PlayerShootAst();
                Explode();
            }
            else
            {
                Split();
            }
        }
        if (collision.tag == "Ship")
        {            
            healthBar.GetComponent<Healthbar>().changeHealth(-1);
            collision.gameObject.GetComponent<ShipController>().OnDamageTaken();
            
            Destroy(this.gameObject);
        }
    }

    private void Explode()
    {
        var pos = transform.position;
        var rot = transform.rotation;
        Instantiate(Explosion, pos, rot);
        var seed = Random.Range(1, 100);
        if (seed > 35)
        {
            Instantiate(ShipPickups[Random.Range(0, ShipPickups.Length - 1)], pos, rot);
        }
    }

    private void Split()
    {
        Vector3 newSize = new Vector3(this.transform.localScale.x / 2, this.transform.localScale.y / 2, 1);
        rock.transform.localScale = newSize;

        Vector3 spawnPos = this.transform.localPosition;
        for (int x = 0; x < 2; x++)
        {
            GameObject AsteroidClone = Instantiate(rock, spawnPos, Quaternion.Euler(0,0,Random.Range(0,359)));
            //rb.AddForce(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0f));
        }
    }

}
