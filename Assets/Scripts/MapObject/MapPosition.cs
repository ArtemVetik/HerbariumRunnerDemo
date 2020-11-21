using UnityEngine;

public struct MapPosition
{
    [SerializeField] private MapRow _row;
    [SerializeField] private int _rowPosition;

    public MapPosition(MapRow mapRow, int rowPosition)
    {
        _row = mapRow;
        _rowPosition = rowPosition;
    }

    public MapRow Row => _row;
    public int RowPosition => _rowPosition;
}
