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
    
    private float _startVolume = 0.1f;
    private float _stepVolume = 0.01f;

    private string _enableParameterName = "isEnable";

    private void Start()
    {
        _animator = GetComponent<Animator>();   
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = _startVolume;
    }

    private void Update()
    {
        if (_inZone == true)
        {
            if(_audioSource.isPlaying == false) {
                _audioSource.Play();
                _animator.SetTrigger(_enableParameterName);
            }
            else
            {
                _audioSource.volume += _stepVolume;
            }
        }
        else
        {
            if (_audioSource.isPlaying == true && _audioSource.volume > 0.1f)
            {
                _audioSource.volume -= _stepVolume;
            }
            else
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
