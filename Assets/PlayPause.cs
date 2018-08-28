using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPause : MonoBehaviour {

    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("1"))
        {
            anim.Play("Default Take");
        }
	}

    public void pauseAnim()
    {
        //GameObject.FindWithTag("Model20").PlayAnimation(GameObject.FindWithTag("Model20"));
    }

}
