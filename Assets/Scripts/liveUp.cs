﻿using UnityEngine;
using System.Collections;

public class liveUp : MonoBehaviour {

    private PlayerController pClass;

    void Start()
    {
        pClass = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pClass.setHealth += 1;
            Destroy(this.gameObject);
        }
    }
}
