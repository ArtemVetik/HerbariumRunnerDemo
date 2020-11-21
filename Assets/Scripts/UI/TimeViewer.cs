using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TimeViewer : MonoBehaviour
{
    [SerializeField] private Stopwatch _stopwatch;

    private Text _timeText;

    private void Awake()
    {
        _timeText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _stopwatch.Tick += OnStopwatchTick;
        OnStopwatchTick(_stopwatch.Seconds);
    }

    private void OnDisable()
    {
        _stopwatch.Tick -= OnStopwatchTick;
    }

    private void OnStopwatchTick(float time)
    {
        _timeText.text = string.Format("{0:0.0}", time);
    }
}
