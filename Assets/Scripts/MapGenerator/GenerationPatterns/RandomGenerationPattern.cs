using System.Collections.Generic;
using UnityEngine;

public class RandomGenerationPattern : RowGenerationPattern
{
    private int _emptyCount;

    public RandomGenerationPattern(List<MapRow> map, int emptyCount, MapObjectContainer container)
        : base(map, container)
    {
        _emptyCount = emptyCount;
    }

    public override List<MapObject> GenerateRow(int size)
    {
        List<MapObject> row = new List<MapObject>(size);
        List<int> emptyIndexes = new List<int>();

        for (int index = 0; index < size; index++)
        {
            row.Add(ObjectContainer.GetObject<Wall>());
            emptyIndexes.Add(index);
        }

        for (int i = 0; i < size - _emptyCount; i++)
            emptyIndexes.RemoveAt(Random.Range(0, emptyIndexes.Count));

        foreach (int index in emptyIndexes)
            row[index] = ObjectContainer.GetObject<Floor>();

        return row;
    }
}
