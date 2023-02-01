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
    private int _targetVolume;

    public void Control(bool isInside)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        if (isInside)
        {
            _audioSource.volume = 0;
            _audioSource.Play();
            _targetVolume = _maxSoundValue;
        }
        else
        {
            _targetVolume = _minSoundValue;
        }

        _coroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, Time.deltaTime);
            yield return _waitSeconds;
        }
    }
}
