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
            AddEmptyCell(nextPositions[i], 1f);

        return _row;
    }

    private List<int> GetRandomNextPositions(MapRow previousRow)
    {
        List<int> emptyPositions = previousRow.GetEmptyPositions();
        List<int> emptyCopy = new List<int>(emptyPositions);

        foreach (var item in emptyPositions)
        {
            int neighborsCount = 0;
            if (emptyCopy.Contains(item - 1))
                neighborsCount++;
            if (emptyCopy.Contains(item + 1))
                neighborsCount++;

            if (IsTrue((0.2f + neighborsCount * 0.25f)))
                emptyCopy.Remove(item);
        }

        if (emptyCopy.Count == 0)
            emptyCopy.Add(emptyPositions[Random.Range(0, emptyPositions.Count)]);

        return emptyCopy;
    }

    private void AddEmptyCell(int position, float probability)
    {
        if (IsTrue(probability))
            _row[position] = ObjectContainer.GetObject<Floor>();
        else
            return;

        if (position + 1 < _row.Count)
            AddEmptyCell(position + 1, probability * 0.5f);
        if (position - 1 >= 0)
            AddEmptyCell(position - 1, probability * 0.5f);
    }

    private bool IsTrue(float probability)
    {
        return Random.Range(0f, 1f) < probability;
    }
}
