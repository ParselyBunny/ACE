using JTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Current;
    public AudioSource MusicSource;
    IEnumerator _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        Current = this;

        MusicSource = GetComponent<AudioSource>();
        MusicSource.volume = 0.0f;
        MusicSource.Play();

        _coroutine = ThemeFadeIn(0.075f);
        StartCoroutine(_coroutine);
    }

    private IEnumerator ThemeFadeIn(float waitTime)
    {
        while (MusicSource.volume < 1.0f)
        {
            yield return new WaitForSeconds(waitTime);
            MusicSource.volume += 0.005f;
        }
    }
}
