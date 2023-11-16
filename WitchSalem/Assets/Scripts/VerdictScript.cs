using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this to use the UI namespace for buttons

public class VerdictScript : MonoBehaviour
{
    public bool verdictSelected = false;
    public int deadInnocent = 0;
    public int aliveGuilty = 0;
    public Button guilty;
    public Button innocent;
    EditCardPopup card;
    CharacterSelection charSelect;
    // Start is called before the first frame update
    void Start()
    {
        verdictSelected = false;
        guilty.onClick.AddListener(delegate { VerdictSelected("guilty"); });
        innocent.onClick.AddListener(delegate { VerdictSelected("innocent"); });
        card = GetComponent<EditCardPopup>();
        charSelect = GetComponent<CharacterSelection>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void VerdictSelected(string innocentOrGuilty)
    {
        if (innocentOrGuilty == "guilty" && !card.guilty) //activate sound for guilty "FETCH ME THEIR SOULS"
        {
            deadInnocent++;
            
        }
        else if (innocentOrGuilty == "innocent" && card.guilty) //activate some goofy sound
        {
            aliveGuilty++;
            
        }

        verdictSelected = true;
        card.evidenceSelected = false;
        charSelect.charSelected = false;
        Debug.Log("evidence" + card.evidenceSelected);
        Debug.Log("char select" + charSelect.charSelected);
    }
}
