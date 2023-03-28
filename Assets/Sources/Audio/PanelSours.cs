using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Menu))]
[RequireComponent(typeof(GlobalVolume))]
public class PanelSours : MonoBehaviour
{
    private Menu _menu;

    private AudioSource _audioSource;

    private void OnEnable()
    {
        _menu = GetComponent<Menu>();
        _audioSource = GetComponent<AudioSource>();

        _menu.Clicked += PlaySound;
    }

    private void OnDisable()
    {
        _menu.Clicked -= PlaySound;
    }

    private void PlaySound(bool isLock)
    {
        _audioSource.Play();
    }
}
