using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    public GameObject tscreen;

    public void Interact()
    {
        StartCoroutine(TransititonScreen());
        thePlayer.transform.position = teleportTarget.transform.position;
    }

    public IEnumerator TransititonScreen()
    {
        tscreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        tscreen.gameObject.SetActive(false);
    }
}

