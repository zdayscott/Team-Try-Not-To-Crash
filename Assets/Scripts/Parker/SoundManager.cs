using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource shipSfxSource;
    public AudioSource einSfxSource;

    public static SoundManager instance = null;

    public float lowPitchRando = .90f;
    public float highPitchRando = 1.05f;
    // Start is called before the first frame update
    void Awake()
   
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySfx (AudioClip clip)
    {
        shipSfxSource.clip = clip;
        shipSfxSource.Play ();


    }

    public void PlayRandomSfx (params AudioClip [] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randoPitch = Random.Range(lowPitchRando, highPitchRando);

        shipSfxSource.pitch = randoPitch;
        shipSfxSource.clip = clips[randomIndex];
        shipSfxSource.Play();



    }


}
