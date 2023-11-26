using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VerdictBtnUI : MonoBehaviour
{
   //public GameObject guiltyBtn;
   //public GameObject notGuiltyBtn;
   public GameObject testBtn;

    // This method toggles the active state of the second button
    public void ToggleButton()
    {
        //guiltyBtn.SetActive(!guiltyBtn.activeSelf);
        //notGuiltyBtn.SetActive(!notGuiltyBtn.activeSelf);
        testBtn.SetActive(!testBtn.activeSelf);
    }
}


