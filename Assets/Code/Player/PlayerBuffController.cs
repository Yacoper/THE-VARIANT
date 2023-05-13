using System;
using System.Collections;
using UnityEngine;

public class PlayerBuffController : MonoBehaviour
{
    [SerializeField] private ParticleSystem blueBuff;
    [SerializeField] private ParticleSystem redBuff;
    [SerializeField] private ParticleSystem greenBuff;
    
    private PlayerMovement playerMovement;
    private PlayerRedCubePower playerRedCubePower;

    private ParticleSystem currentBuffParticleSystem;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerRedCubePower = GetComponent<PlayerRedCubePower>();
    }
    
    public void SetBuffAvailable(BuffTypes currentBuff, CubeDataSO cubeData)
    {
        switch (currentBuff)
        {
            case BuffTypes.None:
                break;
            case BuffTypes.RedBuff:
                playerRedCubePower.ApplyBuffFromCube(currentBuff, cubeData);
                StartCoroutine(TurnOnBuffVFX(currentBuff));
                break;
            case BuffTypes.GreenBuff:
                playerMovement.ApplyBuffFromCube(currentBuff, cubeData);
                StartCoroutine(TurnOnBuffVFX(currentBuff));
                break;
            case BuffTypes.BlueBuff:
                playerMovement.ApplyBuffFromCube(currentBuff, cubeData);
                StartCoroutine(TurnOnBuffVFX(currentBuff));
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ClearBuff(BuffTypes currentBuff)
    {
        currentBuffParticleSystem.gameObject.SetActive(false);
        switch (currentBuff)
        {
            case BuffTypes.RedBuff:
                playerRedCubePower.ClearBuffFromCube();
                break;
            case BuffTypes.GreenBuff:
                playerMovement.ClearBuffFromCube();
                break;
            case BuffTypes.BlueBuff:
                playerMovement.ClearBuffFromCube();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private IEnumerator TurnOnBuffVFX(BuffTypes currentBuff)
    {
        yield return new WaitForSeconds(0.7f);
        switch (currentBuff)
        {
            case BuffTypes.None:
                break;
            case BuffTypes.RedBuff:
                currentBuffParticleSystem = redBuff;
                currentBuffParticleSystem.gameObject.SetActive(true);
                break;
            case BuffTypes.GreenBuff:
                currentBuffParticleSystem = greenBuff;
                currentBuffParticleSystem.gameObject.SetActive(true);
                break;
            case BuffTypes.BlueBuff:
                currentBuffParticleSystem = blueBuff;
                currentBuffParticleSystem.gameObject.SetActive(true);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(blueBuff), blueBuff, true);
        ValidateUtilities.NullCheckVariable(this, nameof(redBuff), redBuff, true);
        ValidateUtilities.NullCheckVariable(this, nameof(greenBuff), greenBuff, true);
    }
}
