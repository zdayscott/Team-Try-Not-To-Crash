using UnityEngine;

public class Spiner : MonoBehaviour
{
    [SerializeField]
    private float rotZ = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, rotZ) * Time.deltaTime);
    }
}
