using UnityEngine;

public class EasyShooter : MonoBehaviour, IShooter
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform[] shootpoints;

    public void Shoot()
    {
        for (int i = 0; i < shootpoints.Length; i++)
        {
            Instantiate(projectile, shootpoints[i]);
        }
    }
}
