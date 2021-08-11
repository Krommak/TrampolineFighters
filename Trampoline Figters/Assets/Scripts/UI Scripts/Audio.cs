using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    private bool audioIsActive = true;

    [SerializeField]
    Sprite soundOn, soundOff;
    
    GameObject button;
    void Start()
    {
        button = this.gameObject;
        audioIsActive = PlayerPrefs.GetInt("Sound") == 1 ? true : false;
        SetImage(audioIsActive);
    }

    public void SetAudio()
    {
        audioIsActive = audioIsActive ? false : true;
        PlayerPrefs.SetInt("Sound", audioIsActive ? 1 : 0);
        SetImage(audioIsActive);
    }

    private void SetImage(bool isActive)
    {
        Image imageComponent = button.GetComponent<Image>();

        imageComponent.sprite = isActive ? soundOn : soundOff;
    }

    public bool GetAudio()
    {
        return audioIsActive;
    }
}
