using UnityEngine;
using System.Collections;

public class RocketSpawner : MonoBehaviour {
    [SerializeField]
    private GameObject rocket;
    [SerializeField]
    private GameObject player;
    private float counter;

    void Update()
    {
        if (counter != 400f) counter += 1f;
        else counter = 0f;

        if (counter == 400)
        {
            Instantiate(rocket, new Vector2(80f, player.transform.position.y), Quaternion.identity);
        }
    }
	
}
