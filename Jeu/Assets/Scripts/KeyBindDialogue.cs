using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBindDialogue : MonoBehaviour
{
    InputManager inputManager;
    public GameObject keyItemPrefab;
    public GameObject keyList;

    string buttonToRebind = null;
    Dictionary <string, Text> buttonToLabel;
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        
        string[] buttonNames = inputManager.GetButtonNames();

        buttonToLabel = new Dictionary<string, Text>();
        
        //foreach(string bn in buttonNames)
        for(int i = 0; i < buttonNames.Length; i++)
        {
           string bn;
           bn = buttonNames[i];
           GameObject go = (GameObject)Instantiate(keyItemPrefab);
           go.transform.SetParent(keyList.transform);
           go.transform.localScale = Vector3.one;

           Text buttonNameText = go.transform.Find("Button Name").GetComponent<Text>();
           buttonNameText.text = bn;
           
           Text KeyNameText = go.transform.Find("Button/Key Name").GetComponent<Text>();
           KeyNameText.text = inputManager.GetKeyNameForButton(bn);
           buttonToLabel[bn] = KeyNameText;


           Button keyBindButton = go.transform.Find("Button").GetComponent<Button>();
           keyBindButton.onClick.AddListener(() => {StartRebindfor(bn);});
        }
    }

    
    void Update()
    {
        if(buttonToRebind != null)
        {
            if(Input.anyKeyDown)
            {
               
               foreach(KeyCode kc in Enum.GetValues(typeof(KeyCode)))
               {
                   if(Input.GetKeyDown(kc))
                   {
                       inputManager.SetButtonForKey(buttonToRebind, kc);
                       buttonToLabel[buttonToRebind].text = kc.ToString();
                       buttonToRebind = null;
                       break;
                   }
               }
            }
        }
    }


    void StartRebindfor(string buttonName)
    {
        Debug.Log("StartRebindFor" + buttonName);

        buttonToRebind = buttonName;
    }
}
