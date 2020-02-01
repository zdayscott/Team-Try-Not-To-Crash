using System.Collections.Generic;
using UnityEngine;

public class ShipComponentManager : MonoBehaviour
{
    [SerializeField]
    private List<IThruster> thrusters = new List<IThruster>();
    private int thrusterIndex;

    [SerializeField]
    private List<ITurner> turners = new List<ITurner>();
    private int turnerIndex;

    [SerializeField]
    private List<IShooter> shooters = new List<IShooter>();
    private int shooterIndex;

    private ShipController shipController;


    // Start is called before the first frame update
    void Start()
    {

        thrusters.AddRange(GetComponentsInChildren<IThruster>());
        
        turners.AddRange(GetComponentsInChildren<ITurner>());

        shooters.AddRange(GetComponentsInChildren<IShooter>());

        if(shipController == null)
        {
            shipController = FindObjectOfType<ShipController>();
        }

        thrusterIndex = thrusters.Count - 1;
        turnerIndex = turners.Count - 1;
        shooterIndex = shooters.Count - 1;

        shipController.SetThruster(thrusters[thrusterIndex]);
        shipController.SetTurner(turners[turnerIndex]);
        shipController.SetShooter(shooters[shooterIndex]);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RepairShip();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            HarmShip();
        }
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

    public void RepairShip()
    {
        int seed = Random.Range(0, 2);

        switch (seed)
        {
            case 0:
                if (!RepairThrusters())
                {
                    if (!RepairTurners())
                    {
                        if (!RepairShooters())
                        {

                        }
                    }
                }
                break;
            case 1:
                if (!RepairTurners())
                {
                    if (!RepairShooters())
                    {
                        if (!RepairThrusters())
                        {

                        }
                    }
                }
                break;
            case 2:
                if (!RepairShooters())
                {
                    if (!RepairThrusters())
                    {
                        if (!RepairTurners())
                        {

                        }
                    }
                }
                break;
        }
    }

    private bool DamageThrusters()
    {
        if(thrusterIndex > 0)
        {
            thrusterIndex--;
            shipController.SetThruster(thrusters[thrusterIndex]);
            thrusters[thrusterIndex].OnAttach();

            print(thrusters[thrusterIndex].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool DamageTurners()
    {
        if (turnerIndex > 0)
        {
            turnerIndex--;
            shipController.SetTurner(turners[turnerIndex]);
            turners[turnerIndex].OnAttach();
            print(turners[turnerIndex].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool DamageShooters()
    {
        if (shooterIndex > 0)
        {
            shooterIndex--;
            shipController.SetShooter(shooters[shooterIndex]);
            print(shooters[shooterIndex].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool RepairThrusters()
    {
        if (thrusterIndex < thrusters.Count - 1)
        {
            thrusterIndex++;
            shipController.SetThruster(thrusters[thrusterIndex]);
            thrusters[thrusterIndex].OnAttach();
            print(thrusters[thrusterIndex].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool RepairTurners()
    {
        if (turnerIndex < turners.Count - 1)
        {
            turnerIndex++;
            shipController.SetTurner(turners[turnerIndex]);
            turners[turnerIndex].OnAttach();
            print(turners[turnerIndex].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool RepairShooters()
    {
        if (shooterIndex < shooters.Count - 1)
        {
            shooterIndex++;
            shipController.SetShooter(shooters[shooterIndex]);
            print(shooters[shooterIndex].ToString());
            return true;
        }
        else
        {
            return false;
        }
    }
}
