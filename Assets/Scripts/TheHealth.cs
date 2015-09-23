using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TheHealth : MonoBehaviour {
    [SerializeField]
    private Text displayHealth;

    private PlayerController pScript;

    void Awake()
    {
        pScript = this.GetComponent<PlayerController>();
    }

    void Update()
    {
        displayHealth.text = "Health = " + pScript.setHealth;
    }
}
