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


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        balloonInstance = Instantiate(balloonPrefab, attachPoint);
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        Destroy(balloonInstance.gameObject);
    }
}
