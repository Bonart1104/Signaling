using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _alarm;
    private float _minVolume = 0;
    private float _maxVolume = 100;

    private void Start()
    {
        _audioSource.volume = _minVolume;    
    }

    public void TurnOn(bool isWork)
    {
        if (isWork)
        {
            TurnOn(_maxVolume);

            _audioSource.Play();
        }
        else
        {
            TurnOn(_minVolume);
        }
    }

    private void TurnOn(float volume)
    {
        if (_alarm != null)
        {
            StopCoroutine(_alarm);
        }

       _alarm = StartCoroutine(SetVolume(volume));
    }

    private IEnumerator SetVolume(float volume)
    {
        while(_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, Time.deltaTime * _duration );
            yield return null;
        }
    }
}
