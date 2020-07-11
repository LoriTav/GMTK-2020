using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxSize = 3;
    public List<Elements_SO> elementBullets;

    // Start is called before the first frame update
    void Start()
    {
        elementBullets = new List<Elements_SO>();
        SlotMachineManager.instance.UpdateInventorySlots();
        gameObject.GetComponent<SpriteRenderer>().sprite = elementBullets[0].elementSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            elementBullets.Remove(elementBullets[0]);
            
            if(elementBullets.Count <= 0)
            {
                SlotMachineManager.instance.UpdateInventorySlots();
            }

            gameObject.GetComponent<SpriteRenderer>().sprite = elementBullets[0].elementSprite;
        }
    }

    public bool CanAddToInventory(Elements_SO newBullet)
    {
        if(elementBullets.Count >= maxSize) { return false; }

        elementBullets.Add(newBullet);

        return true;
    }
}
