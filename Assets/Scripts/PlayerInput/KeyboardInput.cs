using UnityEngine;
using UnityEngine.Events;

public class KeyboardInput : BaseInputSystem
{
    public override event UnityAction<Vector2Int> DirectionChanged;
    public override event UnityAction DoubleClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            DirectionChanged?.Invoke(Vector2Int.right);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            DirectionChanged?.Invoke(Vector2Int.left);
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            DirectionChanged?.Invoke(Vector2Int.up);

        if (Input.GetKeyDown(KeyCode.Space))
            DoubleClicked?.Invoke();
    }
}
