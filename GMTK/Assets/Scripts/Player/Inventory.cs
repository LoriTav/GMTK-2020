using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public OnBeatCanvas OnBeatC;
    public int maxSize = 3;
    public List<Elements_SO> elementBullets;
    public Transform spellPoint;
    public GameObject currentSpell;
    public float timeTweenShots;
    public float shotTimeReset = .35f;
    public SpriteRenderer[] inventorySlots;
    public SpriteRenderer[] MachineSlots;
    public SlotCanvas slotsCanvas;
    public EnemyManager enemyManager;
    public bool waveCanvasOn;

    public float BPM = 135;
    public float rythm = 0.89f;
    private float beatTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        elementBullets = new List<Elements_SO>();
        enemyManager = GameObject.Find("Enemy Manager").GetComponent<EnemyManager>();
       
        SlotMachineManager.instance.playerInventory = this;
        ScoreManager.instance.inventory = this;

        SlotMachineManager.instance.UpdateInventorySlots();
        UpdateUIInventorySlots();

        SlotMachineManager.instance.UpdateMachineSlots();
        ScoreManager.instance.SlotTimerOn = true;

        // Updates animator and sprite for first time
        UpdatePlayerAnimator();

        rythm = (60f / BPM) * 2f;
        timeTweenShots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        beatTimer -= Time.deltaTime;
        timeTweenShots -= Time.deltaTime;

        if(beatTimer <= 0)
        {
            beatTimer = rythm;
        }

        //aim
        Vector3 delta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - spellPoint.position;
        float zRotation = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        spellPoint.rotation = Quaternion.Euler(0f, 0f, zRotation - 90);

        if (Input.GetKeyDown(KeyCode.Mouse0) && enemyManager.enemiesOnField.Count > 0 
            && elementBullets.Count > 0 && timeTweenShots <= 0 && !ScoreManager.instance.isGameOver
            && !GameObject.Find("PauseMenus").GetComponent<PauseMenu>().isPaused && PlayerMovement.isRandomizingSpell == false)
        {
            if(beatTimer <= .5)
            {
                OnBeatC.CanvasOn();
                ScoreManager.instance.IncreaseScoreInCurrentFrame(200);
            }

            // Spawn a new spell and set its element to whatever is on top of the element bullets, and set its animator
            GameObject spell = Instantiate(currentSpell, spellPoint.position, spellPoint.rotation);
            spell.GetComponent<ElementComp>().elementObj = elementBullets[0];
            spell.GetComponent<Animator>().runtimeAnimatorController = elementBullets[0].spellController;

            // Remove top element from list after bullet is spawned
            elementBullets.Remove(elementBullets[0]);

            // Get new element bullets when player runs out
            if (elementBullets.Count <= 0)
            {
                SlotMachineManager.instance.UpdateInventorySlots();
                UpdateUIInventorySlots();

                SlotMachineManager.instance.UpdateMachineSlots();
                UpdateUIMachineSlots();
            }

            // Update animator on the player after spell is shot
            UpdatePlayerAnimator();

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

    public void UpdateUIMachineSlots()
    {
        for (int i = 0; i < MachineSlots.Length; i++)
        {
            if (elementBullets[i] != null && elementBullets[i].elementSymbol)
                MachineSlots[i].sprite = elementBullets[i].elementSymbol;
            else
                MachineSlots[i].sprite = null;
        }
        SoundManager.instance.PlaySlotsSound();
        slotsCanvas.enabled = true;
        slotsCanvas.CanvasOn();
    }

    private void UpdatePlayerAnimator()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = elementBullets[0].elementSprite;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = elementBullets[0].ballController;
        gameObject.GetComponent<Animator>().enabled = true;
    }
}
