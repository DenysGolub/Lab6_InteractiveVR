using UnityEngine;

public class EnvironmentChanger : MonoBehaviour
{
    [Header("Skybox")]
    [SerializeField] private Material[] skyboxMaterials;

    [Header("Lighting")]
    [SerializeField] private Light targetLight;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 3f;

    [Header("Background Music")]
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioSource audioSource;


    public void ChangeSkybox()
    {
        if (skyboxMaterials == null || skyboxMaterials.Length == 0)
            return;

        Material randomSkybox = skyboxMaterials[
            Random.Range(0, skyboxMaterials.Length)
        ];

        RenderSettings.skybox = randomSkybox;
        DynamicGI.UpdateEnvironment();
    }

    public void ChangeLight()
    {
        if (targetLight == null)
            return;

        targetLight.color = Random.ColorHSV(
            0f, 1f,
            0.7f, 1f,
            0.8f, 1f
        );

        targetLight.intensity = Random.Range(
            minIntensity,
            maxIntensity
        );
    }

    public void ChangeMusic()
    {
        if (musicClips == null || musicClips.Length == 0 || audioSource == null)
            return;

        AudioClip randomClip = musicClips[
            Random.Range(0, musicClips.Length)
        ];

        audioSource.Stop();
        audioSource.clip = randomClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}