using UnityEngine;

public class ShipController : MonoBehaviour
{

    private IThruster mThruster;
    private ITurner mTurner;
    private IShooter mShooter;

    // Start is called before the first frame update
    void Start()
    {
        if(mThruster == null)
        {
            mThruster = GetComponent<IThruster>();
        }

        if(mTurner == null)
        {
            mTurner = GetComponent<ITurner>();
        }

        if(mShooter == null)
        {
            mShooter = GetComponent<IShooter>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Vertical"))
        {
            Debug.Log("Thrusting!!");
            mThruster.Thrust();
        }

        if(Input.GetButtonDown("Horizontal"))
        {
            mTurner.Turn(Input.GetAxis("Horizontal"));
        }

        if(Input.GetButton("Fire1"))
        {
            mShooter.Shoot();
        }
    }
}

public interface IThruster
{
    void Thrust();
}

public interface ITurner
{
    void Turn(float f);
}

public interface IShooter
{
    void Shoot();
}