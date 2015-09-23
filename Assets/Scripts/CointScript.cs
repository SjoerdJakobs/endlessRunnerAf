using UnityEngine;
using System.Collections;

public class CointScript : MonoBehaviour {
    private TheScore scoreClass;
    public AudioClip coinSound;
    private AudioSource audioOn;
    void Awake()
    {
        audioOn = GetComponent<AudioSource>();
        scoreClass = GameObject.Find("GameHandler").GetComponent<TheScore>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioOn.PlayOneShot(coinSound, 1f);
            scoreClass.changeScore = 1;
            Destroy(this.gameObject);
            
        }
    }

}
