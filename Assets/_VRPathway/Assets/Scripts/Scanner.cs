using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data"), SerializeField]
    private Animator animator;

    void Start()
    {
    }

    void Update()
    {

    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        animator.SetBool("Opened", true);
    }
}
