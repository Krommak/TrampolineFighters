using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject shopPanel;
    [SerializeField]
    GameObject gameUIPanel;

    [SerializeField]
    BaseCharacter[] charactersBC;

    public void GameStart()
    {
        
        gameUIPanel.SetActive(true);
        foreach(BaseCharacter BC in charactersBC)
        {
            BC.Pause();
        }
        menuPanel.SetActive(false);
    }

    public void ToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
}
