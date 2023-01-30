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

    public void AlarmOn()
    {
        _audioSource.Play();

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(IncreaseVolume());
    }

    public void AlarmOff()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(DecreaseVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        _audioSource.volume = 0;

        while (_audioSource.volume != _maxSoundValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxSoundValue, Time.deltaTime);
            yield return _waitSeconds;
        }

        StopCoroutine(_coroutine);
    }

    private IEnumerator DecreaseVolume()
    {
        while (_audioSource.volume != _minSoundValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minSoundValue, Time.deltaTime);
            yield return _waitSeconds;
        }

        StopCoroutine(_coroutine);
        _audioSource.Stop();
    }
}
