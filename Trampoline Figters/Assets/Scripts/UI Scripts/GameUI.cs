using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject gameUIPanel;

    [SerializeField]
    BaseCharacter [] charactersBC;
    public void GamePause()
    {
        menuPanel.SetActive(true);
        gameUIPanel.SetActive(false);
        foreach(BaseCharacter BC in charactersBC)
        {
            BC.Pause();
        }
    }
}
