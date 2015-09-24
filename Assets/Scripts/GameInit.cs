using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    public string _sceneToLoad = "Main";
    public Image _logoImage;
    public float _waitTime = 2f;
    public float _fadeSpeed = 0.5f;

    public void Awake()
    {
#if UNITY_EDITOR
        Application.LoadLevel(_sceneToLoad);
#else
        startFadeIn();
#endif
    }

    private void startFadeIn()
    {
        StartCoroutine(this.Hideintro(() => { Application.LoadLevel(_sceneToLoad); }));//start hide intro daarna maak callback naar scene laden
    }

    public IEnumerator Hideintro(Action _callback)
    {
        if (_callback != null)
        {
            if (_logoImage != null)
            {
                yield return new WaitForSeconds(this._waitTime);
                float i = 1f;
                while (_logoImage.GetComponent<Image>().color.a > 0f)
                {
                    i -= _fadeSpeed*Time.deltaTime;
                    _logoImage.GetComponent<Image>().color = (new Color(1, 1, 1, i));
                    yield return null;
                }
                _logoImage.GetComponent<Image>().color = (new Color(1, 1, 1, 0));
                _callback();
            }
            else
            {
                Debug.LogError("logoImage null");
            }
        }
        else
        {
            Debug.LogError("callback null");
        }
        yield return null;
    }

}
