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
                playerRedCubePower.CurrentBuffAvailable = currentBuff;
                break;
            case BuffTypes.GreenBuff:
                playerMovement.CurrentBuffAvailable = currentBuff;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.CurrentBuffAvailable = currentBuff;
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
                playerRedCubePower.CurrentBuffAvailable = BuffTypes.None;
                playerMovement.IsBuffApplied = false;
                break;
            case BuffTypes.GreenBuff:
                playerMovement.CurrentBuffAvailable = BuffTypes.None;
                playerMovement.IsBuffApplied = false;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.CurrentBuffAvailable = BuffTypes.None;
                playerMovement.IsBuffApplied = false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
