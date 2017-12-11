using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Manager : MonoBehaviour
{
    Player1 p1;
    Player2 p2;
    Animator anim1;
    bool airBorn;

    // Use this for initialization
    void Start()
    {
        p1 = GetComponentInParent<Player1>();
        anim1 = p1.GetComponent<Animator>();
        airBorn = false;
    }

    void OnTriggerEnter2D()
    {
        airBorn = false;
        anim1.SetInteger("State", 0);
    }

    private void OnTriggerExit2D()
    {
        airBorn = true;
        if (airBorn)
        {
            anim1.SetInteger("State", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.MainJoystick() == Vector3.zero && airBorn == false)
        {
            anim1.SetInteger("State", 0);
        }
        if (InputManager.MainJoystick().x > 0.0 && airBorn == false)
        {
            anim1.SetInteger("State", 1);
        }
        if (InputManager.MainJoystick().x < 0.0 && airBorn == false)
        {
            anim1.SetInteger("State", 1);
        }
        if (InputManager.MainJoystick().y > 0.0)
        {
            anim1.SetInteger("State", 0);
        }
        if (InputManager.MainJoystick().y > 0.0)
        {
            anim1.SetInteger("State", 0);
        }
    }
}
