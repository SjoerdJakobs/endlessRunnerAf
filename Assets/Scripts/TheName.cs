using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheName : MonoBehaviour
{
    [SerializeField]
    private Text displayName;
    private string name;
    private StayingScores sScore;

    void Start()
    {
        sScore = GameObject.Find("GodObject").GetComponent<StayingScores>();
        name = sScore.changeName;
        displayName.text = "" + name;
    }
}
