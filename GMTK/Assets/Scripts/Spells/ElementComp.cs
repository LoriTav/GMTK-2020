using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementComp : MonoBehaviour
{
    public Elements_SO elementObj;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.GetComponent<SpellObject>())
        {
            gameObject.GetComponent<SpriteRenderer>().color = elementObj.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
