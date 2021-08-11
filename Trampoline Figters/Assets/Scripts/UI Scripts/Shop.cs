using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    GameObject menuPanel;
    [SerializeField]
    GameObject shopPanel;
    [SerializeField]
    GameObject productCart;

    public void ToMenu()
    {
        menuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }

    public void OpenProductCart(int productIndex)
    {
        productCart.SetActive(true);
    }

    public void CloseProductCart()
    {
        productCart.SetActive(false);
    }

}
