using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Manager manager = null;

    public void FinishGame()
    {
        manager.GameEnd();
    }
}
