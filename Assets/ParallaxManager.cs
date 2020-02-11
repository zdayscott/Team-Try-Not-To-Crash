using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    [SerializeField]
    private GameObject foreground;
    [SerializeField]
    private GameObject background;

    private List<GameObject> foregrounds = new List<GameObject>();
    private List<GameObject> backgrounds = new List<GameObject>();

    private float foreSpeed = .2f;


    // Start is called before the first frame update
    void Start()
    {
        GenerateParallaxLayer(foregrounds, foreground);
        GenerateParallaxLayer(backgrounds, background);
    }

    private void GenerateParallaxLayer(List<GameObject> layer, GameObject prefab)
    {
        var pos = new Vector3(2.2f, 0, 0);
        var rot = Quaternion.Euler(0, 0, 0);
        layer.Add(Instantiate(prefab, pos, rot));

        pos += Vector3.up * 8;
        layer.Add(Instantiate(prefab, pos, rot));

        pos = new Vector3(-4.2f, -1f, 0);

        layer.Add(Instantiate(prefab, pos, rot));

        pos += Vector3.up * 8;
        layer.Add(Instantiate(prefab, pos, rot));
    }

    // Update is called once per frame
    void Update()
    {
        MoveLayer(foregrounds, foreSpeed);
        MoveLayer(backgrounds, foreSpeed / 2);
    }

    private void MoveLayer(List<GameObject> layer, float speed)
    {
        foreach (GameObject f in layer)
        {
            f.transform.position -= Vector3.up * speed * Time.deltaTime;
            if (f.transform.position.y <= -8)
            {
                f.transform.position = new Vector3(f.transform.position.x, 8, 0);

            }
        }
    }
}
