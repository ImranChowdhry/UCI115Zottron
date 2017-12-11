using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Player1 p1;
    Player2 p2;
    Animator anim;
    bool airBorn;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        p1 = GetComponentInParent<Player1>();
        p2 = GetComponentInParent<Player2>();
        airBorn = false;
    }

    void OnTriggerEnter2D()
    {
        airBorn = false;
        anim.SetInteger("State", 0);
    }

    private void OnTriggerExit2D()
    {
        airBorn = true;
        if (airBorn)
        {
            anim.SetInteger("State", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.MainJoystick() == Vector3.zero && airBorn == false)
        {
            anim.SetInteger("State", 0);
        }
        if (InputManager.MainJoystick().x > 0.0 && airBorn == false)
        {
            anim.SetInteger("State", 1);
        }
        if (InputManager.MainJoystick().x < 0.0 && airBorn == false)
        {
            anim.SetInteger("State", 1);
        }
        if (InputManager.MainJoystick().y > 0.0)
        {
            anim.SetInteger("State", 0);
        }
        if (InputManager.MainJoystick().y > 0.0)
        {
            anim.SetInteger("State", 0);
        }
    }
}
