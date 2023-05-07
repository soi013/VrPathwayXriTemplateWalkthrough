using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data"), SerializeField]
    private Animator animator;

    [SerializeField]
    private LineRenderer laserRenderer;

    protected override void Awake()
    {
        base.Awake();
        ChangeRaserEnable(false);
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
        ChangeRaserEnable(true);
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        ChangeRaserEnable(false);
    }

    private void ChangeRaserEnable(bool isOn)
    {
        laserRenderer.gameObject.SetActive(isOn);
    }
}
