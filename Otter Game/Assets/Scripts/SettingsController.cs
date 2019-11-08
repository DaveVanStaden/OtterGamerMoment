using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public float SetMaxScore = 40;

    /// <summary>
    /// This script is made for the options menu in the main menu.
    /// it is used to set the max score, volume, game speed and object size.
    /// Everything is fully cusomizable.
    /// </summary>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetScore(string MaximalScore)
    {
        SetMaxScore = float.Parse(MaximalScore);
        print(SetMaxScore);
        StaticVariable.MaxScore = SetMaxScore;
    }
    public void IncreaseSpeed()
    {
        StaticVariable.SpawnSpeed -= 1f;
        StaticVariable.MovementSpeedSpawner += 1;
        print(StaticVariable.ObjectSize);
    }
    public void DecreaseSpeed()
    {
        StaticVariable.SpawnSpeed += 1f;
        StaticVariable.MovementSpeedSpawner -= 1;
        print(StaticVariable.ObjectSize);
    }
    public void SetSize(int sizeIndex)
    {
        print(sizeIndex);
        StaticVariable.ObjectSize = sizeIndex;
    }
    public void IncreaseSize()
    {
        StaticVariable.ObjectSize += 0.1f;
        print(StaticVariable.ObjectSize);
    }
    public void DecreaseSize()
    {
        StaticVariable.ObjectSize -= 0.1f;
        print(StaticVariable.ObjectSize);
    }
}