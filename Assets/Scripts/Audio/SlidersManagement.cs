using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSliderManager : MonoBehaviour
{
    // Référence à l'AudioMixer
    public AudioMixer audioMixer;

    // Sliders pour les groupes audio
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    // Les noms des paramètres dans l'AudioMixer
    private const string MasterVolumeParam = "VolumeMaster";
    private const string MusicVolumeParam = "VolumeMusic";
    private const string SfxVolumeParam = "VolumeSfx";

    private void Start()
    {
        // Initialiser les sliders avec les valeurs actuelles de l'AudioMixer
        InitializeSlider(masterSlider, MasterVolumeParam);
        InitializeSlider(musicSlider, MusicVolumeParam);
        InitializeSlider(sfxSlider, SfxVolumeParam);

        // Ajouter des listeners pour détecter les changements sur les sliders
        masterSlider.onValueChanged.AddListener(value => SetVolume(MasterVolumeParam, value));
        musicSlider.onValueChanged.AddListener(value => SetVolume(MusicVolumeParam, value));
        sfxSlider.onValueChanged.AddListener(value => SetVolume(SfxVolumeParam, value));
    }

    private void InitializeSlider(Slider slider, string parameterName)
    {
        // Obtenir la valeur actuelle du paramètre dans l'AudioMixer
        if (audioMixer.GetFloat(parameterName, out float currentVolume))
        {
            // Convertir de dB en valeur normale pour le slider
            slider.value = Mathf.Pow(10, currentVolume / 20);
        }
        else
        {
            Debug.Log("Paramètre non trouvé dans l'AudioMixer.");
        }
    }

    private void SetVolume(string parameterName, float sliderValue)
    {
        // Convertir la valeur du slider (0 à 1) en dB (-80 à 0)
        float dB = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1)) * 20;
        audioMixer.SetFloat(parameterName, dB);
    }
}