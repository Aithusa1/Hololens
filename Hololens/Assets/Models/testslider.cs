using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class testslider : MonoBehaviour
{
    [Range (0.0f, 1.0f) ]
    public float alingementBalk;

    [Range(0.0f, 1.0f)]
    public float heightHead;

    [Range(0.0f, 1.0f)]
    public float powerSwitch;

    [Range(0.0f, 1.0f)]
    public float alingementBalkKnop;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Alginement Balk", alingementBalk);
        anim.SetFloat("Heigth Head", heightHead);
        anim.SetFloat("Power Switch", powerSwitch);
        anim.SetFloat("TurnKnops Alginement Balk", alingementBalkKnop);

    }
}
