using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AnimationDone()
    {
        Destroy(transform.parent.gameObject);
    }

}