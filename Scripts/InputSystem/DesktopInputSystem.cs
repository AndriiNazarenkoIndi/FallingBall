using UnityEngine;

public class DesktopInputSystem : IInput
{
    private Vector2 _inputValue;
    private float _horizontalInput;
    private float _verticalInput;

    public Vector2 GetTouchDeltaPosition()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        return InputValue(_horizontalInput, _verticalInput);
    }

    private Vector2 InputValue(float valueHorizontal, float valueVertical)
    {
        _inputValue.x = valueHorizontal;
        _inputValue.y = valueVertical;
        return _inputValue;
    }
}