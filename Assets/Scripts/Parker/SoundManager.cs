using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource shipSfxSource;
    public AudioSource einSfxSource;
    public AudioSource einHappySource;
    public AudioSource einGettingSadSource;
    public AudioSource einDepressedSource;

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

    public static IEnumerator EinFadeIn (AudioSource fadeInSource, AudioSource fadeOutSourceOne, AudioSource fadeOutSourceTwo, float fadeTimer)
    {
        fadeInSource.Play();
        fadeInSource.volume = 0f;
        float startVolumeOne = fadeOutSourceOne.volume;
        float startVolumeTwo = fadeOutSourceTwo.volume;
        while (fadeInSource.volume < 1)
        {
            fadeInSource.volume += Time.deltaTime / fadeTimer;

            yield return null;
        }
        while (fadeOutSourceOne.volume > 0)
        {
            fadeOutSourceOne.volume -= startVolumeOne * Time.deltaTime / fadeTimer;
            yield return null;
        }
        while (fadeOutSourceTwo.volume > 0)
        {
            fadeOutSourceTwo.volume -= startVolumeTwo * Time.deltaTime / fadeTimer;
            yield return null;
        }
    }


}
