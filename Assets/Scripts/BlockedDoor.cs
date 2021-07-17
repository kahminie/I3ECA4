using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedDoor : MonoBehaviour
{
    public GameObject ThePlayer;

    public int CoinNeeded;

    public void Interact()
    {
        if (gameObject.tag == "KeyDoor")
        {
            if (ThePlayer.GetComponent<SamplePlayer>().numKey == 1)
            {
                Debug.Log("key door unlocked");
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
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("coin door locked");
            }
        }
    }
}
