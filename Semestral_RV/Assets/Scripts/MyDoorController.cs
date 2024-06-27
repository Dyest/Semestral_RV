using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    [SerializeField] private AudioClip openDoorClip;
    [SerializeField] private AudioClip closeDoorClip;

    private AudioSource audioSource;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("BathroomDoorOpen", 0, 0.0f);
            PlaySound(openDoorClip);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("BathroomDoorClose", 0, 0.0f);
            PlaySound(closeDoorClip);
            doorOpen = false;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public float GetAnimationLength()
    {
        // Retorna a duração da animação atualmente em reprodução
        AnimatorStateInfo animState = doorAnim.GetCurrentAnimatorStateInfo(0);
        return animState.length;
    }
}
