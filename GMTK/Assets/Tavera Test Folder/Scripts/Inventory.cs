using System.Collections;
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
    public SpriteRenderer[] inventorySlots;
    
    public float BPM = 135;
    public float rythm = 0.89f;
    private float beatTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        elementBullets = new List<Elements_SO>();
        SlotMachineManager.instance.UpdateInventorySlots();
        UpdateUIInventorySlots();

        // Updates animator and sprite for first time
        gameObject.GetComponent<SpriteRenderer>().sprite = elementBullets[0].elementSprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = elementBullets[0].ballController;
        gameObject.GetComponent<Animator>().enabled = true;
        rythm = (60f / BPM) * 2f;

        timeTweenShots = 0;
    }
    private int fff = 0;
    // Update is called once per frame
    void Update()
    {
        beatTimer -= Time.deltaTime;
        if(beatTimer <= 0)
        {
            beatTimer = rythm;
        }

        //aim
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - spellPoint.position;
        float zRotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        spellPoint.rotation = Quaternion.Euler(0f, 0f, zRotation - 90);

        timeTweenShots -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && EnemyManager.instance.enemiesOnField.Count > 0 
            && elementBullets.Count > 0  && timeTweenShots <= 0 && !ScoreManager.instance.isGameOver)
        {
            if(beatTimer <= .5)
            {
                Debug.Log("Hit beat");
                ScoreManager.instance.IncreaseScoreInCurrentFrame(1000);
            }

            //spawn spell
            GameObject spell = Instantiate(currentSpell, spellPoint.position, spellPoint.rotation);
            spell.GetComponent<ElementComp>().elementObj = elementBullets[0];
            spell.GetComponent<Animator>().runtimeAnimatorController = elementBullets[0].spellController;

            elementBullets.Remove(elementBullets[0]);

            if (elementBullets.Count <= 0)
            {
                SlotMachineManager.instance.UpdateInventorySlots();
                UpdateUIInventorySlots();
            }


            // Update animator
            gameObject.GetComponent<Animator>().runtimeAnimatorController = elementBullets[0].ballController;
            gameObject.GetComponent<Animator>().enabled = true;

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

    public void UpdateUIInventorySlots()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            if(elementBullets[i] != null && elementBullets[i].elementSymbol)
                inventorySlots[i].sprite = elementBullets[i].elementSymbol;
            else
                inventorySlots[i].sprite = null;
        }
    }
}
