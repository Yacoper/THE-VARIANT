using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    public void ApplyBuff(BuffTypes currentBuff)
    {
        switch (currentBuff)
        {
            case BuffTypes.None:
                break;
            case BuffTypes.RedBuff:
                break;
            case BuffTypes.GreenBuff:
                playerMovement.HasGreenBuff = true;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.HasBlueBuff = true;
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
                break;
            case BuffTypes.GreenBuff:
                playerMovement.HasGreenBuff = false;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.HasBlueBuff = false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
