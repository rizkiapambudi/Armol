using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {

    public Animator anim;
    bool gg = false;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gg)
        {
            Mainkan();
        }
      
        //if (Input.GetKeyDown("1"))
        //{
        //  anim.Play("Default Take");
        //}
    }

    public void cek()
    {
        gg = true;

    }
    public void Mainkan()
    {
            anim.Play("Default Take");
     
    }

    public void Resume()
    {
        anim.speed = 1;

    }

    public void Berhenti()
    {
        anim.speed = 0;

    }

}
