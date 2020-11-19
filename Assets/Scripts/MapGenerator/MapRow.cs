using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapRow : MonoBehaviour
{
    [SerializeField] private int _width;

    private List<MapObject> _row;

    public event UnityAction<MapRow> BecameInvisible;

    public int Count => _row.Count;
    public MapObject this[int index] => _row[index];

    public void Init(RowGenerationPattern generationPattern)
    {
        _row = generationPattern.GenerateRow(_width);
    }

    public List<int> GetEmptyPositions()
    {
        List<int> emptyPositions = new List<int>();
        for (int index = 0; index < _row.Count; index++)
        {
            if (_row[index] is Floor)
                emptyPositions.Add(index);
        }

        return emptyPositions;
    }

    public void Spawn(Vector3 startPosition, Vector3 shift)
    {
        List<MapObject> instObjects = new List<MapObject>();
        foreach (MapObject mapObject in _row)
        {
            var inst = Instantiate(mapObject, startPosition, Quaternion.identity, transform);
            instObjects.Add(inst);
            startPosition += shift;
        }

        instObjects[0].BecameInvisible += OnObjectBecameInvisibe;

        _row = instObjects;
    }

    public void RemoveWall(Wall wall, Floor floor)
    {
        Floor instFloor = Instantiate(floor, wall.transform.position, Quaternion.identity, transform);

        if (_row.IndexOf(wall) == 0)
        {
            wall.BecameInvisible -= OnObjectBecameInvisibe;
            instFloor.BecameInvisible += OnObjectBecameInvisibe;
        }

        wall.Destroy();
        int position = _row.IndexOf(wall);
        _row[position] = instFloor;
    }

    public void Replace(int position, MapObject template)
    {
        var inst = Instantiate(template, _row[position].transform.position, Quaternion.identity);
        _row[position] = inst;
    }

    private void OnObjectBecameInvisibe(MapObject mapObject)
    {
        mapObject.BecameInvisible -= OnObjectBecameInvisibe;
        BecameInvisible?.Invoke(this);
    }
}