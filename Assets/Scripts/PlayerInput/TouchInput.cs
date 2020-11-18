using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchInput : BaseInputSystem
{
    public override event UnityAction<Vector2Int> ChangeDirection;
    public override event UnityAction<Vector2Int> DoubleClicked;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Camera.main.pixelWidth / 2)
                    ChangeDirection?.Invoke(Vector2Int.left);
                else
                    ChangeDirection?.Invoke(Vector2Int.right);
            }
            else if (touch.phase == TouchPhase.Ended)
                ChangeDirection?.Invoke(Vector2Int.up);
        }
    }
}