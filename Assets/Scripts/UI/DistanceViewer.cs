using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DistanceViewer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private string _unit;

    private Text _distanceText;

    private void Awake()
    {
        _distanceText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _player.MoveEnded += OnPlayerMoveEnded;
        OnPlayerMoveEnded();
    }

    private void OnDisable()
    {
        _player.MoveEnded -= OnPlayerMoveEnded;
    }

    private void OnPlayerMoveEnded()
    {
        _distanceText.text = _player.Distance.ToString() + _unit;
    }
}
