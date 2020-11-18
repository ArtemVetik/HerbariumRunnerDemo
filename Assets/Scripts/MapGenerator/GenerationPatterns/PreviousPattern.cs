using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousPattern : RowGenerationPattern
{
    private List<MapObject> _row;

    public PreviousPattern(List<MapRow> map, MapObjectContainer container)
        : base(map, container) 
    { }

    public override List<MapObject> GenerateRow(int size)
    {
        _row = new List<MapObject>(size);
        for (int i = 0; i < size; i++)
            _row.Add(ObjectContainer.GetObject<Wall>());

        MapRow lastRow = Map[Map.Count - 1];

        List<int> nextPositions = GetRandomNextPositions(lastRow);
        for (int i = 0; i < nextPositions.Count; i++)
            AddEmptyCell(nextPositions[i], (float)nextPositions.Count / lastRow.GetEmptyPositions().Count);

        return _row;
    }

    private List<int> GetRandomNextPositions(MapRow previousRow)
    {
        List<int> emptyPositions = previousRow.GetEmptyPositions();
        int removeCount = Random.Range(0, emptyPositions.Count);

        for (int i = 0; i < removeCount; i++)
            emptyPositions.RemoveAt(Random.Range(0, emptyPositions.Count));

        return emptyPositions;
    }

    private void AddEmptyCell(int position, float probability)
    {
        _row[position] = ObjectContainer.GetObject<Floor>();

        if (position + 1 < _row.Count && IsTrue(probability))
            _row[position + 1] = ObjectContainer.GetObject<Floor>();
        if (position - 1 >= 0 && IsTrue(probability))
            _row[position - 1] = ObjectContainer.GetObject<Floor>();
    }

    private bool IsTrue(float probability)
    {
        return Random.Range(0f, 1f) < probability;
    }
}
