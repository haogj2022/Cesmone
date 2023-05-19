using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by: Nguyen Anh Hao
//Date created: 14/12/2022
//Object(s) holding this script: CoinShopManager
//Summary: Manage coin shop events

public class CoinShopManager : MonoBehaviour
{
    public GameObject buy128CoinsConfirm;
    public GameObject buy256CoinsConfirm;
    public GameObject buy512CoinsConfirm;

    public void Buy128Coins()
    {
        buy128CoinsConfirm.SetActive(true);
    }

    public void Buy256Coins()
    {
        buy256CoinsConfirm.SetActive(true);
    }

    public void Buy512Coins()
    {
        buy512CoinsConfirm.SetActive(true);
    }

    public void CancelPurchase()
    {
        buy128CoinsConfirm.SetActive(false);
        buy256CoinsConfirm.SetActive(false);
        buy512CoinsConfirm.SetActive(false);
    }

}
