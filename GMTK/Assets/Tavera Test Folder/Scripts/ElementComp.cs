using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementComp : MonoBehaviour
{
    public Elements_SO elementObj;

    // Start is called before the first frame update
    void Start()
    {
        UpdateSelfElement(elementObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSelfElement(Elements_SO newElement)
    {
        elementObj = newElement;
        GetComponent<SpriteRenderer>().color = newElement.color;
    }
}
