using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockedDoor : MonoBehaviour
{
    /// <summary>
    /// reference the player to access sampleplayer script
    /// </summary>
    public GameObject ThePlayer;

    /// <summary>
    /// coins needed to open door
    /// </summary>
    public int CoinNeeded;

    /// <summary>
    /// keys needed to open door
    /// </summary>
    public int KeysNeeded;

    /// <summary>
    /// weapon needed to break door
    /// </summary>
    public int WeaponNeeded;

    /// <summary>
    /// when player press E to interact with object...
    /// </summary>
    public void Interact()
    {
        //if the object is the key door
        if (gameObject.tag == "KeyDoor")
        {
            //if the player has the keys needed
            if (ThePlayer.GetComponent<SamplePlayer>().numKey == KeysNeeded)
            {
                Debug.Log("key door unlocked");
                //increase door and set inactive
                ThePlayer.GetComponent<SamplePlayer>().IncreaseDoor();
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("key door locked");
            }
        }
        //if the object is the coin door
        if (gameObject.tag == "CoinDoor")
        {
            //if the player has the coins needed
            if (ThePlayer.GetComponent<SamplePlayer>().numCoin == CoinNeeded)
            {
                Debug.Log("coin door unlocked");
                //set door inactive
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("coin door locked");
            }
        }
        //if the object is the treasure door
        if (gameObject.tag == "TreasureDoor")
        {
            //if player has weapon
            if (ThePlayer.GetComponent<SamplePlayer>().numWeapon == WeaponNeeded)
            {
                Debug.Log("treasure door unlocked");
                //increase door and set inactive
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
