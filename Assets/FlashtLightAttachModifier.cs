using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class FlashtLightAttachModifier : MonoBehaviour
{
    IXRSelectInteractable m_SelectInteractable;

    protected void OnEnable()
    {
        m_SelectInteractable = GetComponent<IXRSelectInteractable>();
        if (m_SelectInteractable as Object == null)
        {
            Debug.LogError($"Ray Attach Modifier missing required Select Interactable on {name}", this);
            return;
        }

        m_SelectInteractable.selectEntered.AddListener(OnSelectEntered);
    }

    protected void OnDisable()
    {
        if (m_SelectInteractable as Object != null)
            m_SelectInteractable.selectEntered.RemoveListener(OnSelectEntered);
    }

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (!(args.interactorObject is XRRayInteractor))
            return;

        var attachTransform = args.interactorObject.GetAttachTransform(m_SelectInteractable);
        var originalAttachPose = args.interactorObject.GetLocalAttachPoseOnSelect(m_SelectInteractable);
        attachTransform.SetLocalPose(originalAttachPose);
    }
}
