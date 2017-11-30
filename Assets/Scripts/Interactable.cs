﻿using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3f;

    public Transform interactionTransform;

    bool isFocus = false;

    Transform player;

    bool hasInteracted = false;

    public virtual void Interact( ) {
        //用来重写
        Debug.Log( "Interacting with " + transform.name );

    }

    void Update( ) {

        if( isFocus && !hasInteracted ) {

            float distance = Vector3.Distance( player.position, interactionTransform.position );

            if( distance <= radius ) {

                Interact( );

                hasInteracted = true;

            }
            
        }

    }
    
    public void OnFocused( Transform playerTransform ) {

        isFocus = true;

        player = playerTransform;

        hasInteracted = false;

    }

    public void OnDefocused( ) {

        isFocus = false;

        player = null;

        hasInteracted = false;

    }

	void OnDrawGizmosSelected( ) {
        //Gizmos可視化サブーツール

        if( interactionTransform == null ) {

            interactionTransform = transform;

        }

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere( interactionTransform.position, radius );

    }
    
}
