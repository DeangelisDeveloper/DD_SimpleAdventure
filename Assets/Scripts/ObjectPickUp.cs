using UnityEngine;

public class ObjectPickUp : MonoBehaviour
{
    [Header("General")]
    public Manager manager;
    [SerializeField] GameObject objectPrefab = null;

    public virtual void PickUp()
    {
        manager.SetObjectPanelState(true, objectPrefab);
        Destroy(gameObject);
    }
}
