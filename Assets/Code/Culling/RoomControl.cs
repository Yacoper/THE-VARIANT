using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    [SerializeField] private GameObject[] roomsToTurnOff;
    [SerializeField] private GameObject[] roomsToTurnOn;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
            return;

        foreach (GameObject room in roomsToTurnOn)
        {
            room.SetActive(true);
        }

        foreach (GameObject room in roomsToTurnOff)
        {
            room.SetActive(false);
        }
    }
}
