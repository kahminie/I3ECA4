using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedDoor : MonoBehaviour
{
    public GameObject ThePlayer;

    public int CoinNeeded;

    public int KeysNeeded;

    public int WeaponNeeded;

    public void Interact()
    {
        if (gameObject.tag == "KeyDoor")
        {
            if (ThePlayer.GetComponent<SamplePlayer>().numKey == KeysNeeded)
            {
                Debug.Log("key door unlocked");
                ThePlayer.GetComponent<SamplePlayer>().IncreaseDoor();
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("key door locked");
            }
        }
        if (gameObject.tag == "CoinDoor")
        {
            if (ThePlayer.GetComponent<SamplePlayer>().numCoin == CoinNeeded)
            {
                Debug.Log("coin door unlocked");
                ThePlayer.GetComponent<SamplePlayer>().IncreaseCoin();
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("coin door locked");
            }
        }
        if (gameObject.tag == "TreasureDoor")
        {
            if (ThePlayer.GetComponent<SamplePlayer>().numWeapon == WeaponNeeded)
            {
                Debug.Log("treasure door unlocked");
                ThePlayer.GetComponent<SamplePlayer>().IncreaseTreasure();
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("treasure door locked");
            }
        }
    }
}
