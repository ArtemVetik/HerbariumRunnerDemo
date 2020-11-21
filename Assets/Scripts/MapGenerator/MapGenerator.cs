using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Transform _mapRoot;
    [SerializeField] private Player _player;
    [SerializeField] private MapRow _rowTemplate;
    [SerializeField] private MapObjectContainer _container;

    public List<MapRow> Map { get; private set; }

    private void Start()
    {
        Map = new List<MapRow>();
        Map.Add(SpawnRow(Vector3.zero, new RandomGenerationPattern(Map, 1, _container)));

        int startSize = (int)Camera.main.orthographicSize * 3;
        for (int i = 1; i < startSize; i++)
            Map.Add(SpawnRow(Vector3.zero + Vector3.forward * i, new PreviousPattern(Map, _container)));

        int rowIndex = Map[0].GetEmptyPositions()[0];
        _player.Init(new MapPosition(Map[0], rowIndex));
    }

    private MapRow SpawnRow(Vector3 startPosition, RowGenerationPattern pattern)
    {
        MapRow instRow = Instantiate(_rowTemplate, startPosition, Quaternion.identity, _mapRoot);
        instRow.name = Map.Count.ToString();
        instRow.Init(pattern);
        instRow.Spawn(startPosition, Vector3.right);
        instRow.BecameInvisible += OnRowBecameInvisible;

        return instRow;
    }

    private void OnRowBecameInvisible(MapRow row)
    {
        row.BecameInvisible -= OnRowBecameInvisible;
        Destroy(row.gameObject);
        Map.Remove(row);

        Vector3 nextPosition = Map[Map.Count - 1].transform.position + Vector3.forward;
        Map.Add(SpawnRow(nextPosition, new PreviousPattern(Map, _container)));
    }
}