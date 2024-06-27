using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("BathroomDoorOpen", 0, 0.0f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("BathroomDoorClose", 0, 0.0f);
            doorOpen = false;
        }
    }

    public float GetAnimationLength()
    {
        // Retorna a duração da animação atualmente em reprodução
        AnimatorStateInfo animState = doorAnim.GetCurrentAnimatorStateInfo(0);
        return animState.length;
    }
}
