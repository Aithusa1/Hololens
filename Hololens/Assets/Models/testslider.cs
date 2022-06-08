using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class testslider : MonoBehaviour
{
    [Range (0.0f, 1.0f) ]
    public float test;
    public int a;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetLayerWeight(a, test);
            
            
    }
}
