using UnityEngine;
using System.Collections;

public class GameOverHandeler : MonoBehaviour {
    private TheScore scoreClass;
    private StayingScores sScore;
    private PlayerController player;
    private float timer;

    void Awake()
    {
        scoreClass = GameObject.Find("GameHandler").GetComponent<TheScore>();
        sScore = GameObject.Find("GodObject").GetComponent<StayingScores>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
	
	void Update () {
        timer += Time.deltaTime;
        if (player.setHealth <= 0)
        {   
            gameOver();
        }
	}

    public void gameOver()
    {
        sScore.setScore = scoreClass.changeScore;
        Application.LoadLevel("leaderboardScene");
    }
}
