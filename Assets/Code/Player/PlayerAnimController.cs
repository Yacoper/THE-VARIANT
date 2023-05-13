using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator leftHandAnimator;
    [SerializeField] private string fingerGunParameterName;
    [SerializeField] private string handFuckParameterName;
    [SerializeField] private string cubeGrabParameterName;
    [SerializeField] private string cubeDropParameterName;

    private int fingerGunID;
    private int handFuckID;
    private int cubeGrabID;
    private int cubeDropID;

    private void Awake()
    {
        fingerGunID = Animator.StringToHash(fingerGunParameterName);
        handFuckID = Animator.StringToHash(handFuckParameterName);
        cubeGrabID = Animator.StringToHash(cubeGrabParameterName);
        cubeDropID = Animator.StringToHash(cubeDropParameterName);
    }

    public void PlayFingerGunAnim()
    {
        leftHandAnimator.SetTrigger(fingerGunID);
    }

    public void PlayHandFuckAnim()
    {
        leftHandAnimator.SetTrigger(handFuckID);
    }

    public void PlayGrabCubeAnim()
    {
        leftHandAnimator.SetTrigger(cubeGrabID);
    }

    public void PlayDropCubeAnim()
    {
        leftHandAnimator.SetTrigger(cubeDropID);
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(leftHandAnimator), leftHandAnimator, true);
        ValidateUtilities.NullCheckVariable(this, nameof(fingerGunParameterName), fingerGunParameterName, true);
        ValidateUtilities.NullCheckVariable(this, nameof(handFuckParameterName), handFuckParameterName, true);
        ValidateUtilities.NullCheckVariable(this, nameof(cubeDropParameterName), cubeDropParameterName, true);
        ValidateUtilities.NullCheckVariable(this, nameof(cubeGrabParameterName), cubeGrabParameterName, true);
    }
}
