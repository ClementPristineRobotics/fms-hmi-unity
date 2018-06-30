using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class NextScene : StateMachineBehaviour {
    
	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        SceneManager.LoadScene("Map", LoadSceneMode.Single);
    }
    
}
