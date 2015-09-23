using UnityEngine;
using System.Collections;

public class LaserBehaviour : MonoBehaviour {
    bool movingUp = false;
    private int lifeTime;
    private PlayerController player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

	void Update () {
        moving();

        lifeTime++;
        if (lifeTime == 500) Destroy(this.gameObject);
	}

    void moving()
    {

        float yPos = this.transform.position.y;

        if (yPos > 10) movingUp = false;
        else if (yPos < 2) movingUp = true;

        if (!movingUp)
            this.transform.Translate(Vector2.down * Time.deltaTime * 2f);
        else if (movingUp)
            this.transform.Translate(Vector2.up * Time.deltaTime * 2f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.setHealth--;
        }
    }

}
