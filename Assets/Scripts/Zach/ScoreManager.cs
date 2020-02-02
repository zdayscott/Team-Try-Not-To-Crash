using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;


    [SerializeField]
    private float timeElapsed = 0;
    private float nextDifficultyCheck = 20;
    [SerializeField]
    private float diffCheckStep = 15;

    private int astHit = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
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

    public void PlayerShootAst()
    {
        astHit++;
    }

    public int GetAstHit()
    {
        return astHit;
    }

    public float GetTime()
    {
        return timeElapsed;
    }


}
