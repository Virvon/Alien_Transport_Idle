using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class GlobalVolumeScrollbar : MonoBehaviour
{
    [SerializeField] private GlobalVolume[] _audioSourses;

    private Scrollbar _scrollbar;

    private void Start()
    {
        _scrollbar = GetComponent<Scrollbar>();
    }

    public void ChangeValue()
    {
        foreach (var audiosourse in _audioSourses)
            audiosourse.SetVolume(_scrollbar.value);
    }
}
