using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemPresenter : MonoBehaviour
{
    public int index;
    public String side;
    public MeshRenderer renderer;

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void SetupItem(int index, String side, Vector3 vector, Material material)
    {
        this.index = index;
        this.side = side;
        transform.position = vector;
        renderer.material = material;

    }
    
    public void ChangePosition(Vector3 vector)
    {
        transform.position = vector;
    }

}
