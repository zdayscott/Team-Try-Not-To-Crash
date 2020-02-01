using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public int chance;
    public GameObject rock;
    private Rigidbody2D rb;
    private Vector3 playerPos;
    public Transform player;
    public float minDistance = 10;
    
    private float nextAst;
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
            nextAst = Random.Range(1, 4);
        }

    }

    float SpawnDistance(Vector3 playerPos, Vector3 spawnPos)
    {
        float distance;
        distance = Mathf.Sqrt(Mathf.Pow((playerPos.x - spawnPos.x), 2) + Mathf.Pow((playerPos.y - spawnPos.y), 2) + Mathf.Pow((playerPos.z - spawnPos.z), 2));
        return distance;
    }
    void CreateSmallAsteroids()
    {
        rb = rock.GetComponent<Rigidbody2D>();
      //  float distance;
        float xPos;
        float zPos;
        Vector3 rockPos;
        //this checks if asteroids is going to spawn too close to the player
       // do {
            xPos = Random.Range(-10, 10);
            zPos = Random.Range(-10, 10);
            rockPos = new Vector3(xPos, 0, zPos);            
         //   distance = SpawnDistance(playerPos, rockPos);
       // } while (distance < minDistance);

       // print("Rock spawned at " + xPos + ", 0, " + zPos);
        GameObject AsteroidClone = Instantiate(rock, rockPos, Quaternion.identity);
        float xSpeed;
        float ySpeed;
        if (xPos > 0)
        {
            xSpeed = Random.Range(-100, 0);
        }
        else
        {
            xSpeed = Random.Range(0, 100);
        }

       
        
         Random.Range(-100, 100);
        rb.AddForce(new Vector3(xSpeed, 155, 0f));
    }
}
