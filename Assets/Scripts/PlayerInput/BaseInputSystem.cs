using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseInputSystem : MonoBehaviour
{
    public abstract event UnityAction<Vector2Int> ChangeDirection;
    public abstract event UnityAction DoubleClicked;
}
