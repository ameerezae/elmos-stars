using System;
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

    private GamePresenter _gamePresenter;
    
    void Awake()
    {
        _gamePresenter = FindObjectOfType<GamePresenter>();
        mousePoint = GameObject.FindGameObjectWithTag("mp");
    }

    
    void OnMouseUp()
    {
        Vector3 push = shootDirection * shootPower;
        Rigidbody PlayerObj = GetComponent<Rigidbody>();
        PlayerItemPresenter player = GetComponent<PlayerItemPresenter>();
        if (
            player.side == _gamePresenter.gameModel.GetTurn() &&
            !FindObjectOfType<GamePresenter>().stopCounting)
        {
            _gamePresenter.HidePlayersTurnMask(); 
            StopAllCoroutines();
            StartCoroutine(ToggleTurnAfterStopingPlayers());
            PlayerObj.AddForce(push, ForceMode.Impulse);
            _gamePresenter.shootsCount++;
            _gamePresenter.stopCounting = true;
            _gamePresenter.t1 = Time.time;
            
        }
          
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

    public IEnumerator ToggleTurnAfterStopingPlayers()
    {
        yield return new WaitForSeconds(3);
        _gamePresenter.ToggleTurnForPlayers();
    }


}