using UnityEngine;

public class ShipPickup : MonoBehaviour
{
    [SerializeField]
    Transform target;

    private Vector3 startPos;
    private Vector3 startScale;
    private Vector3 endScale;
    [SerializeField]
    private float shrinkPercent = .5f;

    [Header("Animation timers")]
    [SerializeField]
    private float lerpTime = .6f;
    [SerializeField]
    private float lifeTime = 7f;
    private float currentTime = 0f;
    private float LifeTime = 0f;
    private bool readyToMove = false;

    [Header("Art Assets")]
    [SerializeField]
    private SpriteRenderer BG;
    [SerializeField]
    private SpriteRenderer icon;
    [SerializeField]
    private Color repairBG;
    [SerializeField]
    private Color damageBG;

    private Vector3 startSpot;

    bool fading = true;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startScale = this.transform.localScale;
        endScale = startScale * shrinkPercent;
        startSpot = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0) + this.transform.position;
        if (target == null)
        {
            target = FindObjectOfType<EINColider>().gameObject.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (readyToMove)
        {
            MoveTowardTarget();
        }
        LifeTime += Time.deltaTime;

        if(LifeTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
        else if(fading)
        {
            BG.color = new Color(BG.color.r, BG.color.g, BG.color.b, 1 - LifeTime / lifeTime);
            icon.color = new Color(icon.color.r, icon.color.g, icon.color.b, 1 - LifeTime / lifeTime);
        }
    }

    void MoveTowardTarget()
    {
        currentTime += Time.deltaTime;
        float percentComplete = currentTime / lerpTime;
        if (percentComplete > .97)
        {
            print("Make EIN happier!");
            FindObjectOfType<EINmanager>().MakeHappier();
            Destroy(this.gameObject);
        }

        transform.position = Vector3.Lerp(startPos, target.position, percentComplete);
        transform.localScale = Vector3.Lerp(startScale, endScale, percentComplete);

        fading = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Colliding");
        if (collision.gameObject.CompareTag("EIN"))
        {
            print("Make EIN happier!");
            FindObjectOfType<EINmanager>().MakeHappier();
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Ship")
        {
            //print("coliding with ship");
            readyToMove = true;
            //GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
}
