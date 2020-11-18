using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform _mapRoot;
    [SerializeField] private MapRow _rowTemplate;
    [SerializeField] private MapObjectContainer _container;

    private List<MapRow> _map;

    private void Start()
    {
        _map = new List<MapRow>();
        _map.Add(SpawnRow(Vector3.zero, new RandomPattern(_map, _container)));

        for (int i = 1; i < 24; i++)
            _map.Add(SpawnRow(Vector3.zero + Vector3.forward * i, new PreviousPattern(_map, _container)));
    }

    private MapRow SpawnRow(Vector3 startPosition, RowGenerationPattern pattern)
    {
        MapRow instRow = Instantiate(_rowTemplate, startPosition, Quaternion.identity, _mapRoot);
        instRow.Init(pattern);
        instRow.Spawn(startPosition, Vector3.right);
        instRow.BecameInvisible += OnRowBecameInvisible;

        return instRow;
    }

    private void OnRowBecameInvisible(MapRow row)
    {
        row.BecameInvisible -= OnRowBecameInvisible;
        Destroy(row.gameObject);
        _map.Remove(row);

        Vector3 nextPosition = _map[_map.Count - 1].transform.position + Vector3.forward;
        _map.Add(SpawnRow(nextPosition, new PreviousPattern(_map, _container)));
    }
}
