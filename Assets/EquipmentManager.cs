﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Keep track of equipment. Has functions for adding and removing items. */

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    void Awake( ) {

        if( instance != null ) {

            Debug.LogWarning( "More than one instance of EquipmentManager found!" );

            return;

        }

        instance = this;

    }

    #endregion

    public Equipment[ ] defaultItems;

    public SkinnedMeshRenderer targetMesh;

    Equipment[ ] currentEquipment;  // Items we currently have equipped

    SkinnedMeshRenderer[ ] currentMeshes;

    // Callback for when an item is equipped/unequipped
    public delegate void OnEquipmentChanged( Equipment newItem, Equipment oldItem );
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;    // Reference to our inventory

    void Start( ) {

        inventory = Inventory.instance;

        // Initialize currentEquipment based on number of equipment slots
        int numSlots = System.Enum.GetNames( typeof( EquipmentSlot ) ).Length;

        currentEquipment = new Equipment[ numSlots ];

        currentMeshes = new SkinnedMeshRenderer[ numSlots ];

        EquipDefaultItems( );

    }

    void Update( ) {

        if( Input.GetKeyDown( KeyCode.U ) ) {

            UnequipAll( );

        }

    }

    // Equip a new item
    public void Equip( Equipment newItem ) {

        // Find out what slot the item fits in
        int slotIndex = ( int )newItem.equipSlot;

        Equipment oldItem = Unequip( slotIndex ); 

        /*// If there was already an item in the slot
        // make sure to put it back in the inventory
        if( currentEquipment[slotIndex] != null ) {

            oldItem = currentEquipment[ slotIndex ];

            inventory.Add( oldItem );

        }*/

        // An item has been equipped so we trigger the callback
        if( onEquipmentChanged != null ) {

            onEquipmentChanged.Invoke( newItem, oldItem );

        }

        SetEquipmentBlendShapes( newItem, 100 );

        // Insert the item into the slot
        currentEquipment[ slotIndex ] = newItem;

        SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>( newItem.mesh );

        newMesh.transform.parent = targetMesh.transform;

        newMesh.bones = targetMesh.bones;

        newMesh.rootBone = targetMesh.rootBone;

        currentMeshes[ slotIndex ] = newMesh;

    }

    // Unequip an item with a particular index
    public Equipment Unequip( int slotIndex ) {

        // Only do this if an item is there
        if( currentEquipment[slotIndex] != null ) {

            if( currentMeshes[slotIndex] != null ) {

                Destroy( currentMeshes[ slotIndex ].gameObject );

            }

            Equipment oldItem = currentEquipment[ slotIndex ];

            SetEquipmentBlendShapes( oldItem, 0 );

            inventory.Add( oldItem );

            currentEquipment[ slotIndex ] = null;

            if( onEquipmentChanged != null ) {

                onEquipmentChanged.Invoke( null, oldItem );

            }

            return oldItem;

        }

        return null;

    }

    // Unequip all items
    public void UnequipAll( ) {

        for( int i = 0; i < currentEquipment.Length; i++ ) {

            Unequip( i );

        }

        EquipDefaultItems( );

    }

    void SetEquipmentBlendShapes(Equipment item, int weight ) {

        foreach( EquipmentMeshRegion blendShape in item.coveredMeshRegions ) {

            targetMesh.SetBlendShapeWeight( ( int )blendShape, weight );

        }

    }

    void EquipDefaultItems( ) {

        foreach( Equipment item in defaultItems ) {

            Equip( item );

        }
    }
}
