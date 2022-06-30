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

        public GameObject machineInfoOne;
        public GameObject machineInfoTwo;
        public GameObject machineInfoThree;
        public GameObject machineInfoFour;
        public GameObject machineInfoFive;

        public bool small = false, medium = false, large = false;

        public Transform boxPoint;

        private Transform empty;
        private Renderer rend;

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

        private void OnCollisionEnter(Collision collision)
        {
            empty = collision.transform;

            if (empty.transform.CompareTag("SmallBox"))
            {

                small = true;

            }

            if (empty.transform.CompareTag("MediumBox"))
            {
                medium = true;
            }

            if (empty.transform.CompareTag("LargeBox"))
            {
                large = true;
            }
        }




        void Update()
        {
            headHeight = headSlider.GetComponent<StepSlider>().SliderValue;
            alignment = alignmentSlider.GetComponent<StepSlider>().SliderValue;

            MachineAnimations.SetFloat("Heigth Head", headHeight);
            MachineAnimations.SetFloat("Alginement Balk", alignment);

            if( alignment != 0)
            {
                StepFourActive();
            }
            if(headHeight != 0)
            {
                StepFiveActive();
            }




            if (small)
            {
                Debug.Log("SmallBox Yes");
                StepThreeActive();
                if (headHeight == 0.5f && alignment == 0.5f && !smallBoxTrigger)
                {

                    if (powerSwitch)
                    {
                        StartCoroutine(WaitForBox());
                        smallBoxTrigger = true;
                        empty.gameObject.transform.SetParent(boneAnim.transform);

                    }
                }
            }

            

            if (medium)
            {
                Debug.Log("MediumBox Yes");
                StepThreeActive();
                if (headHeight == 0.25f && alignment == 0.25 && !mediumBoxTrigger)
                {

                    if (powerSwitch)
                    {
                        StartCoroutine(WaitForBox());
                        mediumBoxTrigger = true;
                        empty.gameObject.transform.SetParent(boneAnim.transform);

                    }
                }
            }

            if (large)
            {
                Debug.Log("LargeBox Yes");
                StepThreeActive();
                if (headHeight == 0f && alignment == 0f && !largeBoxTrigger)
                {
                    if (powerSwitch)
                    {
                        StartCoroutine(WaitForBox());
                        largeBoxTrigger = true;
                        empty.gameObject.transform.SetParent(boneAnim.transform);


                    }
                }
            }
        }
    
        public IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(3f);
            pressed = false;
        }

        public void PowerSwitchButton()
        {
            if (!powerSwitch)
            {
                MachineAnimations.SetFloat("Power Switch", 1f);
                powerSwitch = true;
            }
            else if (powerSwitch)
            {
                MachineAnimations.SetFloat("Power Switch", 0f);
                powerSwitch = false;
            }
        }

        #region Steps
        public void StepTwoActive()
        {
            machineInfoOne.SetActive(false);
            machineInfoTwo.SetActive(true);
        }

        public void StepThreeActive()
        {
            machineInfoTwo.SetActive(false);
            machineInfoThree.SetActive(true);
        }

        public void StepFourActive()
        {
            machineInfoThree.SetActive(false);
            machineInfoFour.SetActive(true);
        }

        public void StepFiveActive()
        {
            machineInfoFour.SetActive(false);
            machineInfoFive.SetActive(true);
        }
        #endregion

        public IEnumerator WaitForBox()
        {

            MachineAnimations.SetTrigger("Doos door machine");
            MachineAnimations.SetTrigger("Tape Wheel Front Down");
            MachineAnimations.SetTrigger("Tape Wheel Back Down");

            yield return new WaitForSeconds(1.45f);

            empty.parent = null;
            empty.position = boxPoint.position;

            rend = empty.transform.GetComponent<Renderer>();
            rend.material.SetFloat("swap", 1);

            yield return new WaitForSeconds(1.45f);
            
            smallBoxTrigger = false;
            mediumBoxTrigger = false;
            largeBoxTrigger = false;

                small = false;
            medium = false;
            large = false;

            MachineAnimations.ResetTrigger("Doos door machine");
            MachineAnimations.ResetTrigger("Tape Wheel Front Down");
            MachineAnimations.ResetTrigger("Tape Wheel Back Down");

        
        }



       


    }
}
