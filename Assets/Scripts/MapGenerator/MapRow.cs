using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapRow : MonoBehaviour
{
    [SerializeField] private int _width;

    private List<MapObject> _row;

    public event UnityAction<MapRow> BecameVisible;
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
        MapObject inst = null;
        foreach (MapObject mapObject in _row)
        {
            inst = Instantiate(mapObject, startPosition, Quaternion.identity, transform);
            startPosition += shift;
        }

        inst.BecameInvisible += OnObjectBecameInvisibe;
        inst.BecameVisible += OnObjectBecameVisible;
    }

    private void OnObjectBecameInvisibe(MapObject mapObject)
    {
        mapObject.BecameInvisible -= OnObjectBecameInvisibe;
        BecameInvisible?.Invoke(this);
    }

    private void OnObjectBecameVisible(MapObject mapObject)
    {
        mapObject.BecameVisible -= OnObjectBecameVisible;
        BecameVisible?.Invoke(this);
    }
}
