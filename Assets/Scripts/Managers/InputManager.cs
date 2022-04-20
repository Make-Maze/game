using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public LoadJson loadJson;
    public TMP_InputField myInputField;
    // Start is called before the first frame update
    void Start()
    {
        loadJson = GameObject.Find("MapDataBase").GetComponent<LoadJson>();
        myInputField.onEndEdit.AddListener(ValueChanged);
    }
    public void ValueChanged(string text)
    {
        Debug.Log(text);
        loadJson.PlayerEMail=text;
    }
}
