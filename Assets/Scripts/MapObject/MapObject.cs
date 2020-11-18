using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MapObject : MonoBehaviour
{
    public event UnityAction<MapObject> BecameVisible;
    public event UnityAction<MapObject> BecameInvisible;

    private void OnBecameVisible()
    {
        BecameVisible?.Invoke(this);
    }

    private void OnBecameInvisible()
    {
        BecameInvisible?.Invoke(this);
    }
}
