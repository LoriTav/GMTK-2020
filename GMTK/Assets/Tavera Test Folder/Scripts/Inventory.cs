﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSize = 3;
    public List<Elements_SO> elementBullets;
    public Transform spellPoint;
    public GameObject currentSpell;
    public float timeTweenShots;
    public float shotTimeReset = .35f;

    // Start is called before the first frame update
    void Start()
    {
        elementBullets = new List<Elements_SO>();
        SlotMachineManager.instance.UpdateInventorySlots();
        gameObject.GetComponent<SpriteRenderer>().sprite = elementBullets[0].elementSprite;
        timeTweenShots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //aim
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - spellPoint.position;
        float zRotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        spellPoint.rotation = Quaternion.Euler(0f, 0f, zRotation - 90);

        timeTweenShots -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && EnemyManager.instance.enemiesOnField.Count > 0 
            && elementBullets.Count > 0  && timeTweenShots <= 0)
        {
            // currentSpell.GetComponent<SpriteRenderer>().color = elementBullets[0].color;
            //spawn spell
            var x = Instantiate(currentSpell, spellPoint.position, spellPoint.rotation);
            x.GetComponent<ElementComp>().elementObj = elementBullets[0];
            x.GetComponent<ElementComp>().UpdateSelfElement();

            elementBullets.Remove(elementBullets[0]);

            if (elementBullets.Count <= 0)
            {
                SlotMachineManager.instance.UpdateInventorySlots();
            }

            gameObject.GetComponent<SpriteRenderer>().sprite = elementBullets[0].elementSprite;
            timeTweenShots = shotTimeReset;
        }
    }

    public bool CanAddToInventory(Elements_SO newBullet)
    {
        if (elementBullets.Count >= maxSize) { return false; }

        elementBullets.Add(newBullet);

        return true;
    }
}
