    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GlobalVolume : MonoBehaviour
{ 
    private float _ownVolume;
    private float _volume;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _ownVolume = _audioSource.volume;
    }

    public void SetVolume(float globalVolume)
    {
        _audioSource.volume = globalVolume * _ownVolume;
    }
}
