using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Coffee
{

    public class Popup : MonoBehaviour
    {

        public TMP_Text popupText1, popupText2, titleText, salesText;
        public string text1, text2;

       void Start() {
            popupText1.enabled = false;
            popupText2.enabled = false;
        }

        public void OnPointerEnter()
        {
            popupText1.text = text1;
            popupText2.text = text2.Replace("\\n", "\n");
            salesText.enabled = false;
            titleText.enabled = false;
            popupText1.enabled = true;
            popupText2.enabled = true;
            Debug.Log("Enter"+text1);
        }

        public void OnPointerExit()
        {
            Debug.Log(text1);
            salesText.enabled = true;
            titleText.enabled = true;
            popupText1.enabled = false;
            popupText2.enabled = false;

        }

       


    }
}
