using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public Animator countDown;
    public string animationStateName = "cd";

    [SerializeField] private FlyBehaviour flyBehaviour;
    [SerializeField] private PipeSpawner pipeSpawner;
    [SerializeField] private LoopGround loopGround;

    void Start()
    {
        StartCoroutine(WaitForAnimation(countDown, animationStateName));
    }

    IEnumerator WaitForAnimation(Animator animator, string stateName)
    {
        animator.Play(stateName);

        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(stateName))
        {
            yield return null;
        }

        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

        Debug.Log("Animation done!");
        Time.timeScale = 1f;
        flyBehaviour.CanFly();
        Debug.Log("Animation Fly!");
        pipeSpawner.CanMove();
        loopGround.CanMove();
        Destroy(gameObject);
        
    }
}
