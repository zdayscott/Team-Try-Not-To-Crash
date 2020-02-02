using UnityEngine;

public class ShipController : MonoBehaviour
{

    private IThruster mThruster;
    private ITurner mTurner;
    private IShooter mShooter;

    [SerializeField]
    private float fireRate = .5f;
    private float timeFromLastFile;


    public AudioClip shootSfx1;
    public AudioClip shootSfx2;
    public AudioClip shootSfx3;
    public AudioClip shootSfx4;
    public AudioClip shootSfx5;
    public AudioClip shootSfx6;
    public AudioClip shootSfx7;

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

                if(shootSfx1 && shootSfx2 && shootSfx3 && shootSfx4 && shootSfx5 && shootSfx6 && shootSfx7)
                {
                    SoundManager.instance.PlayRandomSfx(shootSfx1, shootSfx2, shootSfx3, shootSfx4, shootSfx5, shootSfx6, shootSfx7);
                }

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