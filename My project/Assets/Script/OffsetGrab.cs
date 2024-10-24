using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffsetGrab : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        base.OnSelectEnter(interactor);
        StoreInteractor(interactor);
        MatchAttachmentPoint(interactor);
    }
    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }
    private void MatchAttachmentPoint(XRBaseInteractor interactor)
    {
        // Check whether the current object has an attachment point
        bool hasAttach = attachTransform != null;
        // Move the attachTransform of the hand to that of the interactable object
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }

    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        base.OnSelectExit(interactor);
        ResetAttachmentPoint(interactor);
        ClearInteractor(interactor);
    }
    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    
    }
    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
