using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VRRespawn : MonoBehaviour
{
    public Transform player;            // Reference to the player's transform
    private Vector3 respawnPoint;        // The point at which the player will respawn
    public float fallThreshold = -10f;  // Y-coordinate below which the player will respawn
    public Transform flashLight;
    private Vector3 flashLightPoint;
    public Transform boulder;
    public Transform boulder2;
    public Transform boulder3;
    private Vector3 boulderPoint;
    private Vector3 boulder2Point;
    private Vector3 boulder3Point;
    private Quaternion respawnRotation;
    private Quaternion flashLightRotation;
    private Quaternion boulderRotation;
    private Quaternion boulder2Rotation;
    public Quaternion boulder3Rotation;
    public GameObject deathMenu;
    void Start()
    {
        deathMenu.SetActive(false);
        respawnPoint = player.position;
        boulderPoint = boulder.position;
        boulder2Point = boulder2.position;
        boulder3Point = boulder3.position;
        flashLightPoint = flashLight.position;
        respawnRotation = player.rotation;
        flashLightRotation = flashLight.rotation;
        boulderRotation = boulder.rotation;
        boulder2Rotation = boulder2.rotation;
        boulder3Rotation = boulder3.rotation;
    }

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (player.position.y < fallThreshold)
        {
            StartCoroutine(WaitBeforeRespawn());
        }

    }
    IEnumerator WaitBeforeRespawn()
    {
        yield return new WaitForSeconds(1);
        Respawn();
        deathMenu.SetActive(true);
    }

    void Respawn()
    {
        player.position = respawnPoint; // Reset the player's position to the respawn point
        player.rotation = respawnRotation;
        flashLight.position = flashLightPoint;
        flashLight.rotation = flashLightRotation;
        boulder.position = boulderPoint;
        boulder.rotation = boulderRotation;
        boulder2.position = boulder2Point;
        boulder3.position = boulder3Point;
        boulder2.rotation = boulder2Rotation;
        boulder3.rotation = boulder3Rotation;
        // Optionally reset velocity if using a Rigidbody
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
        deathMenu.SetActive(true); // Activate the death menu
    }
}
