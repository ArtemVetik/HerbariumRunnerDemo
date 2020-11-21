using UnityEngine;

public class Wall : MapObject
{
    [SerializeField] private ParticleSystem _destroyEffect;

    public void Destroy()
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
