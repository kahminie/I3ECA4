using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public GameObject ThePlayer;

    public void Interact()
    {
        //if interact with tag key then...
        if (gameObject.transform.tag == "Key")
        {
            //set key to disappear after interaction and increase key count
            ThePlayer.GetComponent<SamplePlayer>().IncreaseKey();
            gameObject.SetActive(false);
        }
        //if interact with tag coins then...
        if (gameObject.transform.tag == "Coins")
        {
            //set coins to disappear after interaction and increase coin count
            ThePlayer.GetComponent<SamplePlayer>().IncreaseCoin();
            gameObject.SetActive(false);
        }
        if (gameObject.transform.tag == "Weapon")
        {
            //set coins to disappear after interaction and increase coin count
            ThePlayer.GetComponent<SamplePlayer>().IncreaseWeapon();
            gameObject.SetActive(false);
        }
    }
}
