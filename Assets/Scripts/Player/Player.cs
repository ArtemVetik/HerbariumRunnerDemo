using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FolowingMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private MapNavigator _navigator;
    [SerializeField] private BaseInputSystem _controllerSystem;

    private FolowingMove _folowingMove;
    private MapPosition _currentPosition;
    private Vector2Int _moveDirection;

    public event UnityAction<Vector2Int> StartMoveNext;
    public event UnityAction StopMove;

    private void Awake()
    {
        _folowingMove = GetComponent<FolowingMove>();
    }

    private void OnEnable()
    {
        _folowingMove.MoveEnded += OnMoveEnded;
        _controllerSystem.ChangeDirection += SetDirection;
    }

    private void OnDisable()
    {
        _folowingMove.MoveEnded -= OnMoveEnded;
        _controllerSystem.ChangeDirection -= SetDirection;
    }

    private void OnMoveEnded()
    {
        MoveNext();
    }

    public void Init(MapPosition currentPosition)
    {
        _currentPosition = currentPosition;
        _moveDirection = Vector2Int.up;

        transform.position = _navigator.ToScenePosition(_currentPosition);
        MoveNext();
    }

    private void MoveNext()
    {
        MapPosition nextPosition = GetNextPosition(_currentPosition);
        if (nextPosition.Equals(_currentPosition))
        {
            StopMove?.Invoke();
            return;
        }

        _currentPosition = nextPosition;
        Vector3 scenePosition = _navigator.ToScenePosition(_currentPosition);
        _folowingMove.Move(scenePosition);

        StartMoveNext?.Invoke(_moveDirection);
    }

    private MapPosition GetNextPosition(MapPosition from)
    {
        MapPosition nextPosition = _navigator.GetNextPosition(from, _moveDirection);

        if (_navigator.GetMapObject(nextPosition) is Floor)
            return nextPosition;
        
        nextPosition = _navigator.GetNextPosition(from, Vector2Int.up);
        if (_navigator.GetMapObject(nextPosition) is Floor)
            return nextPosition;

        return from;
    }

    public void SetDirection(Vector2Int direction)
    {
        _moveDirection = direction;

        if (_folowingMove.IsMoving == false)
            MoveNext();
    }
}
