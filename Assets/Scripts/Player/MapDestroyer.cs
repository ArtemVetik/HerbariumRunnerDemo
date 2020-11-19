using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] private MapObjectContainer _container;
    [SerializeField] private float _destroyDelay;

    private bool _canDestroy = true;

    public void DestroyWall(MapPosition position)
    {
        if (_canDestroy == false)
            return;

        if (position.MapRow[position.RowPosition] is Wall == false)
            return;

        Wall wall = position.MapRow[position.RowPosition] as Wall;
        position.MapRow.RemoveWall(wall, _container.GetObject<Floor>() as Floor);

        StartCoroutine(DestroyDelay(_destroyDelay));
    }

    private IEnumerator DestroyDelay(float delay)
    {
        _canDestroy = false;
        yield return new WaitForSeconds(delay);
        _canDestroy = true;
    }
}