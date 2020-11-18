using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Container", menuName = "Object Container", order = 51)]
public class MapObjectContainer : ScriptableObject
{
    [SerializeField] private MapObject[] _mapObjects;

    public MapObject GetObject<T>()
    {
        foreach (MapObject mapObject in _mapObjects)
        {
            if (mapObject is T)
                return mapObject;
        }

        throw new InvalidOperationException();
    }
}
