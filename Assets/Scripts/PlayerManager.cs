using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Player p;
    Animator anim;
    bool airBorn;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        p = GetComponentInParent<Player>();
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
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey("right"))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey("left"))
        {
            anim.SetInteger("State", 1);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp("right"))
        {
            anim.SetInteger("State", 0);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp("left"))
        {
            anim.SetInteger("State", 0);
        }
    }
}
