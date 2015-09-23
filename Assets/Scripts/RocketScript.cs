using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {
    private int speed = 40;
    private PlayerController pClass;

    void Start()
    {
        transform.Rotate(0, 0, 90);
        pClass = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.x <= 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            pClass.setHealth -= 2;
            Destroy(this.gameObject);
        }
    }
}
