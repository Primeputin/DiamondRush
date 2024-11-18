using UnityEngine;

public class ActivateUIOnTrigger : MonoBehaviour
{
    public GameObject uiElement; // Reference to the UI element to activate

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.collider.CompareTag("Finish"))
            {
                uiElement.SetActive(true);
            }
        }
    }
}
