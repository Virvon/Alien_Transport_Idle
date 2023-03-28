using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSourse : SoundPlayer
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.MoneySpent += PlaySound;
    }

    private void OnDisable()
    {
        _player.MoneySpent -= PlaySound;
    }
}
