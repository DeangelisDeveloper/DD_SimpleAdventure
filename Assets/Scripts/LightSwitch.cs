using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Light currentLight = null;
    [SerializeField] Renderer lampRenderer = null;
    [SerializeField] AudioSource lightSwitchAudioSource = null;
    [SerializeField] Material[] lampMaterials = null;
    [SerializeField] bool on;

    void Update()
    {
        if (on)
            SetLight(true, 0);

        else
            SetLight(false, 1);
    }

    void SetLight(bool value, int materialIndex)
    {
        currentLight.enabled = value;
        Material[] materials = lampRenderer.materials;
        materials[0] = lampMaterials[materialIndex];
        lampRenderer.materials = materials;
    }

    public void SwitchLight()
    {
        on = !on;
        lightSwitchAudioSource.Play();
    }
}
