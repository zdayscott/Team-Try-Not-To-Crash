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
            Vector3 pos = shootpoints[i].position;
            Quaternion rot = shootpoints[i].rotation;

            Instantiate(projectile, pos, rot);
        }
    }
}
