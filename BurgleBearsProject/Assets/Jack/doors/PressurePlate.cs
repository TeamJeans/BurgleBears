using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public Animator anim;


    private void OnTriggerStay(Collider other)
    {
        anim.SetBool("open", true);
        anim.SetBool("close", false);
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("open", false);
        anim.SetBool("close", true);
    }
}
