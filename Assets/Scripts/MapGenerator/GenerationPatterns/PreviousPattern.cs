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
            AddEmptyCell(nextPositions[i]);

        return _row;
    }

    private List<int> GetRandomNextPositions(MapRow previousRow)
    {
        List<int> emptyPositions = previousRow.GetEmptyPositions();
        List<int> emptyCopy = new List<int>(emptyPositions);

        int firstPath = emptyPositions[Random.Range(0, emptyPositions.Count / 2)];
        int secondPath = emptyPositions[Random.Range(emptyPositions.Count / 2, emptyPositions.Count)];

        if (IsTrue(0.05f))
        {
            if (IsTrue(0.5f))
                firstPath = secondPath;
            else
                secondPath = firstPath;
        }

        foreach (var item in emptyPositions)
        {
            int neighborsCount = 0;
            if (emptyCopy.Contains(item - 1))
                neighborsCount++;
            if (emptyCopy.Contains(item + 1))
                neighborsCount++;

            if (IsTrue((0.4f + neighborsCount * 0.2f)))
                emptyCopy.Remove(item);
        }

        if (emptyCopy.Contains(firstPath) == false)
            emptyCopy.Add(firstPath);
        if (emptyCopy.Contains(secondPath) == false)
            emptyCopy.Add(secondPath);

        return emptyCopy;
    }

    private void AddEmptyCell(int position)
    {
        _row[position] = ObjectContainer.GetObject<Floor>();

        if (position + 1 < _row.Count && IsTrue(0.4f))
            _row[position + 1] = ObjectContainer.GetObject<Floor>();
        if (position - 1 >= 0 && IsTrue(0.4f))
            _row[position - 1] = ObjectContainer.GetObject<Floor>();
    }

    private bool IsTrue(float probability)
    {
        return Random.Range(0f, 1f) < probability;
    }
}
