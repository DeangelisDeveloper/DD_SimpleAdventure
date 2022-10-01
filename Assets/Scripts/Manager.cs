using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject player = null;
    [SerializeField] Camera objectCamera = null;
    Door currentDoor;
    GameObject currentObject;
    [Header("GUI")]
    [SerializeField] GameObject mainGui = null;
    [SerializeField] GameObject objectGui = null;
    [SerializeField] GameObject codePanelGui = null;
    [SerializeField] GameObject gameEndPanel = null;
    [SerializeField] Text codeText = null;
    [SerializeField] Text messageText = null;
    [SerializeField] float messageTextTime = 0f;

    void Start()
    {
        SetCursorState(false);
    }

    void SetCursorState(bool value)
    {
        Cursor.visible = value;

        if(value)
            Cursor.lockState = CursorLockMode.None;

        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void SetMessageText(string message)
    {
        StopAllCoroutines();
        messageText.text = message;
        StartCoroutine(ShowMessageText());
    }

    public void SetObjectPanelState(bool value, GameObject obj)
    {
        GameObject instance = currentObject;
        objectCamera.gameObject.SetActive(value);
        objectGui.SetActive(value);
        player.SetActive(!value);
        mainGui.SetActive(!value);
        SetCursorState(value);

        if (value == true)
        {
            instance = Instantiate(obj);
            instance.GetComponent<ObjectRotation>().SetCamera(objectCamera);
            currentObject = instance;
        }

        else
        {
            if (instance != null)
                Destroy(instance);
        }
    }

    public void CloseObjectPanel()
    {
        SetObjectPanelState(false, null);
    }

    public void SetCurrentDoor(Door door)
    {
        currentDoor = door;
    }

    public void FindDoorKey()
    {
        currentDoor.FindKey();
    }

    public void SetCodeInterfaceState(bool value)
    {
        codePanelGui.SetActive(value);
        mainGui.SetActive(!value);
        SetCursorState(value);
    }

    public void SetCodeText(string code)
    {
        codeText.text = code;
    }

    public void InsertDoorCode(int num)
    {
        string s = num.ToString();
        currentDoor.InsertCode(s);
    }

    public void CheckDoorCode()
    {
        currentDoor.CheckCode();
        SetCodeInterfaceState(false);
    }

    public void GameEnd()
    {
        gameEndPanel.SetActive(true);
        SetCursorState(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator ShowMessageText()
    {
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(messageTextTime);
        messageText.gameObject.SetActive(false);
    }
}
