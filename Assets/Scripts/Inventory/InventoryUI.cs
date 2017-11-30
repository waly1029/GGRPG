﻿using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[ ] slots;

    public GameObject inventoryUI;

    void Start( ) {

        inventory = Inventory.instance;

        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>( );

    }

    void Update( ) {

        if( Input.GetButtonDown( "Inventory" ) ) {

            inventoryUI.SetActive( !inventoryUI.activeSelf );

        }

    }

    void UpdateUI( ) {

        for( int i = 0; i < slots.Length; i++ ) {

            if( i < inventory.items.Count ) {

                slots[ i ].AddItem( inventory.items[ i ] );

            } else {

                slots[ i ].ClearSlot( );

            }

        }

    }
}
