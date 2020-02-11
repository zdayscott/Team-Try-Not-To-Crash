using UnityEngine;

public class EINEffectIndicator : MonoBehaviour
{
    Transform ship;

    private Vector3 startPos;
    private Vector3 startScale;
    private Vector3 endScale;
    [SerializeField]
    private float shrinkPercent = .5f;

    [SerializeField]
    private float lerpTime = .6f;
    [SerializeField]
    private float startTime = .3f;
    private float currentTime = 0f;
    private bool readyToMove = false;

    [SerializeField]
    private GameObject repairIcon;
    [SerializeField]
    private GameObject damageIcon;
    [SerializeField]
    private SpriteRenderer BG;
    [SerializeField]
    private Color repairBG;
    [SerializeField]
    private Color damageBG;

    private Vector3 startSpot;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startScale = this.transform.localScale;
        endScale = startScale * shrinkPercent;
        ship = FindObjectOfType<ShipController>().gameObject.transform;
        startSpot = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0) + this.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(readyToMove)
        {
            MoveTowardShip();
        }
        else
        {
            MoveToStartSpot();
        }
    }

    void MoveToStartSpot()
    {
        currentTime += Time.deltaTime;
        float percentComplete = currentTime / startTime;
        if(percentComplete >= 1)
        {
            readyToMove = true;
            currentTime = 0;
            startPos = this.transform.position;
            return;
        }
        else
        {
            transform.position = Vector3.Lerp(startPos, startSpot, percentComplete);
        }
    }

    void MoveTowardShip()
    {
        currentTime += Time.deltaTime;
        float percentComplete = currentTime / lerpTime;
        if (percentComplete > .97)
        {
            Destroy(this.gameObject);
        }

        transform.position = Vector3.Lerp(startPos, ship.position, percentComplete);
        transform.localScale = Vector3.Lerp(startScale, endScale, percentComplete);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ship"))
        {
            Destroy(this.gameObject);
        }
    }

    public void OnDamage()
    {
        damageIcon.SetActive(true);
        BG.color = damageBG;
    }

    public void OnRepair()
    {
        repairIcon.SetActive(true);
        BG.color = repairBG;
    }
}
