using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlashlightItem : MonoBehaviour
{
    public Light flashlight;           // Assign your spotlight here
    public float intensityStep = 1f; // Amount to change intensity by each press
    public float maxIntensity = 20.0f;  // Maximum intensity limit
    public float minIntensity = 0.0f;  // Minimum intensity limit

    public string increaseButton = "XRI_Right_TriggerButton"; 
    public string decreaseButton = "XRI_Left_TriggerButton";  

    private bool isHoldingFlashlight = false; // Tracks if the flashlight is held

    private void Awake()
    {
        // Ensure the flashlight has an XRGrabInteractable component
        var grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }
    }

    void Update()
    {
        if (flashlight != null && isHoldingFlashlight)
        {
            // Increase intensity
            if (Input.GetButtonDown(increaseButton))
            {
                flashlight.intensity = Mathf.Min(flashlight.intensity + intensityStep, maxIntensity);
            }
            // Decrease intensity
            if (Input.GetButtonDown(decreaseButton))
            {
                flashlight.intensity = Mathf.Max(flashlight.intensity - intensityStep, minIntensity);
            }
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isHoldingFlashlight = true;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isHoldingFlashlight = false;
    }
}
