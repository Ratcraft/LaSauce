using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    void OnEnable()
    {
        buttonKeys = new Dictionary<string, KeyCode>();
        buttonKeys["Jump"] = KeyCode.Space;
        buttonKeys["Hit"] = KeyCode.F;
        buttonKeys["Grab"] = KeyCode.Mouse0;
        //buttonKeys["left"] = KeyCode.A;
        //buttonKeys["right"] = KeyCode.D;
    }
    Dictionary<string, KeyCode> buttonKeys;
    
    void Start()
    {
        
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetButtonDown(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButtonDown -- No");
            return false;
        }
        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public string[] GetButtonNames()
    {
        return buttonKeys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if(buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetKeyNameForButton -- No button named: " + buttonName);
            return "N/A";
        }
        return buttonKeys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keyCode)
    {
        buttonKeys[buttonName] = keyCode;
    }
}
