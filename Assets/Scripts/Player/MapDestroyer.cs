using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MapDestroyer : MonoBehaviour
{
    [SerializeField] private MapObjectContainer _container;
    [SerializeField] private float _destroyDelay;

    private bool _canDestroy = true;

    public event UnityAction Destroyed;
    public event UnityAction ReadyToDestroy;

    public void DestroyWall(MapPosition position)
    {
        if (_canDestroy == false)
            return;

        if (position.Row[position.RowPosition] is Wall == false)
            return;

        Wall wall = position.Row[position.RowPosition] as Wall;
        position.Row.RemoveWall(wall, _container.GetObject<Floor>() as Floor);

        StartCoroutine(DestroyDelay(_destroyDelay));
    }

    private IEnumerator DestroyDelay(float delay)
    {
        _canDestroy = false;
        Destroyed?.Invoke();
        yield return new WaitForSeconds(delay);
        _canDestroy = true;
        ReadyToDestroy?.Invoke();
    }
}