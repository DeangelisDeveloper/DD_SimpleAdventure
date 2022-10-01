using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Manager manager = null;
    [SerializeField] Camera playerCamera = null;
    [Header("Interaction")]
    [SerializeField] float interactionDistance = 0f;
    [SerializeField] KeyCode keyCode;
    [Header("GUI")]
    [SerializeField] GameObject dot = null;

    void Update()
    {
        if (Cursor.visible)
            return;

        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Mathf.Infinity))
        {
            Door door = hit.collider.gameObject.GetComponent<Door>();
            ObjectPickUp objectPickUp = hit.collider.gameObject.GetComponent<ObjectPickUp>();
            CodePanel codePanel = hit.collider.gameObject.GetComponent<CodePanel>();
            EndGameTrigger endGameTrigger = hit.collider.gameObject.GetComponent<EndGameTrigger>();
            LightSwitch lightSwitch = hit.collider.gameObject.GetComponent<LightSwitch>();
            ObjectDrag objectDrag = hit.collider.gameObject.GetComponent<ObjectDrag>();

            if (Vector3.Distance(gameObject.transform.position, hit.transform.position) <= interactionDistance)
            {
                if (door != null)
                {
                    if (door.interactable)
                    {
                        dot.SetActive(true);

                        if (Input.GetKeyDown(keyCode))
                            door.InteractDoor();
                    }
                }

                else if (objectPickUp != null)
                {
                    dot.SetActive(true);

                    if (Input.GetKeyDown(keyCode))
                        objectPickUp.PickUp();
                }

                else if (codePanel != null)
                {
                    if (codePanel.interactable)
                    {
                        dot.SetActive(true);

                        if (Input.GetKeyDown(keyCode))
                            codePanel.OpenCodePanelInterface();
                    }
                }

                else if (endGameTrigger != null)
                {
                    dot.SetActive(true);

                    if (Input.GetKeyDown(keyCode))
                        endGameTrigger.FinishGame();
                }

                else if (lightSwitch != null)
                {
                    dot.SetActive(true);

                    if (Input.GetKeyDown(keyCode))
                        lightSwitch.SwitchLight();
                }

                else if (objectDrag != null)
                    dot.SetActive(true);

                else
                {
                    dot.SetActive(false);
                }
            }

            else
            {
                dot.SetActive(false);
            }
        }
    }
}
