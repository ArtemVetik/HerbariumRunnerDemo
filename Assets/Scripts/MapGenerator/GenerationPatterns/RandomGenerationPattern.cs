using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerationPattern : RowGenerationPattern
{

    public RandomGenerationPattern(List<MapRow> map, MapObjectContainer container)
        : base(map, container)
    {
    }

    public override List<MapObject> GenerateRow(int size)
    {
        List<MapObject> row = new List<MapObject>(size);
        for (int i = 0; i < size; i++)
            row.Add(ObjectContainer.GetObject<Wall>());

        int randomIndex = Random.Range(0, size);
        row[randomIndex] = ObjectContainer.GetObject<Floor>();

        return row;
    }
}
