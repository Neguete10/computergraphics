using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CharacterSelection : MonoBehaviour
{

    VerdictScript verdictScript;
    bool verdict;
    public bool charSelected;
    public GameObject brute;
    public GameObject peasantMan;
    public GameObject peasantGirl;
    public GameObject[] characters;
    public int oldCharacter1Index;
    public int oldCharacter2Index;
    //public GameObject oldCharacter;

    // Start is called before the first frame update
    void Start()
    {
        verdictScript = GetComponent<VerdictScript>();
        charSelected = true;
        //brute.SetActive(false);
        //peasantMan.SetActive(false);
        //peasantGirl.SetActive(false);
        characters = new GameObject[3] { brute, peasantMan, peasantGirl };
        //oldCharacter = new GameObject();
        oldCharacter1Index = -1;
        oldCharacter2Index = -1;

        SelectCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        if (!charSelected)
        {
            Debug.Log(charSelected + "in char selection");
            SelectCharacter();
            charSelected = true;
        }
    }

    void SelectCharacter()
    {
        //Debug.Log(charSelected);
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].SetActive(false);
        }
        
        System.Random rand = new System.Random();
        int newCharacter;
        for (int i = 0; i < 1; i++)
        {
            newCharacter = rand.Next() % characters.Length;
            if (newCharacter == oldCharacter1Index || newCharacter == oldCharacter2Index)
            {
                i--;
            }
            else
            {

                //Debug.Log("2nd run");
                //oldCharacter.SetActive(false);
                //oldCharacter = characters[newCharacter];
                //oldCharacter.SetActive(true);
                characters[newCharacter].SetActive(true);
                oldCharacter2Index = oldCharacter1Index;
                oldCharacter1Index = newCharacter;
                
            }
        }
        //Debug.Log(characters.Length);
    }
}
