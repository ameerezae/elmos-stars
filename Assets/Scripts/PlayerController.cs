using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject mousePoint;
    private GameObject circle;

    private float currentDistance;

    private float safeSpace;

    private float shootPower;

    private Vector3 shootDirection;

    // Start is called before the first frame update
    void Awake()
    {
        mousePoint = GameObject.FindGameObjectWithTag("mp");
    }

    // Update is called once per frame
    void OnMouseUp()
    {
        Vector3 push = shootDirection * shootPower;
        GetComponent<Rigidbody>().AddForce(push, ForceMode.Impulse);
    }

    private void OnMouseDrag()
    {
        
        currentDistance = Vector3.Distance(mousePoint.transform.position, transform.position);
        if (currentDistance <= 3f)
        {
            safeSpace = currentDistance;
        }
        else
        {
            safeSpace = 3f;
        }

        shootPower = Mathf.Abs(safeSpace) * 10;
        Vector3 dimxy = mousePoint.transform.position - transform.position;
        float differnce = dimxy.magnitude;
        mousePoint.transform.position = transform.position + ((dimxy / differnce) * currentDistance * -1);
        shootDirection = Vector3.Normalize(mousePoint.transform.position - transform.position);
    }
}