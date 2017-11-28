using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;//移動焦点

    public LayerMask movementMask;

    PlayerMotor playerMtor;

    Camera camera;
	// Use this for initialization
	void Start ( ) {
		
        camera = Camera.main;

        playerMtor = GetComponent<PlayerMotor>( );

	}
	
	// Update is called once per frame
	void Update ( ) {

        if ( Input.GetMouseButtonDown( 0 ) ) {

            Ray ray = camera.ScreenPointToRay( Input.mousePosition );

            RaycastHit hit;

            if( Physics.Raycast( ray, out hit, 100, movementMask ) ) {

                playerMtor.MoveToPoint( hit.point );

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

        focus = newFocus;

        playerMtor.FollowTarget( newFocus );

    }

    void RemoveFocus( ) {

        focus = null;

        playerMtor.StopFollowingTarget( );

    }
}
