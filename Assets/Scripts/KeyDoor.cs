using UnityEngine;

public class KeyDoor : Door
{
    [Header("Key Door")]
    [SerializeField] string keyUsedString = "";
    [SerializeField] string keyNeededString = "";
    bool keyFound;

    void Start()
    {
        keyFound = false;
    }

    public override void FindKey()
    {
        keyFound = true;
    }

    public override void InteractDoor()
    {
        base.InteractDoor();

        if(isLocked)
        {
            if (keyFound)
            {
                isLocked = false;
                manager.SetMessageText(keyUsedString);
            }

            else
                manager.SetMessageText(keyNeededString);
        }
    }
}
