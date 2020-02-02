using UnityEngine;

public class HardShooter : MonoBehaviour, IShooter
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform[] shootpoints;
    [SerializeField]
    private float variance;

    public void Shoot()
    {
        for (int i = 0; i < shootpoints.Length; i++)
        {
            Vector3 pos = shootpoints[i].position;
            float rand = Random.Range(-variance, variance);
            Quaternion rot = shootpoints[i].rotation * Quaternion.Euler(0,0,rand);

            Instantiate(projectile, pos, rot);
        }
    }
}
