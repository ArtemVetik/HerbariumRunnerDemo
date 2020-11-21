using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGameTrigger : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private CameraTranslate _cameraTranslate;
    [SerializeField] private GameObject _endOfGamePanel;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _stopwatch.enabled = false;
        _cameraTranslate.enabled = false;
        _endOfGamePanel.SetActive(true);
    }
}
