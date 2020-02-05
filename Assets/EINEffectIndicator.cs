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
    private float currentTime = 0f;
    private bool readyToMove = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startScale = this.transform.localScale;
        endScale = startScale * shrinkPercent;
        ship = FindObjectOfType<ShipController>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToMove)
        {
            MoveTowardShip();
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
}
