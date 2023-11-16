using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this to use the TextMeshPro namespace
using UnityEngine.UI; // Add this to use the UI namespace for buttons
using System;
using System.Linq;

public class EditCardPopup : MonoBehaviour
{
    public Button button1; // Reference to the first button
    public Button button2; // Reference to the second button
    public Button button3; // Reference to the third button
    public Button button4; // Reference to the fourth button
    public Button button5;
    public string[,] evidence;
    /*
    public string[] guiltyEvidenceName = new string[21];
    public string[,] guiltyEvidenceDescription = new string[21, 3];
    public string[] innocentEvidenceName = new string[21];
    public string[,] innocentEvidenceDescription = new string[21, 3];
    */
    public string[] guiltyEvidenceName;
    public string[] guiltyEvidenceDescription;
    public string[] innocentEvidenceName;
    public string[] innocentEvidenceDescription;
    public bool guilty;
    VerdictScript verdictScript;
    public bool verdict;
    public bool evidenceSelected;
    


    public TextMeshProUGUI textMeshPro; // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI textMeshProTitle;

    void Start()
    {
        // Register onClick events for the buttons to call the UpdateText function with different parameters


        guilty = true;
        evidence = new string[5, 2];
        verdictScript = GetComponent<VerdictScript>();
        guiltyEvidenceName = new string[3] { "Knife", "Doll", "Dead Cat" };
        guiltyEvidenceDescription = new string[3] { "This knife with a twisted blade with dark engravings was found with the suspect at the time of arrest.",
                            "The doll has drops of blood and multiple stab marks.", "This cat is a perfect representation of the devil's work."};
        innocentEvidenceName = new string[5] { "Knife", "Poultice", "Missing Livestock", "Church Attendance", "Occupation" };
        innocentEvidenceDescription = new string[5] { "This knife was discovered hidden underneath the floorboards wrapped in deer skin.",
                            "Natural remedies may be a mark of the antichrist.", "They are accused of being vegetarian and having a box full of chicken feet.",
                            "Luke-warm Christian. Poser.", "Schizofrenic"};
        SelectEvidence();
        evidenceSelected = true;
        
        button1.onClick.AddListener(delegate { UpdateText(evidence[0, 1], evidence[0, 0]); });
        button2.onClick.AddListener(delegate { UpdateText(evidence[1, 1], evidence[1, 0]); });
        button3.onClick.AddListener(delegate { UpdateText(evidence[2, 1], evidence[2, 0]); });
        button4.onClick.AddListener(delegate { UpdateText(evidence[3, 1], evidence[3, 0]); });
        button5.onClick.AddListener(delegate { UpdateText(evidence[4, 1], evidence[4, 0]); });

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
    private void Update()
    {
        if (!evidenceSelected)
        {
            SelectEvidence();
            evidenceSelected = true;

        }
    }
    
    public void SelectEvidence()
    {

        
        //determine whether accused is guilty or not
        System.Random rand = new System.Random();
        int isGuilty = rand.Next() % 2;
        if (isGuilty == 0)
        {
            guilty = false;
        }
        else
        {
            guilty = true;
        }

        //pick number of pieces of guilty and innocent evidence based on guilty boolean
        //System.Random numGuiltyPieces = new System.Random();
        //System.Random numInnocentPieces = new System.Random();
        System.Random guiltyIndex = new System.Random();
        //System.Random innocentIndex = new System.Random();
        string[] tempGuiltyName;
        string[] tempGuiltyDesc;
        string[] tempInnName;
        string[] tempInnDesc;




        if (guilty)
        {
            tempGuiltyName = new string[3];
            tempGuiltyDesc = new string[3];

            for (int i = 0; i < 3; i++)
            {
                int gIndex = guiltyIndex.Next() % 3;
                string gName = guiltyEvidenceName[gIndex];
                string gDesc = guiltyEvidenceDescription[gIndex];
                if (tempGuiltyName.Contains(gName))
                {
                    i--;
                }
                else
                {
                    tempGuiltyName[i] = gName;
                    tempGuiltyDesc[i] = gDesc;

                }
            }

            tempInnName = new string[2];
            tempInnDesc = new string[2];
            for (int i = 0; i < 2; i++)
            {
                int iIndex = guiltyIndex.Next() % 5;
                string iName = innocentEvidenceName[iIndex];
                string iDesc = innocentEvidenceDescription[iIndex];
                if (tempInnName.Contains(iName) || tempGuiltyName.Contains(iName))
                {
                    i--;
                }
                else
                {
                    tempInnName[i] = iName;
                    tempInnDesc[i] = iDesc;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                (evidence[i, 0], evidence[i, 1]) = (tempGuiltyName[i], tempGuiltyDesc[i]);

                if (i < 2)
                {
                    (evidence[3 + i, 0], evidence[3 + i, 1]) = (tempInnName[i], tempInnDesc[i]);
                }
            }
        }
        else
        {
            int numGuilty = guiltyIndex.Next() % 3;
            tempGuiltyName = new string[numGuilty];
            tempGuiltyDesc = new string[numGuilty];

            for (int i = 0; i < numGuilty; i++)
            {
                int gIndex = guiltyIndex.Next() % 3;
                string gName = guiltyEvidenceName[gIndex];
                string gDesc = guiltyEvidenceDescription[gIndex];
                if (tempGuiltyName.Contains(gName))
                {
                    i--;
                }
                else
                {
                    tempGuiltyName[i] = gName;
                    tempGuiltyDesc[i] = gDesc;

                }
            }

            tempInnName = new string[5 - numGuilty];
            tempInnDesc = new string[5 - numGuilty];
            for (int i = 0; i < 5-numGuilty; i++)
            {
                int iIndex = guiltyIndex.Next() % 5;
                string iName = innocentEvidenceName[iIndex];
                string iDesc = innocentEvidenceDescription[iIndex];
                if (tempInnName.Contains(iName) || tempGuiltyName.Contains(iName))
                {
                    i--;
                }
                else
                {
                    tempInnName[i] = iName;
                    tempInnDesc[i] = iDesc;
                }
            }

            for (int i = 0; i < 5-numGuilty; i++)
            {
                (evidence[i, 0], evidence[i, 1]) = (tempInnName[i], tempInnDesc[i]);

                if (i < numGuilty)
                {
                    (evidence[3 + i, 0], evidence[3 + i, 1]) = (tempGuiltyName[i], tempGuiltyDesc[i]);
                }
            }
        }


        int count = 5;
        System.Random shuffleIndex = new System.Random();
        while (count > 1)
        {
            int i = shuffleIndex.Next(count--);
            (evidence[i,0], evidence[count,0]) = (evidence[count,0], evidence[i,0]);
            (evidence[i, 1], evidence[count, 1]) = (evidence[count, 1], evidence[i, 1]);
        }
    }
}
