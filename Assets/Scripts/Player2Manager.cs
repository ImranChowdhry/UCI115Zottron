using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{

    Animator anim2;
    bool airBorn;

    // Use this for initialization
    void Start()
    {
        anim2 = GetComponent<Animator>();
        airBorn = false;
    }

    private void OnTriggerEnter2D()
    {
        print("hello");
        airBorn = false;
    }

    private void OnTriggerExit2D()
    {
        airBorn = true;
        if (airBorn)
        {
            print("hi");
            anim2.SetInteger("State", 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetButton("Right") || !Input.GetButton("Left") && airBorn == false)
        {
            anim2.SetInteger("State", 0);
        }
        if (Input.GetButton("Right") || Input.GetButton("Left") && airBorn == false)
        {
            anim2.SetInteger("State", 1);
        }
    }
}
/*
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
*/
