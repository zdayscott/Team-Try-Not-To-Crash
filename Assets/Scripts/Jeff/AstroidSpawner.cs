using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    //public int chance;
    public GameObject rock;
    private Rigidbody2D rb;
    private Vector3 playerPos;
    public Transform player;
    public float minDistance = 10;
    public float size;

    [SerializeField]
    private float minSpawnTime = 2.5f;
    [SerializeField]
    private float maxSpawnTime = 5;
    [SerializeField]
    private float velocityScaler = 0.2f;

    [SerializeField]
    private float[] min = {2.5f, 2, 1.5f, 1.2f, 1, 0.5f};
    [SerializeField]
    private float[] max = {5, 4, 3.75f, 3, 2.5f, 2};
    private int currentDifficultyIndex = 0;

    private float nextAst;

    [SerializeField]
    private float spawnRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.position;
        nextAst = Random.Range(0, 2);
        CreateSmallAsteroids();
    }

   

    // Update is called once per frame
    void Update()
    {
        nextAst -= Time.deltaTime;
        if(nextAst < Time.deltaTime)
        {
            CreateSmallAsteroids();
            nextAst = Random.Range(min[currentDifficultyIndex], max[currentDifficultyIndex]);
        }
    }

    float SpawnDistance(Vector3 playerPos, Vector3 spawnPos)
    {
        float distance;
        distance = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((playerPos.x - spawnPos.x), 2) + Mathf.Pow((playerPos.y - spawnPos.y), 2) + Mathf.Pow((playerPos.z - spawnPos.z), 2)));
        return distance;
    }
    void CreateSmallAsteroids()
    {
        rb = rock.GetComponent<Rigidbody2D>();
        float distance;
        float xPos;
        float yPos;
        Vector3 rockPos;

        print(player.position);

        //this checks if asteroids is going to spawn too close to the player
        do {
            xPos = Random.Range(-spawnRange, spawnRange);
            yPos = Random.Range(-spawnRange, spawnRange);
            rockPos = new Vector3(xPos, yPos, 0);
            distance = SpawnDistance(player.position, rockPos);
        } while (distance < minDistance);

        //This determines max size of the asteroids
        float scaler = Random.Range(1, 4);
        Vector3 randomScale = new Vector3(scaler, scaler, 1);
        rock.transform.localScale = randomScale;

        GameObject AsteroidClone = Instantiate(rock, rockPos, Quaternion.identity);
        float xSpeed;
        //float ySpeed;

        if (xPos > 0)
        {
            xSpeed = Random.Range(-100, 0);
        }
        else
        {
            xSpeed = Random.Range(0, 100);
        }

        
         Random.Range(-100, 100);
         rb.AddForce(new Vector3(xSpeed * (1 + velocityScaler), 155 * (1 + velocityScaler), 0f));
    }

    public void DifficultyUp()
    {
        if(currentDifficultyIndex < 5)
        {
            currentDifficultyIndex++;
        }

        velocityScaler *= 2;
    }
}
