using UnityEngine;

public class CodePanel : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Manager manager = null;
    [SerializeField] Door door = null;
    public bool interactable;

    public void OpenCodePanelInterface()
    {
        manager.SetCurrentDoor(door);
        manager.SetCodeInterfaceState(true);
    }
}
