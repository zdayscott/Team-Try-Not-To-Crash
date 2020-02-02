using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float timeElapsed = 0;
    private float nextDifficultyCheck = 20;
    [SerializeField]
    private float diffCheckStep = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > nextDifficultyCheck)
        {
            GetComponent<AstroidSpawner>().DifficultyUp();
            nextDifficultyCheck += diffCheckStep;
        }
    }
}
