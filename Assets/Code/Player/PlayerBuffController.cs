using System;
using UnityEngine;

public class PlayerBuffController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerRedCubePower playerRedCubePower;

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
                break;
            case BuffTypes.GreenBuff:
                playerMovement.ApplyBuffFromCube(currentBuff, cubeData);
                break;
            case BuffTypes.BlueBuff:
                playerMovement.ApplyBuffFromCube(currentBuff, cubeData);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void ClearBuff(BuffTypes currentBuff)
    {
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
}
