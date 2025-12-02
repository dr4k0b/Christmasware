using UnityEngine;

public class ClementineDone : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindAnyObjectByType<Clementine>().done = true;
    }
}
