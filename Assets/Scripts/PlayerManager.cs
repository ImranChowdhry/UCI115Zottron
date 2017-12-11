using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Player1 p1;
    Player2 p2;
    Animator anim1, anim2;
    bool airBorn;

    // Use this for initialization
    void Start()
    {
        p1 = GetComponentInParent<Player1>();
        p2 = GetComponentInParent<Player2>();
        anim1 = p1.GetComponent<Animator>();
        anim2 = p2.GetComponent<Animator>();
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




        if (!Input.GetButton("Right") && !Input.GetButton("Left") && airBorn == false)
        {
            anim2.SetInteger("State", 0);
        }
        if (Input.GetButton("Right") && airBorn == false)
        {
            anim2.SetInteger("State", 1);
        }
        if (Input.GetButton("Left") && airBorn == false)
        {
            anim2.SetInteger("State", 1);
        }
    }
}
