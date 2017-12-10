using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    // PS4 Axis
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

    //Xbox One Axis
    public static float MainHorizontal2()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainHorizontal2");
        r += Input.GetAxis("K_MainHorizontal2");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public static float MainVertical2()
    {
        float r = 0.0f;
        r += Input.GetAxis("J_MainVertical2");
        r += Input.GetAxis("K_MainVertical2");
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainJoystick2()
    {
        return new Vector3(MainHorizontal2(), 0, MainVertical2());
    }

    //PS4 Buttons
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

    //XboxOne Buttons
    public static bool AButton()
    {
        return Input.GetButtonDown("A_Button");
    }
    public static bool BButton()
    {
        return Input.GetButtonDown("B_Button");
    }
    public static bool YButton()
    {
        return Input.GetButtonDown("Y_Button");
    }
    public static bool XXOneButton()
    {
        return Input.GetButtonDown("XXOne_Button");
    }
    public static bool Run2Button()
    {
        return Input.GetButton("Run2");
    }
    public static bool Fire2()
    {
        return Input.GetButtonDown("Fire2");
    }
}
