using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheScore : MonoBehaviour {
    [SerializeField]
    private Text displayScore;
    private int score = 0;

    void awake()
    {
        displayScore.text = "score = " + score;
    }

    public int changeScore
    {
        set
        {
            score += value;
            displayScore.text = "score = " + score;
        }
        get { return score; }
    }
}
