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
    public AudioSource einPulse;
    public AudioSource menuMusic;
    public AudioClip robotIntro;


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
    public void PlayEinRandomSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randoPitch = Random.Range(lowPitchRando, highPitchRando);

        einSfxSource.pitch = randoPitch;
        einSfxSource.clip = clips[randomIndex];
        einSfxSource.Play();



    }

    public static IEnumerator EinFadeIn (AudioSource fadeInSource, AudioSource fadeOutSourceOne, AudioSource fadeOutSourceTwo, float fadeTimer)
    {

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
    public static IEnumerator EinFadeOut(AudioSource fadeInSource, AudioSource fadeOutSourceOne, AudioSource fadeOutSourceTwo, float fadeTimer)
    {


        float startVolumeOne = fadeOutSourceOne.volume;
        float startVolumeTwo = fadeOutSourceTwo.volume;
        float startVolumeThree = fadeInSource.volume;
        while (fadeInSource.volume > 1)
        {
            fadeInSource.volume -= startVolumeThree * Time.deltaTime / fadeTimer;

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

    public void EinIsDead()
    {

        StartCoroutine(EinFadeOut(einHappySource, einGettingSadSource, einDepressedSource, 0.2f));

    }
    public void EinIsHappySfx()
    {

        StartCoroutine(EinFadeIn(einHappySource, einGettingSadSource, einDepressedSource, 0.2f));

    }
    public void EinIsSadSfx()
    {

        StartCoroutine(EinFadeIn(einGettingSadSource, einHappySource, einDepressedSource, 0.2f));

    }
    public void EinIsDepressedSfx()
    {

        StartCoroutine(EinFadeIn(einDepressedSource, einGettingSadSource, einHappySource, 0.2f));

    }

    public static IEnumerator MusicFadeIn (AudioSource MusicSource, float musicfader)
    {
       

        while (MusicSource.volume < 1)
        {
            MusicSource.volume += Time.deltaTime / musicfader;

            yield return null;
        }

    }
    public void MusicStart()
    {
       

        StartCoroutine(MusicFadeIn(menuMusic, 0.2f));

    }
    public static IEnumerator MusicFadeOut(AudioSource MusicSource, float fader)
    {
        float startVolumeOne = MusicSource.volume;
        while (MusicSource.volume > 0)
        {
            MusicSource.volume -= startVolumeOne * Time.deltaTime / fader;
            yield return null;
        }
        yield return null;
    }
    public void MusicStop()
    {

        StartCoroutine(MusicFadeOut(menuMusic, 1.0f));

    }
    public void EinPulseStart()
    {

        StartCoroutine(MusicFadeIn(einPulse, 1.0f));

    }
    public void EinPulseStop()
    {

        StartCoroutine(MusicFadeOut(einPulse, 1.0f));

    }




}
