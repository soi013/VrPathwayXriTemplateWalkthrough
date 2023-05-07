using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data"), SerializeField]
    private Animator animator;

    [SerializeField]
    private LineRenderer laserRenderer;

    [SerializeField]
    private TextMeshProUGUI targetName;

    [SerializeField]
    private TextMeshProUGUI targetPosition;

    protected override void Awake()
    {
        base.Awake();
        ChangeRaserActivate(false);
        ChangeTextActivate(false);
    }


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ChangeOpen(true);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ChangeOpen(false);
    }

    private void ChangeOpen(bool isOpen)
    {
        animator.SetBool("Opened", isOpen);
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        ChangeRaserActivate(true);
        ChangeTextActivate(true);
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        ChangeRaserActivate(false);
        ChangeTextActivate(false);
    }

    private void ChangeRaserActivate(bool isOn)
    {
        laserRenderer.gameObject.SetActive(isOn);
    }

    private void ChangeTextActivate(bool isActive)
    {
        targetName.gameObject.SetActive(isActive);
        targetPosition.gameObject.SetActive(isActive);
    }

}
