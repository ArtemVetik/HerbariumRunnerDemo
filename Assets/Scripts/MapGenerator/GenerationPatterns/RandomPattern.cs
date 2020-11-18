using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPattern : RowGenerationPattern
{

    public RandomPattern(List<MapRow> map, MapObjectContainer container)
        : base(map, container)
    {
    }

    public override List<MapObject> GenerateRow(int size)
    {
        List<MapObject> row = new List<MapObject>(size);
        for (int i = 0; i < size; i++)
            row.Add(ObjectContainer.GetObject<Wall>());

        row[size / 2] = ObjectContainer.GetObject<Floor>();

        return row;
    }
}
