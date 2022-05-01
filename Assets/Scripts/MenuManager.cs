using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;

    private void Start()
    {
        string pName = DataManager.Instance.GetName();
        if (pName != null)
        {
            _inputField.text = pName;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void UpdateName(string playerName)
    {
        DataManager.Instance.SetName(playerName);
    }
    
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
