﻿using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

    public float speed = 0.5f;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * 1 * speed;

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 1);
    }
}