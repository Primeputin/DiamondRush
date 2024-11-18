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
    private Vector3 boulderPoint;
    private Quaternion respawnRotation;
    private Quaternion flashLightRotation;
    private Quaternion boulderRotation;
    public GameObject deathMenu;
    void Start()
    {
        deathMenu.SetActive(false);
        respawnPoint = player.position;
        boulderPoint = boulder.position;
        flashLightPoint = flashLight.position;
        respawnRotation = player.rotation;
        flashLightRotation = flashLight.rotation;
        boulderRotation = boulder.rotation;
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
        // Optionally reset velocity if using a Rigidbody
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
        }
        deathMenu.SetActive(true); // Activate the death menu
    }
}
