using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Transform player = null;
    [SerializeField] float playerDistance = 0f;
    Vector3 offset;
    float zPos;

    Vector3 mouseScreenPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zPos;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    void OnMouseDown()
    {
        zPos = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - mouseScreenPos();
    }

    void OnMouseDrag()
    {
        if (Vector3.Distance(gameObject.transform.position, player.position) <= playerDistance)
            transform.position = mouseScreenPos() + offset;
    }
}
