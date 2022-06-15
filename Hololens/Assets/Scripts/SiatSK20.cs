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
        public bool pressed = false;

        public float headHeight;
        public float alignment;
        public float alignmentKnopTurn;

        public bool powerSwitch;


        public GameObject headSlider;
        public GameObject alignmentSlider;
      

        private void Start()
        {
            headSlider.GetComponent<StepSlider>().SliderValue = 0;
            alignmentSlider.GetComponent<StepSlider>().SliderValue = 0;
            
        }

        void Update()
        {
            if (pressed)
            {
                Debug.Log("Pressed");
                var rot = Quaternion.Euler(-90, +45, 0);
                gameObject.transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 1);
                //gameObject.transform.rotation = Quaternion.Euler(-90, 120, 0);
            }

            headHeight = headSlider.GetComponent<StepSlider>().SliderValue;
            alignment = alignmentSlider.GetComponent<StepSlider>().SliderValue;
           
         
            MachineAnimations.SetFloat("Heigth Head", headHeight);
            MachineAnimations.SetFloat("Alginement Balk", alignment);
        }



        public void HandCranck()
        {
            pressed = true;
        }

        public void PowerSwitchButton()
        {
            MachineAnimations.SetFloat("Power Switch", 1f);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("SmallBox") && powerSwitch)
            {
                Debug.Log("SmallBox Yes");
                if (headHeight == 0f && alignment == 0f)
                {

                }
            }

            if (collision.transform.CompareTag("MediumBox") && powerSwitch)
            {
                Debug.Log("MediumBox Yes");
                if (headHeight == 0.5f && alignment == 0.5f)
                {

                }
            }

            if (collision.transform.CompareTag("LargeBox") && powerSwitch)
            {
                Debug.Log("LargeBox Yes");
                if (headHeight == 1f && alignment == 1f)
                {

                }
            }
        }
    }
}
