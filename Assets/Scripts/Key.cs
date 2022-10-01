using UnityEngine;

public class Key : ObjectPickUp
{
    [Header("Key")]
    [SerializeField] Door door;

    public override void PickUp()
    {
        manager.SetCurrentDoor(door);
        manager.FindDoorKey();
        base.PickUp();
    }
}
