using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : MonoBehaviour
{
    public GameObject currentDoor;
    bool isDoorOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            currentDoor.transform.position += new Vector3(0, 6, 0);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (isDoorOpen)
        {
            isDoorOpen = false;
            currentDoor.transform.position += new Vector3(0, -6, 0);
        }
    }
}
