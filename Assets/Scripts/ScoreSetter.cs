using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSetter : MonoBehaviour {
    public Text score;
    private int theScore;
    private string userName;
    StayingScores sScore;

    void Start () {

        sScore = GameObject.Find("GodObject").GetComponent<StayingScores>();
        theScore = sScore.setScore;
        userName = sScore.changeName;

        score.text = "Your score is: " + theScore;

        Highscores.AddNewHighscore(userName, theScore);
	}
}
