using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
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

    public static bool X_Button()
    {
        return Input.GetButtonDown("X_Button");
    }

    public static bool J_Run()
    {
        return Input.GetButton("J_Run");
    }
    public static bool J_Fire()
    {
        return Input.GetButtonDown("J_Fire");
    }
}
