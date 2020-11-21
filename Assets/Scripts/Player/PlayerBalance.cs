using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerBalance : MonoBehaviour
{
    [SerializeField] private GameBalance _balance;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

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
        _balance.AddBalance((int)_player.Distance);
    }
}
