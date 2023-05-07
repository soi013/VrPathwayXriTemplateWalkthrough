using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data"), SerializeField]
    private Animator animator;

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
}
