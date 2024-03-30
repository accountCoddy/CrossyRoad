using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private int _scoreRecord;

    void Start()
    {

    }

    public void Save(float saveValue, string saveName)
    {
        PlayerPrefs.SetFloat(saveName, saveValue);
        PlayerPrefs.Save();
    }
    public void Save(int saveValue, string saveName)
    {
        PlayerPrefs.SetInt(saveName, saveValue);
        PlayerPrefs.Save();
    }
    public void Save(string saveValue, string saveName)
    {
        PlayerPrefs.SetString(saveName, saveValue);
        PlayerPrefs.Save();
    }


    public float LoadFloat(string saveNane)
    {
        return PlayerPrefs.GetFloat(saveNane);
    }

    public int LoadInt(string saveNane)
    {
        return PlayerPrefs.GetInt(saveNane);
    }

    public string LoadString(string saveNane)
    {
        return PlayerPrefs.GetString(saveNane);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
