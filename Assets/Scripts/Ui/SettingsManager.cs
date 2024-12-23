using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject canvasSettings;

    public void ToggleCanvas(bool flag)
    {
        canvasSettings.SetActive(flag);
    }
}
