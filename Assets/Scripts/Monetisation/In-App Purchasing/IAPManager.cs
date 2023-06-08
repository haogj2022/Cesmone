using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string coin5000 = "com.hao.cesmone.coin5000";
    private string coin25000 = "com.hao.cesmone.coin25000";
    private string coin100000 = "com.hao.cesmone.coin100000";

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == coin5000)
        {
            //reward your players
            Debug.Log("You've gained 5000 coins");
        }

        if (product.definition.id == coin25000)
        {
            //reward your players
            Debug.Log("You've gained 25000 coins");
        }

        if (product.definition.id == coin100000)
        {
            //reward your players
            Debug.Log("You've gained 100000 coins");
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed because" + failureReason);
    }
}
