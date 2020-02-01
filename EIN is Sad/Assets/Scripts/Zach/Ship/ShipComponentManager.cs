using UnityEngine;

public class ShipComponentManager : MonoBehaviour
{
    [SerializeField]
    private IThruster[] thrusters;
    private int thrusterIndex;
    [SerializeField]
    private ITurner[] turners;
    private int turnerIndex;
    [SerializeField]
    private IShooter[] shooters;
    private int shooterIndex;

    private ShipController shipController;


    // Start is called before the first frame update
    void Start()
    {
        if(thrusters.Length <= 0)
        {
            thrusters = GetComponents<IThruster>();
        }

        if(turners.Length <= 0)
        {
            turners = GetComponents<ITurner>();

        }

        if(shooters.Length <= 0)
        {
            shooters = GetComponents<IShooter>();
        }

        if(shipController == null)
        {
            shipController = FindObjectOfType<ShipController>();
        }

        thrusterIndex = thrusters.Length;
        turnerIndex = turners.Length;
        shooterIndex = shooters.Length;
    }

    public void HarmShip()
    {
        int seed = Random.Range(0, 2);

        switch(seed)
        {
            case 0:
                if(!DamageThrusters())
                {
                    if(!DamageTurners())
                    {
                        if(!DamageShooters())
                        {

                        }
                    }
                }
                break;
            case 1:
                if(!DamageTurners())
                {
                    if(!DamageShooters())
                    {
                        if(!DamageThrusters())
                        {

                        }
                    }
                }
                break;
            case 2:
                if(!DamageShooters())
                {
                    if(!DamageThrusters())
                    {
                        if(!DamageTurners())
                        {

                        }
                    }
                }
                break;
        }
    }

    private bool DamageThrusters()
    {
        if(thrusterIndex >= 0)
        {
            thrusterIndex--;
            shipController.SetThruster(thrusters[thrusterIndex]);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool DamageTurners()
    {
        if (turnerIndex >= 0)
        {
            turnerIndex--;
            shipController.SetTurner(turners[turnerIndex]);
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool DamageShooters()
    {
        if (shooterIndex >= 0)
        {
            shooterIndex--;
            shipController.SetShooter(shooters[shooterIndex]);
            return true;
        }
        else
        {
            return false;
        }
    }
}
