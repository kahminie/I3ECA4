using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;

    public void Interact()
    {
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}

