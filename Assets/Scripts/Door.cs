using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("General")]
    public Manager manager;
    [SerializeField] Animator anim = null;
    [SerializeField] float disableInteractionTime = 0f;
    [SerializeField] bool isOpen;
    public bool isLocked;
    public bool interactable;
    [Header("Audio")]
    [SerializeField] AudioSource doorOpenAudioSource = null;
    [SerializeField] AudioSource doorCloseAudioSource = null;

    public virtual void FindKey() { }
    public virtual void CheckCode() { }
    public virtual void InsertCode(string s) { }

    public virtual void InteractDoor()
    {
        if (isLocked == false)
        {
            if (isOpen)
            {
                isOpen = false;
                anim.SetTrigger("close");
                doorCloseAudioSource.Play();
                StartCoroutine(DisableInteraction());
            }

            else
            {
                isOpen = true;
                anim.SetTrigger("open");
                doorOpenAudioSource.Play();
                StartCoroutine(DisableInteraction());
            }
        }
    }

    IEnumerator DisableInteraction()
    {
        interactable = false;
        yield return new WaitForSeconds(disableInteractionTime);
        interactable = true;
    }
}
