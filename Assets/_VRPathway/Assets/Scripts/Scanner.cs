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
        ChangeTextActivate(isOpen);
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        base.OnActivated(args);
        ChangeRaserActivate(true);
    }

    private void ScanForObjects()
    {
        Vector3 worldHit = laserRenderer.transform.position + laserRenderer.transform.forward * 1000.0f; // new line

        if (Physics.Raycast(laserRenderer.transform.position, laserRenderer.transform.forward, out RaycastHit hit))
        {
            worldHit = hit.point; // new line
            SetTexts(hit.collider.name, hit.collider.transform.position);
        }
        else
        {
            SetTexts("---", Vector3.zero);
        }

        laserRenderer.SetPosition(1, laserRenderer.transform.InverseTransformPoint(worldHit)); // new line

    }

    private void SetTexts(string name, Vector3 position)
    {
        targetName.SetText($"Name:\n{name}");
        targetPosition.SetText($"Position:\n{position}");
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        base.OnDeactivated(args);
        ChangeRaserActivate(false);

        SetTexts("(Ready)", Vector3.zero);
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

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (!laserRenderer.gameObject.activeSelf)
            return;

        ScanForObjects();
    }
}
