using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator leftHandAnimator;
    [SerializeField] private string fingerGunParameterName;
    [SerializeField] private string handFuckParameterName;

    private int fingerGunID;
    private int handFuckID;

    private void Awake()
    {
        fingerGunID = Animator.StringToHash(fingerGunParameterName);
        handFuckID = Animator.StringToHash(handFuckParameterName);
    }

    public void PlayFingerGunAnim()
    {
        leftHandAnimator.SetTrigger(fingerGunID);
    }

    public void PlayHandFuckAnim()
    {
        leftHandAnimator.SetTrigger(handFuckID);
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(leftHandAnimator), leftHandAnimator, true);
        ValidateUtilities.NullCheckVariable(this, nameof(fingerGunParameterName), fingerGunParameterName, true);
        ValidateUtilities.NullCheckVariable(this, nameof(handFuckParameterName), handFuckParameterName, true);
    }
}
