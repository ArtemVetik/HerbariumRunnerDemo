using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellType
{
    Empty, Wall,
}

public class MapRow
{
    private List<CellType> _row;

    public int Count => _row.Count;
    public CellType this[int index] => _row[index];

    public MapRow(int size, int startPosition)
    {
        InitRow(size, CellType.Wall);

        _row[startPosition] = CellType.Empty;
    }

    public MapRow(int size, MapRow previousRow)
    {
        InitRow(size, CellType.Wall);

        List<int> nextPositions = GetRandomNextPositions(previousRow);
        for (int i = 0; i < nextPositions.Count; i++)
            AddEmptyCell(nextPositions[i], (float)nextPositions.Count / previousRow.GetEmptyPositions().Count);
    }

    private void InitRow(int size, CellType type)
    {
        _row = new List<CellType>(size);
        for (int i = 0; i < size; i++)
            _row.Add(type);
    }

    public List<int> GetEmptyPositions()
    {
        List<int> emptyPositions = new List<int>();
        for (int index = 0; index < _row.Count; index++)
        {
            if (_row[index] == CellType.Empty)
                emptyPositions.Add(index);
        }

        return emptyPositions;
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
        _row[position] = CellType.Empty;

        Debug.Log((float)position / _row.Count);

        if (position + 1 < _row.Count && TrueFalseEvent(probability))
            _row[position + 1] = CellType.Empty;
        if (position - 1 >= 0 && TrueFalseEvent(probability))
            _row[position - 1] = CellType.Empty;
    }

    private bool TrueFalseEvent(float probability)
    {
        return Random.Range(0f, 1f) < probability;
    }
}
