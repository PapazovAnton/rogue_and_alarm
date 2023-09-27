using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private Animator _animator;
    private AudioSource _audioSource;
    private bool inZone = false;
    private float startVolume = 0.1f;
    private float stepVolume = 0.01f;

    private void Start()
    {
        _animator = GetComponent<Animator>();   
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = startVolume;
    }

    private void Update()
    {
        if (inZone == true)
        {
            if(_audioSource.isPlaying == false) {
                _audioSource.Play();
                _animator.SetTrigger("isEnable");
            }
            else
            {
                _audioSource.volume += stepVolume;
            }
        }
        else
        {
            if (_audioSource.isPlaying == true && _audioSource.volume > 0.1f)
            {
                _audioSource.volume -= stepVolume;
            }
            else
            {
                _audioSource.Stop();
                _animator.ResetTrigger("isEnable");
            }
        }        
    }

    public void Enable()
    {
        inZone = true;
    }

    public void Disable()
    {
        inZone = false;
    }
}
