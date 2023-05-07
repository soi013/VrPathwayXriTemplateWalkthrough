using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BalloonInflator : XRGrabInteractable
{

    [Header("Balloon Data")]
    [SerializeField]
    private Transform attachPoint;

    [SerializeField]
    private Balloon balloonPrefab;

    private Balloon balloonInstance;

    private XRBaseController grabedController;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (args.interactorObject is not XRBaseControllerInteractor controllerInteractor)
            return;

        grabedController = controllerInteractor.xrController;

        balloonInstance = Instantiate(balloonPrefab, attachPoint);


        //var value = controller.val.value;
        //balloonInstance.transform.localScale = Vector3.one * value;

    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (!isSelected || grabedController == null)
            return;

        float valueGrab = grabedController.activateInteractionState.value;

        balloonInstance.transform.localScale = Vector3.one * Mathf.Lerp(1.0f, 4.0f, valueGrab);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        Destroy(balloonInstance.gameObject);
    }
}
