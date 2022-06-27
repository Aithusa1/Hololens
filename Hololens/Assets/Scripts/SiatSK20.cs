using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Experimental.UI
{
    public class SiatSK20 : MonoBehaviour
    {
        public Animator MachineAnimations;
       
        public float headHeight;
        public float alignment;
        public float alignmentKnopTurn;

        public bool powerSwitch = false;
        public bool pressed = false;
        public bool smallBoxTrigger = false;
        public bool mediumBoxTrigger = false;
        public bool largeBoxTrigger = false;

        public GameObject headSlider;
        public GameObject alignmentSlider;
        public GameObject handCranck;
        public GameObject boneAnim;

        public GameObject machineInfoOne, machineInfoTwo, machineInfoThree, machineInfoFour, machineInfoFive;

        private void Start()
        {
            headSlider.GetComponent<StepSlider>().SliderValue = 0;
            alignmentSlider.GetComponent<StepSlider>().SliderValue = 0;

            machineInfoOne.SetActive(true);
            machineInfoTwo.SetActive(false);
            machineInfoThree.SetActive(false);
            machineInfoFour.SetActive(false);
            machineInfoFive.SetActive(false);

        }

        void Update()
        {
            if (pressed)
            {
                Debug.Log("Pressed");
                var rot = Quaternion.Euler(-90, handCranck.transform.rotation.y + 90, 0 );
                handCranck.transform.rotation = Quaternion.Lerp(handCranck.transform.rotation, rot, Time.deltaTime * 1);
                
                StartCoroutine(WaitTime());
                //gameObject.transform.rotation = Quaternion.Euler(-90, 120, 0);
            }



            headHeight = headSlider.GetComponent<StepSlider>().SliderValue;
            alignment = alignmentSlider.GetComponent<StepSlider>().SliderValue;
           
            MachineAnimations.SetFloat("Heigth Head", headHeight);
            MachineAnimations.SetFloat("Alginement Balk", alignment);
        }

        public IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(3f);
            pressed = false;
        }

        public void HandCranck()
        {
            if (pressed)
            {
                pressed = false;
            }
            else
            {
                pressed = true;

            }
        }

        public void PowerSwitchButton()
        {
            if (!powerSwitch)
            {
                MachineAnimations.SetFloat("Power Switch", 1f);
                powerSwitch = true;
            }

            if (powerSwitch)
            {
                MachineAnimations.SetFloat("Power Switch", 0f);
                powerSwitch = false;
            }
        }

        public IEnumerator WaitForBox()
        {
            yield return new WaitForSeconds(1f);
            smallBoxTrigger = false;
            mediumBoxTrigger = false;
            largeBoxTrigger = false;

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("SmallBox")   /* powerSwitch */)
            {
                Debug.Log("SmallBox Yes");

                if (headHeight == 0.5f && alignment == 0.5f && !smallBoxTrigger)
                {
                    smallBoxTrigger = true;
                    collision.gameObject.transform.SetParent(boneAnim.transform);
                    MachineAnimations.SetTrigger("Tape Wheel Front Down");
                    MachineAnimations.SetTrigger("Tape Wheel Back Down");

                    MachineAnimations.SetTrigger("Doos door machine");
                    StartCoroutine(WaitForBox());

                    //MachineAnimations.SetTrigger("Tape Wheel Front Up");
                    //MachineAnimations.SetTrigger("Tape Wheel Back Up");
                    // animatie doos door machine
                }
            }

            if (collision.transform.CompareTag("MediumBox")  /* powerSwitch */)
            {
                Debug.Log("MediumBox Yes");
                if (headHeight == 0.75f && alignment == 0.75f && !mediumBoxTrigger)
                {
                    mediumBoxTrigger = true;
                    collision.gameObject.transform.SetParent(boneAnim.transform);
                    MachineAnimations.SetTrigger("Doos door machine");

                    MachineAnimations.SetTrigger("Tape Wheel Front Down");
                    MachineAnimations.SetTrigger("Tape Wheel Back Down");
                    StartCoroutine(WaitForBox());

                    //MachineAnimations.SetTrigger("Tape Wheel Front Up");
                    //MachineAnimations.SetTrigger("Tape Wheel Back Up");
                    // animatie doos door machine
                }
            }

            if (collision.transform.CompareTag("LargeBox")  /* powerSwitch */)
            {
                Debug.Log("LargeBox Yes");
                if (headHeight == 1f && alignment == 1f && !largeBoxTrigger)
                {
                    largeBoxTrigger = true;
                    collision.gameObject.transform.SetParent(boneAnim.transform);
                    MachineAnimations.SetTrigger("Doos door machine");

                    MachineAnimations.SetTrigger("Tape Wheel Front Down");
                    MachineAnimations.SetTrigger("Tape Wheel Back Down");
                    StartCoroutine(WaitForBox());

                    //MachineAnimations.SetTrigger("Tape Wheel Front Up");
                    //MachineAnimations.SetTrigger("Tape Wheel Back Up");
                    // animatie doos door machine
                }
            }
        }
    }
}
