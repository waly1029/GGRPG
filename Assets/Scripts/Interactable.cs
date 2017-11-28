﻿using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

	void OnDrawGizmosSelected( ) {
        //Gizmos可視化サブーツール
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere( transform.position, radius );

    }
}
