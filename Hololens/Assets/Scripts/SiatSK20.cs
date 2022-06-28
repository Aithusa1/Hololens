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

        private Transform empty;
        public Transform boxPoint;

        public Material smallBoxShader;
        public Material bigBoxShader;

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
            headHeight = headSlider.GetComponent<StepSlider>().SliderValue;
            alignment = alignmentSlider.GetComponent<StepSlider>().SliderValue;

            MachineAnimations.SetFloat("Heigth Head", headHeight);
            MachineAnimations.SetFloat("Alginement Balk", alignment);

            //if (pressed)
            //{
            //    Debug.Log("Pressed");
            //    var rot = Quaternion.Euler(-90, handCranck.transform.rotation.y + 90, 0 );
            //    handCranck.transform.rotation = Quaternion.Lerp(handCranck.transform.rotation, rot, Time.deltaTime * 1);

            //    StartCoroutine(WaitTime());
            //    //gameObject.transform.rotation = Quaternion.Euler(-90, 120, 0);
            //}

        }

        public IEnumerator WaitTime()
        {
            yield return new WaitForSeconds(3f);
            pressed = false;
        }

        public void HandCranck()
        {
            //if (pressed)
            //{
            //    pressed = false;
            //}
            //else
            //{
            //    pressed = true;

            //}
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
            yield return new WaitForSeconds(1.45f);
            // tape doos value


            smallBoxTrigger = false;
            mediumBoxTrigger = false;
            largeBoxTrigger = false;

            MachineAnimations.ResetTrigger("Doos door machine");
            MachineAnimations.ResetTrigger("Tape Wheel Front Down");
            MachineAnimations.ResetTrigger("Tape Wheel Back Down");


        }

        

        private void OnCollisionEnter(Collision collision)
        {

            empty = collision.transform;

            if (collision.transform.CompareTag("SmallBox"))
            {
                Debug.Log("SmallBox Yes");
                StepThreeActive();
                if (headHeight == 0.5f && alignment == 0.5f && !smallBoxTrigger)
                {
                    StepFourActive();
                    if (powerSwitch)
                    {
                        smallBoxTrigger = true;
                        collision.gameObject.transform.SetParent(boneAnim.transform);             
                        StartCoroutine(WaitForBox());

                        smallBoxShader = collision.transform.GetComponent<Material>();
                        smallBoxShader.SetFloat("Swap", 1);
                        
                    }

                }
            }

            if (collision.transform.CompareTag("MediumBox")  )
            {
                Debug.Log("MediumBox Yes");
                StepThreeActive();
                if (headHeight == 0.75f && alignment == 0.75f && !mediumBoxTrigger)
                {
                    StepFourActive();
                    if (powerSwitch)
                    {                       
                        mediumBoxTrigger = true;
                        collision.gameObject.transform.SetParent(boneAnim.transform);
                        StartCoroutine(WaitForBox());
                        bigBoxShader = collision.transform.GetComponent<Material>();
                        bigBoxShader.SetFloat("Swap", 1);
                    }

                }
            }

            if (collision.transform.CompareTag("LargeBox")  )
            {
                Debug.Log("LargeBox Yes");
                StepThreeActive();
                if (headHeight == 0f && alignment == 0f && !largeBoxTrigger)
                {
                    StepFourActive();
                    if (powerSwitch)
                    { 
                        largeBoxTrigger = true;
                        collision.gameObject.transform.SetParent(boneAnim.transform);           
                        StartCoroutine(WaitForBox());

                        bigBoxShader = collision.transform.GetComponent<Material>();
                        bigBoxShader.SetFloat("Swap", 1);
                    }
                    

                }
            }
        }
    }
}
