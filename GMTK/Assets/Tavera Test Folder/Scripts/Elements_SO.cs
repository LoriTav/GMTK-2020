using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Element", menuName = "New Element")]
public class Elements_SO : ScriptableObject
{
    public string elementName;
    public Color color;
    public Sprite elementSprite;
    public RuntimeAnimatorController controller;
    public RuntimeAnimatorController spellController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
