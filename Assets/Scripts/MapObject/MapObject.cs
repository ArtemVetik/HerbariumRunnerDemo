using UnityEngine;
using UnityEngine.Events;

public abstract class MapObject : MonoBehaviour
{
    public event UnityAction<MapObject> BecameInvisible;

    private void OnBecameInvisible()
    {
        BecameInvisible?.Invoke(this);
    }
}
