using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to use the TextMeshPro namespace
using UnityEngine.UI; // Add this to use the UI namespace for buttons

public class EditCardPopup : MonoBehaviour
{
    public Button button1; // Reference to the first button
    public Button button2; // Reference to the second button
    public Button button3; // Reference to the third button
    public Button button4; // Reference to the fourth button

    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI textMeshProTitle;

    void Start()
    {
        // Register onClick events for the buttons to call the UpdateText function with different parameters

        button1.onClick.AddListener(delegate { UpdateText("Button 1 was clicked", "#1"); });
        button2.onClick.AddListener(delegate { UpdateText("Button 2 was clicked", "#2"); });
        button3.onClick.AddListener(delegate { UpdateText("Button 3 was clicked", "#3"); });
        button4.onClick.AddListener(delegate { UpdateText("Button 4 was clicked", "#4"); });

    }

    // This function updates the text of the TextMeshPro object
    void UpdateText(string message, string number)
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = message;
            textMeshProTitle.text = number;
        }
        else
        {
            Debug.LogError("TextMeshPro component not set in the inspector");
        }
    }

    // Update is not needed unless there's logic to be processed every frame
}
