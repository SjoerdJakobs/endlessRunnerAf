using UnityEngine;
using System.Collections;

public class saw : MonoBehaviour
{
    private PlayerController pClass;
    private int rotation = 0;

    void Start()
    {
        pClass = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Rotate(0, 0, rotation);
        rotation =+ 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pClass.setHealth -= 1;
        }
    }
}
