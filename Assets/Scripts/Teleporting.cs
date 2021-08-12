using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    /// <summary>
    /// teleport target destination
    /// </summary>
    public Transform teleportTarget;

    /// <summary>
    /// reference sampleplayer script
    /// </summary>
    public GameObject thePlayer;

    /// <summary>
    /// loading screen when teleporting
    /// </summary>
    public GameObject tscreen;

    /// <summary>
    /// interactiion with teleporter
    /// </summary>
    public void Interact()
    {
        StartCoroutine(TransititonScreen());
        //move player position
        thePlayer.transform.position = teleportTarget.transform.position;
    }

    /// <summary>
    /// displays and delays teleport loading screen
    /// </summary>
    /// <returns></returns>
    public IEnumerator TransititonScreen()
    {
        tscreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        tscreen.gameObject.SetActive(false);
    }
}

