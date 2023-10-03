using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    
    private bool _inZone = false;
    
    private float _minVolume = 0.05f;
    private float _maxVolume = 1f;
    private float _stepVolume = 0.1f;

    private string _enableParameterName = "isEnable";

    private void Start()
    {
        _animator = GetComponent<Animator>();   
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _minVolume;
    }

    private void Update()
    {
        if (_inZone == true)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maxVolume, _stepVolume * Time.deltaTime);

            if(_audioSource.isPlaying == false && _audioSource.volume > _minVolume)
            {
                _audioSource.Play();
                _animator.SetTrigger(_enableParameterName);
            }  
        }
        else
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minVolume, _stepVolume * Time.deltaTime);

            if (_audioSource.isPlaying == true && _audioSource.volume <= _minVolume)
            {
                _audioSource.Stop();
                _animator.ResetTrigger(_enableParameterName);
            }
        }
    }

    public void Enable()
    {
        _inZone = true;
    }

    public void Disable()
    {
        _inZone = false;
    }
}
