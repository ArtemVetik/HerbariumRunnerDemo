using UnityEngine;
using UnityEngine.Events;

public struct TouchData
{
    public Vector3 Position { get; private set; }
    public float Time { get; private set; }

    public TouchData(Vector2 position, float time)
    {
        Position = position;
        Time = time;
    }
}

public class TouchInput : BaseInputSystem
{
    private TouchData _lastTouch;
    private TouchData _directionTouch;
    private float _maxDoubleTouchDistance = 30f;
    private float _maxDoubleTouchDelay = 0.2f;

    public override event UnityAction<Vector2Int> DirectionChanged;
    public override event UnityAction DoubleClicked;

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            DirectionChanged?.Invoke(Vector2Int.up);
            return;
        }

        Touch directionTouch = Input.touches[0];
        if (directionTouch.phase == TouchPhase.Began)
        {
            TouchData touchData = new TouchData(directionTouch.position, Time.time);
            _directionTouch = touchData;
            if (IsDoubleClicked(directionTouch))
                DoubleClicked?.Invoke();
        }
        else if (directionTouch.phase == TouchPhase.Stationary && Time.time - _directionTouch.Time > 0.1f)
        {
            int direction = (int)Mathf.Sign(_directionTouch.Position.x - Camera.main.pixelWidth / 2);
            DirectionChanged?.Invoke(Vector2Int.left * direction);
        }

        if (Input.touchCount > 1)
        {
            Touch lastTouch = Input.touches[Input.touchCount - 1];
            if (IsDoubleClicked(lastTouch))
                DoubleClicked?.Invoke();
        }
    }

    private bool IsDoubleClicked(Touch touch)
    {
        if (touch.phase == TouchPhase.Began)
        {
            TouchData newTouchData = new TouchData(touch.position, Time.time);
            float distance = Vector2.Distance(_lastTouch.Position, newTouchData.Position);
            float deltaTime = newTouchData.Time - _lastTouch.Time;
            if (distance < _maxDoubleTouchDistance && deltaTime < _maxDoubleTouchDelay)
                return true;

            _lastTouch = newTouchData;
        }

        return false;
    }
}