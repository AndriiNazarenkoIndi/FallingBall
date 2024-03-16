using UnityEngine;

public class MobileInputSystem : IInput
{
    private Touch _touch;
    private Vector2 _touchInputValue;

    public Vector2 GetTouchDeltaPosition()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                return TouchInputValue();
            }
        }
        return Vector2.zero;
    }

    private Vector2 TouchInputValue()
    {
        _touchInputValue.x = _touch.deltaPosition.x;
        _touchInputValue.y = _touch.deltaPosition.y;
       return _touchInputValue;
    }
}