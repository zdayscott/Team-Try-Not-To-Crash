using UnityEngine;

public class ShipController : MonoBehaviour
{

    private IThruster mThruster;
    private ITurner mTurner;
    private IShooter mShooter;
    [SerializeField]
    private float fireRate = .5f;
    private float timeFromLastFile;
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
        timeFromLastFile += Time.deltaTime;

        if(Input.GetButton("Vertical"))
        {
            //Debug.Log("Thrusting!!");
            mThruster.Thrust(Input.GetAxis("Vertical"));
        }

        if(Input.GetButton("Horizontal"))
        {
            mTurner.Turn(-1 * Input.GetAxis("Horizontal"));
        }

        if(Input.GetButtonDown("Fire1"))
        {
            if(timeFromLastFile >= fireRate)
            {
                mShooter.Shoot();
                timeFromLastFile = 0;
            }
        }
    }

    public void SetThruster(IThruster t)
    {
        mThruster = t;
    }

    public void SetTurner(ITurner t)
    {
        mTurner = t;
    }

    public void SetShooter(IShooter s)
    {
        mShooter = s;
    }


}

public interface IThruster
{
    void Thrust(float m);

    void OnAttach();
}

public interface ITurner
{
    void Turn(float f);

    void OnAttach();
}

public interface IShooter
{
    void Shoot();
}