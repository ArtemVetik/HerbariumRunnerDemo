using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int _width;
    private List<MapRow> _map;

    private void Start()
    {
        _map = new List<MapRow>();
        _map.Add(new MapRow(_width, _width / 2));

        for (int i = 0; i < 60; i++)
            _map.Add(new MapRow(_width, _map[_map.Count - 1]));

        StartCoroutine(Generate());
    }

    private IEnumerator Generate() 
    {
        while (true) 
        {
            _map.Add(new MapRow(_width, _map[_map.Count - 1]));
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void OnDrawGizmos()
    {
        if (_map == null)
            return;

        float x = 0, y = 0;

        for (int i = 0; i < _map.Count; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (_map[i][j] == CellType.Wall)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.green;

                Gizmos.DrawCube(new Vector3(x, 0, y), Vector3.one);
                x += 1f;
            }
            x = 0f;
            y += 1f;
        }
    }
}
