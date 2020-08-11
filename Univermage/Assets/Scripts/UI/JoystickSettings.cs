using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickSettings : MonoBehaviour
{
    [SerializeField] RectTransform joystick;

    [SerializeField] Slider slider;

    bool setJoystickPosMode;

    Vector3 TouchDelta
    {
        get
        {
            if (Input.touchCount > 0)
            {
                Vector3 delta = Input.GetTouch(0).deltaPosition;

                return delta;
            }
            else
            {
                return Vector3.zero;
            }
        }
    }

    void Awake()
    {
        slider.value = joystick.sizeDelta.x;
    }

    void Update()
    {
        if (setJoystickPosMode)
        {
            joystick.position += TouchDelta * Time.deltaTime;
        }
    }

    public void SetJoystickSize(float value)
    {
        joystick.sizeDelta = new Vector2(value, value);
    }

    public void SetJoystickPosMode(bool value)
    {
        setJoystickPosMode = value;
    }
}