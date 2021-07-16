using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    [HideInInspector]
    public int KeyCount;

    [HideInInspector]
    public int CoinCount;

    public void Interact()
    {
        Debug.Log(KeyCount);
        Debug.Log(CoinCount);
        //if interact with tag key then...
        if (gameObject.transform.tag == "Key")
        {
            //set key to disappear after interaction and increase key count
            ++KeyCount;
            gameObject.SetActive(false);
            Debug.Log(KeyCount);
        }
        //if interact with tag coins then...
        if (gameObject.transform.tag == "Coins")
        {
            //set coins to disappear after interaction and increase coin count
            ++CoinCount;
            gameObject.SetActive(false);
            Debug.Log(CoinCount);
        }
    }
}
