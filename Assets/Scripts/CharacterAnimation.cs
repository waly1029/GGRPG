using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimation : MonoBehaviour {

    const float locomationAnimationSmoothTime = .1f;

    Animator animator;

    NavMeshAgent agent;
	// Use this for initialization
	void Start ( ) {

        agent = GetComponent<NavMeshAgent>( );

        animator = GetComponentInChildren<Animator>( );

	}
	
	// Update is called once per frame
	void Update ( ) {
        //NavMeshAgent.speed:当跟随路径时的最大移动速度。
        float speedPercent = agent.velocity.magnitude / agent.speed;

        animator.SetFloat( "speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime );

	}
}
