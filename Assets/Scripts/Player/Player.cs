﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FolowingMove))]
public class Player : MonoBehaviour
{
    [SerializeField] private MapNavigator _navigator;
    [SerializeField] private BaseInputSystem _controllerSystem;

    private FolowingMove _folowingMove;
    private MapPosition _currentPosition;
    private Vector2Int _moveDirection;

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
            return;

        _currentPosition = nextPosition;
        Vector3 scenePosition = _navigator.ToScenePosition(_currentPosition);
        _folowingMove.Move(scenePosition);
    }

    private MapPosition GetNextPosition(MapPosition from)
    {
        MapPosition nextPosition = _navigator.GetNextPosition(from, _moveDirection);

        if (_navigator.Is<Floor>(nextPosition))
            return nextPosition;
        
        nextPosition = _navigator.GetNextPosition(from, Vector2Int.up);
        if (_navigator.Is<Floor>(nextPosition))
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
