using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "New Element")]
public class Elements_SO : ScriptableObject
{
    public string elementName;
    public Sprite elementSprite;
    public Sprite elementSymbol;
    public Color color;

    public RuntimeAnimatorController ballController;
    public RuntimeAnimatorController spellController;
    public RuntimeAnimatorController pinAliveController;
    public RuntimeAnimatorController crackPinAliveController;
    public RuntimeAnimatorController[] crackPinDeathController;

    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
