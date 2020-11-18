using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MapPosition
{
    [SerializeField] private MapRow _mapRow;
    [SerializeField] private int _rowPosition;

    public MapPosition(MapRow mapRow, int rowPosition)
    {
        _mapRow = mapRow;
        _rowPosition = rowPosition;
    }

    public MapRow MapRow => _mapRow;
    public int RowPosition => _rowPosition;
}
