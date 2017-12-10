using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    // Axis
    public static float MainHorizontal()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal");
        r += Input.GetAxis("K_MainHorizontal");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float MainVertical()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical");
        r += Input.GetAxis("K_MainVertical");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    // Buttons
    public static bool XButton()
    {
        return Input.GetButtonDown("X_Button");
    }
    public static bool CircleButton()
    {
        return Input.GetButtonDown("Circle_Button");
    }
    public static bool TriangleButton()
    {
        return Input.GetButtonDown("Triangle_Button");
    }
    public static bool SquareButton()
    {
        return Input.GetButtonDown("Square_Button");
    }
    public static bool RunButton()
    {
        return Input.GetButton("Run");
    }
    public static bool Fire()
    {
        return Input.GetButtonDown("Fire1");
    }
}
