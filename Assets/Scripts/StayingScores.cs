using UnityEngine;
using System.Collections;

public class StayingScores : MonoBehaviour {
    private int inGameScore;
    private string name;

    void Awake()
    {
        Object.DontDestroyOnLoad(gameObject);
    }

    public int setScore
    {
        get { return inGameScore; }
        set { inGameScore = value; }
    }
        
    public string changeName
    {
        get { return name; }
        set { name = value; }
    }
}
