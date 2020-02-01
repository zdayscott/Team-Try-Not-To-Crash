using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    private IThruster mThruster;
    private ITurner mTurner;
    private IShooter mShooter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Vertical"))
        {

        }
    }
}

public interface IThruster
{
    public void Thrust()
    {

    }
}

public interface ITurner
{
    public void Turn()
    {

    }

}

public interface IShooter
{
        public void Shoot()
    {
        
    }
}