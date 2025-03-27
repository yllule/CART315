using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    Outline outline;
    public string message; //message displayed when hovering object

    public UnityEvent onInteraction;

    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        outline.enabled = false;
    }

        public void EnableOutline()
    {
        outline.enabled = true;
    }
}
