using UnityEngine;
using UnityEngine.UI;

public class CodeDoor : Door
{
    [Header("Code Door")]
    [SerializeField] string codeString = "";
    [SerializeField] string rightWrongString = "";
    [SerializeField] string codeWrongString = "";
    [SerializeField] string code = "";
    [SerializeField] CodePanel codePanel = null;
    [SerializeField] AudioSource codePanelButtonAudioSource = null;
    string tmpCode = "";
    bool codeFound;

    void Start()
    {
        codeFound = false;
    }

    void Update()
    {
        manager.SetCodeText(tmpCode);
    }

    public override void InsertCode(string s)
    {
        tmpCode += s;
        codePanelButtonAudioSource.Play();
    }

    public override void CheckCode()
    {
        if (tmpCode == code)
        {
            codePanel.interactable = false;
            manager.SetMessageText(rightWrongString);
            codeFound = true;
            isLocked = false;
        }

        else
        {
            manager.SetMessageText(codeWrongString);
            tmpCode = "";
        }
    }

    public override void InteractDoor()
    {
        base.InteractDoor();

        if (isLocked)
        {
            if (codeFound == false)
                manager.SetMessageText(codeString);
        }
    }
}
