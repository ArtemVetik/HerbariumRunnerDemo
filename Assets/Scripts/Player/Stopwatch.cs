using UnityEngine;
using UnityEngine.Events;

public class Stopwatch : MonoBehaviour
{
    public event UnityAction<float> Tick;

    public float Seconds { get; private set; }

    private void Start()
    {
        Seconds = 0;
    }

    private void FixedUpdate()
    {
        Seconds += Time.fixedDeltaTime;
        Tick?.Invoke(Seconds);
    }
}
