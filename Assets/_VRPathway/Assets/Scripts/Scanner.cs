using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Scanner : XRGrabInteractable
{

    [Header("Scanner Data"), SerializeField]
    private Animator animator;

    void Start()
    {
        animator.SetBool("Opened", true);
    }

    void Update()
    {

    }
}
