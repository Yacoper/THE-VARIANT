using System;
using UnityEngine;

public class PlayerBuffController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    public void SetBuffAvailable(BuffTypes currentBuff)
    {
        switch (currentBuff)
        {
            case BuffTypes.None:
                break;
            case BuffTypes.RedBuff:
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
                break;
            case BuffTypes.GreenBuff:
                playerMovement.CurrentBuffAvailable = BuffTypes.None;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.CurrentBuffAvailable = BuffTypes.None;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
