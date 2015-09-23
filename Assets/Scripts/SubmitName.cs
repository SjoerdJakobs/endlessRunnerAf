using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour {
    [SerializeField]
    private InputField nameField;
    private StayingScores sScore;
    public string sceneToGoTo = "";
    void Awake()
    {
        sScore = GameObject.Find("GodObject").GetComponent<StayingScores>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            submit();
        }
    }


    public void submit()
    {
        //if (nameField.text == "theo") "{";

    
        sScore.changeName = nameField.text;
        Application.LoadLevel(sceneToGoTo);
    }
}
