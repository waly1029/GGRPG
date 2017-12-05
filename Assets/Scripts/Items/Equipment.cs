using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* An item that can be equipped. */
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;  // Slot to store equipment in

    public SkinnedMeshRenderer mesh; //Unityの変装

    public EquipmentMeshRegion[ ] coveredMeshRegions;

    public int armorModifier;        // Increase/decrease in armor

    public int damageModifier;       // Increase/decrease in damage

    // When pressed in inventory
    public override void Use( ) {

        base.Use( );
        
        EquipmentManager.instance.Equip( this ); // アイテムを装備する
        
        RemoveFromInventory( );                  // このアイテムをInventoryから削除する

    }

}

public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Feet }

public enum EquipmentMeshRegion { Legs, Arms, Torso };  // Corresponds to body blendshapes