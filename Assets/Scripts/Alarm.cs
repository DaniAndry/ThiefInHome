using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private int _minSoundValue = 0;
    private int _maxSoundValue = 1;
    private WaitForSeconds _waitSeconds = new WaitForSeconds(0.01f);
    private Coroutine _coroutine;

    public void Breaker(bool isInside)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(ChangeVolume(isInside));
    }

    private IEnumerator ChangeVolume(bool isInside)
    {
        int targetVolume;

        if (isInside)
        {
            _audioSource.volume = 0;
            _audioSource.Play();
            targetVolume = _maxSoundValue;
        }
        else
        {
            targetVolume = _minSoundValue;
        }

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime);
            yield return _waitSeconds;
        }
    }
}
