using System.Collections;
using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float speed = 0f;
    [SerializeField] float startDelay = 0f;
    Camera objectCamera;
    Vector3 objPrevPos;
    Vector3 objDiffPos;
    bool canRotate;

    void Start()
    {
        objPrevPos = Vector3.zero;
        objDiffPos = Vector3.zero;
        canRotate = false;
        StartCoroutine(Delay());
    }

    void Update()
    {
        if(canRotate)
            Rotate();
    }

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            objDiffPos = Input.mousePosition - objPrevPos;

            if (Vector3.Dot(transform.up, Vector3.up) >= 0)
                transform.Rotate(transform.up, -Vector3.Dot(objDiffPos, objectCamera.transform.right) * speed, Space.World);

            else
                transform.Rotate(transform.up, Vector3.Dot(objDiffPos, objectCamera.transform.right) * speed, Space.World);

            transform.Rotate(objectCamera.transform.right, Vector3.Dot(objDiffPos, objectCamera.transform.up) * speed, Space.World);
        }

        objPrevPos = Input.mousePosition;
    }

    public void SetCamera(Camera cam)
    {
        objectCamera = cam;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(startDelay);
        canRotate = true;
    }
}