using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class healthPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider hpBar;
    private float nexHealth;
    void Start()
    {
        hpBar = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (hpBar.value <= 0)
        // {
        //     nexHealth += 0.01f;
        //     hpBar.value = nexHealth;
        // }
        
        
    }
}
