﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMachineManager : MonoBehaviour
{
    public static SlotMachineManager instance;
    public Elements_SO[] slots;
    public Elements_SO[] allElementsObjs;
    public Inventory playerInventory;
   
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        slots = new Elements_SO[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventorySlots()
    {
        if (ScoreManager.instance.isGameOver) { return; }

        for(int i = 0; i < 3; i++)
        {
            int rndElementIndex = Random.Range(0, allElementsObjs.Length);
            slots[i] = allElementsObjs[rndElementIndex];
        }

        foreach(Elements_SO slotElement in slots)
        {
            playerInventory.CanAddToInventory(slotElement);
        }
    }

    public void UpdateMachineSlots()
    {
        if (ScoreManager.instance.isGameOver) { return; }

        for (int i = 0; i < 3; i++)
        {
            int rndElementIndex = Random.Range(0, allElementsObjs.Length);
            slots[i] = allElementsObjs[rndElementIndex];
        }
    }
}
