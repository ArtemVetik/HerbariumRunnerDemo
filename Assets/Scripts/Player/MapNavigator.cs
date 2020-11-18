using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNavigator : MonoBehaviour
{
    [SerializeField] private MapGenerator _generator;
    
    public MapPosition GetNextPosition(MapPosition from, Vector2Int direction)
    {
        int nextRowIndex = _generator.Map.IndexOf(from.MapRow) + direction.y;
        MapRow nextRow = _generator.Map[nextRowIndex];

        int nextRowPosition = from.RowPosition + direction.x;
        if (nextRowPosition < 0 || nextRowPosition >= nextRow.Count)
            return from;

        return new MapPosition(nextRow, nextRowPosition);
    }

    public Vector3 ToScenePosition(MapPosition position)
    {
        int index = _generator.Map.IndexOf(position.MapRow);
        return _generator.Map[index][position.RowPosition].transform.position;
    }

    public MapObject GetMapObject(MapPosition position)
    {
        int index = _generator.Map.IndexOf(position.MapRow);
        return _generator.Map[index][position.RowPosition];
    }
}
