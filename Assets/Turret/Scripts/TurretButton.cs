﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurretButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image turretImage = null;
    [SerializeField] private Text turretNameText = null;
    [SerializeField] private GameObject checkbox = null;

    private int myIndex = -1;
    private bool isOpen = true;

    private void Awake()
    {
        //if want to hide from inspector - cache here
        myIndex = transform.GetSiblingIndex();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isOpen) return;
        TurretManager.Instance.SetNewIndex(myIndex);
    }

    public void UpdateButton(TurretBlueprint turret, int selectedIndex, bool open)
    {
        turretNameText.text = turret.name;
        //turretImage.sprite = turret.Sprite;
        Unlock(open);
        ChangeCheckbox(selectedIndex);
    }

    public void Unlock(bool open)
    {
        isOpen = open;
        turretImage.color = isOpen ? Color.green : Color.red;
    }

    public void ChangeCheckbox(int selectedIndex)
    {
        bool activate = myIndex == selectedIndex;
        checkbox.SetActive(activate);
        //Debug.Log($"{myIndex}: activate checkbox = {activate}");
    }
}
