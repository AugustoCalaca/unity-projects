﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
  public float forceSalt;
  public float velocityFactor;
	void Start () {

	}

	// Update is called once per frame
	void Update () {
    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
    float move = Input.GetAxis("Horizontal");
    bool keyDownSpace = Input.GetKeyDown(KeyCode.Space);
    rigidbody.velocity = new Vector2(move * velocityFactor, rigidbody.velocity.y);
    if(move < 0)
      GetComponent<SpriteRenderer>().flipX = true;
    else if(move > 0)
      GetComponent<SpriteRenderer>().flipX = false;
    if(keyDownSpace) {
      rigidbody.AddForce(new Vector2(0, forceSalt));
      GetComponent<Animator>().SetBool("jumped", true);
    }

    if(!keyDownSpace && GetComponent<Animator>().GetBool("jumped"))
      GetComponent<Animator>().SetBool("jumped", false);


    if(move < 0 || move > 0)
      GetComponent<Animator>().SetBool("walking", true);
    else
      GetComponent<Animator>().SetBool("walking", false);
  }
}
