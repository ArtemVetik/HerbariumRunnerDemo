using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FolowingMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private MapNavigator _navigator;
    [SerializeField] private MapDestroyer _destroyer;
    [SerializeField] private BaseInputSystem _controllerSystem;

    private FolowingMove _folowingMove;
    private MapPosition _currentPosition;
    private Vector2Int _moveDirection;
    private Vector3 _startPosition;

    public event UnityAction StartMoveNext;
    public event UnityAction MoveEnded;
    public event UnityAction StopMove;
    public event UnityAction Died;

    public Vector2Int MoveDirection => _moveDirection;
    public float Distance => transform.position.z - _startPosition.z;

    private void Awake()
    {
        _folowingMove = GetComponent<FolowingMove>();
    }

    private void OnEnable()
    {
        _folowingMove.MoveEnded += OnMoveEnded;
        _controllerSystem.ChangeDirection += SetDirection;
        _controllerSystem.DoubleClicked += OnDoubleClicked;
    }

    private void OnDisable()
    {
        _folowingMove.MoveEnded -= OnMoveEnded;
        _controllerSystem.ChangeDirection -= SetDirection;
        _controllerSystem.DoubleClicked -= OnDoubleClicked;
    }

    private void OnMoveEnded()
    {
        MoveEnded?.Invoke();
        MoveNext();
    }

    public void Init(MapPosition currentPosition)
    {
        _currentPosition = currentPosition;
        _moveDirection = Vector2Int.up;

        transform.position = _navigator.ToScenePosition(_currentPosition);
        MoveNext();
    }

    private void OnDoubleClicked()
    {
        MapPosition nextPosition = _navigator.GetNextPosition(_currentPosition, _moveDirection);
        MapObject nextObject = _navigator.GetMapObject(nextPosition);
        if (nextObject is Wall)
        {
            _destroyer.DestroyWall(nextPosition);
            MoveNext();
        }
    }

    private void MoveNext()
    {
        if (_folowingMove.IsMoving)
            return;

        MapPosition nextPosition = TryGetNextPosition(_currentPosition);
        if (nextPosition.Equals(_currentPosition))
        {
            StopMove?.Invoke();
            return;
        }

        _currentPosition = nextPosition;
        Vector3 scenePosition = _navigator.ToScenePosition(_currentPosition);
        _folowingMove.Move(scenePosition);

        StartMoveNext?.Invoke();
    }

    private MapPosition TryGetNextPosition(MapPosition from)
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

    private void OnBecameInvisible()
    {
        Died?.Invoke();
    }
}
