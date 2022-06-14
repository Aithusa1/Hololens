using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiatSK20 : MonoBehaviour
{
    public Animator MachineAnimations;
    public bool pressed = false;



    void Update()
    {
        if (pressed)
        {
            Debug.Log("Pressed");
            var rot = Quaternion.Euler(-90, +45, 0);
            gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 1);
            //gameObject.transform.rotation = Quaternion.Euler(-90, 120, 0);
        }
    }



    public void HandCranck()
    {
        pressed = true;
    }

    public void PowerSwitchButton()
    {

    }

    public void Alignment()
    {
       
    }

    public void SetMachineheadHight()
    {

    }
}
