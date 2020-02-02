using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float lifeTime = 2.5f;
    private float currentLife = 0;

    private void Update()
    {
        if(currentLife >= lifeTime)
        {
            Destroy(this.gameObject);
        }
        else
        {
            currentLife += Time.deltaTime;
        }
    }

}


