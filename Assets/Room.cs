using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    private bool allRender;
    private List<Renderer> childRenderer;

    private void Awake()
    {
        childRenderer = new List<Renderer>(GetComponentsInChildren<Renderer>());
    }

    private void OnEnable()
    {
        allRender = false;
        UpdateAllRenderer();
    }

    public void SetAllRender(bool allRender)
    {
        this.allRender = allRender;
        UpdateAllRenderer();
    }

    
    private void UpdateAllRenderer()
    {
        if(!allRender)
        {
            childRenderer.ForEach(r => r.enabled = false);
        }
        else
        {
            childRenderer.ForEach(r => r.enabled = true);
        }
    }



}
