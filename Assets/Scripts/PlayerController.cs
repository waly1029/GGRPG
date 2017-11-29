using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;//移動焦点

    public LayerMask movementMask;

    PlayerMotor playerMotor;

    Camera camera;
	// Use this for initialization
	void Start ( ) {
		
        camera = Camera.main;

        playerMotor = GetComponent<PlayerMotor>( );

	}
	
	// Update is called once per frame
	void Update ( ) {

        if ( Input.GetMouseButtonDown( 0 ) ) {

            Ray ray = camera.ScreenPointToRay( Input.mousePosition );

            RaycastHit hit;

            if( Physics.Raycast( ray, out hit, 100, movementMask ) ) {

                playerMotor.MoveToPoint( hit.point );

                Debug.Log( hit.collider.name + hit.point );
                //hitしたところにプレーヤーを移動させ
                RemoveFocus( );

            }
        }

        if ( Input.GetMouseButtonDown( 1 ) ) {

            Ray ray = camera.ScreenPointToRay( Input.mousePosition );

            RaycastHit hit;

            if( Physics.Raycast( ray, out hit, 100 ) ) {
                //対話の可能性を確認、できるとフォーカスにする
                Interactable interactable = hit.collider.GetComponent<Interactable>( );
                
                if( interactable != null ) {
                        
                    SetFocus( interactable );

                }
            }
        }

	}

    void SetFocus( Interactable newFocus ) {

        if( newFocus != focus ) {

            if( focus != null ) {

                focus.OnDefocused( );

            }

            focus = newFocus;

            playerMotor.FollowTarget( newFocus );
        }

        newFocus.OnFocused( transform );

    }

    void RemoveFocus( ) {

        if( focus != null ) {

            focus.OnDefocused( );

        }

        focus = null;

        playerMotor.StopFollowingTarget( );

    }
}
