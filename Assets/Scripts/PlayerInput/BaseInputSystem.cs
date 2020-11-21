using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInputSystem : MonoBehaviour
{
    public abstract event UnityAction<Vector2Int> DirectionChanged;
    public abstract event UnityAction DoubleClicked;
}
