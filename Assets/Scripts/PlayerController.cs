using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

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

        if ( Input.GetMouseButtonDown( 1 ) ) {

            Ray ray = camera.ScreenPointToRay( Input.mousePosition );

            RaycastHit hit;

            if( Physics.Raycast( ray, out hit, 100, movementMask ) ) {

                playerMtor.MoveToPoint( hit.point );

                Debug.Log( hit.collider.name + hit.point );
                //hitしたところにプレーヤーを移動させ
                
            }
        }

        if ( Input.GetMouseButtonDown( 0 ) ) {

            Ray ray = camera.ScreenPointToRay( Input.mousePosition );

            RaycastHit hit;

            if( Physics.Raycast( ray, out hit, 100 ) ) {
                //対話の可能性を確認、できるとフォーカスにする
                
            }
        }

	}
}
