using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private Animator _animator;
    private Player _player;
    private float _targetYrotation;

    private const string RunKey = "run";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
    }

    private void OnEnable()
    {
        _player.StartMoveNext += OnStartMoveNext;
        _player.StopMove += OnStopMovement;
    }

    private void OnStopMovement()
    {
        _animator.SetBool(RunKey, false);
    }

    private void OnStartMoveNext()
    {
        _animator.SetBool(RunKey, true);
    }

    private void Update()
    {
        _targetYrotation = 90 * _player.MoveDirection.x;
        float playerRotation = _player.transform.eulerAngles.y;
        playerRotation = (playerRotation > 180) ? playerRotation - 360 : playerRotation;
        float y = Mathf.MoveTowards(playerRotation, _targetYrotation, _rotationSpeed * Time.deltaTime);

        _player.transform.rotation = Quaternion.Euler(0, y, 0);
    }

    private void OnDisable()
    {
        _player.StartMoveNext -= OnStartMoveNext;
        _player.StopMove -= OnStopMovement;
    }
}
