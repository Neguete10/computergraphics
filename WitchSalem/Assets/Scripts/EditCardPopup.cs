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
    public string[,] guiltyEvidence;
    //public string[] guiltyEvidenceDescr;
    public string[,] innocentEvidence;
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
        guiltyEvidence = new string[28,2] { { "Knife", "This knife with a twisted blade with dark engravings was found with the suspect at the time of arrest." },
                                                { "Doll", "The doll has drops of blood and multiple stab marks." },
                                                { "Dead Cat", "This cat is a perfect representation of the devil's work." },
                                                { "Gun", "This gun survived their house fire without a mark." },
                                                { "Diary", "One of the pages of this diary describes sleeping in the town cemetery." },
                                                { "Doll", "This doll was found burried in their backyard." },
                                                { "Dead Cat", "The suspect is accused of eating his neighbor's white cat." },
                                                { "Broken Cross", "Last time this happened the township was hit by a tornado." },
                                                { "Blue Necklace", "The mark of a harlot." },
                                                { "Blue Necklace", "Accusers say this necklace causes married women to kill their spouses." },
                                                { "Nightmares", "Half of the town claims to have had dreams that the accused eats children." },
                                                { "Household Immunity", "The children of the accused were untouched by the sickness that killed many children." },
                                                { "Eye-Witness", "Bartholomew witnessed them arguing with the reverend's wife after church." },
                                                { "Missing Livestock", "They are accused of being vegetarian and having a box full of chicken feet." },
                                                { "Missing Livestock", "The mayor's horse was found dead in front of the house of the accused." },
                                                { "Candles", "They claim that candles \"smell good\"." },
                                                { "Sleepwalks", "The sheriff caught them walking towards the vineyard at 3am and they gave no explanation." },
                                                { "Sleepwalks", "Their daughter sees them standing in the fireplace every night but they are unharmed by the flames." },
                                                { "Church Attendance", "They skip church every full-moon." },
                                                { "Dead Family Member", "Their father died after choking on a carrot bone. Carrots don't have bones." },
                                                { "Dead Family Member", "Their youngest son was found in the woods eaten by wolves. Sacrifice to the sons of Satan?" },
                                                { "Occupation", "Schizophrenic" },
                                                { "Occupation", "Woman" },
                                                { "Book", "This book's cover was tested and inspected! It was human-skin." },
                                                { "Nationality", "French" },
                                                { "Nationality", "English" },
                                                { "Nationality", "Brazilian" },
                                                { "Nationality", "Jamaican" } };
        innocentEvidence = new string[44,2] { { "Knife", "This knife was discovered hidden underneath the floorboards wrapped in deer skin." },
                                                { "Knife", "This bone-handled knife was often carried by the suspect." },
                                                { "Gun", "This gun was made by an unknown manufacturer." },
                                                { "Gun", "This gun has a symbol on the handle and has been in the family for generations." },
                                                { "Diary", "This diary does not have dates written on each page." },
                                                { "Diary", "This diary has a strange language written in it." },
                                                { "Doll", "This doll looks very similar to their sister." },
                                                { "Rope", "The accused was in possession of this noose that was used to execute their grandfather for murder." },
                                                { "Rope", "This rope was used to hang a skinned pig in the woods." },
                                                { "Rope", "The rope shows unusual marks of wear." },
                                                { "Dead Cat", "Their family cat was discovered on the steps of the church with the skin inside out." },
                                                { "Dead Cat", "This cat was owned by the accused and bit townspeople on many occasions." },
                                                { "Poultice", "Herbs and spices should not be put on open wounds. People are not food." },
                                                { "Poultice", "Natural remedies may be a mark of the antichrist." },
                                                { "Poultice", "Unknown Foreigners brought this dark magic into town." },
                                                { "Broken Cross", "This denies the holy doctrine" },
                                                { "Broken Cross", "Jesus did not die for heretics." },
                                                { "Blue Necklace", "No, it is NOT the titanic one. Titanic hasn't happened yet." },
                                                { "Nightmares", "The accused shares openly that they dream of dead people." },
                                                { "Nightmares", "The reverend claims that nightmares are a sign of coming judgement for harboring witches in the town." },
                                                { "Household Immunity", "All of their neighbors pigs mysteriously died, but only one of the accused goats died." },
                                                { "Household Immunity", "Even the plague did not dare to enter this person's house and partake on their table." },
                                                { "Eye-Witness", "Jerry, the dentist, saw abnormal levels of blood in their mouth." },
                                                { "Eye-Witness", "Camila, the housekeeper, claims to have seen this person eating weird food." },
                                                { "Missing Livestock", "Their cattle have reduced drastically in the last month due to unknown circumstances." },
                                                { "Candles", "They have a colorful circle of candles around their house." },
                                                { "Candles", "They have never changed a single candle on their front porch and the wick is never burnt." },
                                                { "Sleepwalks", "They only sleepwalk at night. Sleepwalking in the day is less ominous." },
                                                { "Church Attendance", "Luke-warm Christian. Poser." },
                                                { "Church Attendance", "Devout follower of Jesus Christ our savior. Never missed a service." },
                                                { "Dead Family Member", "Their uncle Ruckus was sentenced to death 4 springs ago. Ruckus was a witch." },
                                                { "Occupation", "Butcher" },
                                                { "Occupation", "Blacksmith" },
                                                { "Occupation", "Writer" },
                                                { "Occupation", "Barber" },
                                                { "Occupation", "Doctor" },
                                                { "Occupation", "Roofer" },
                                                { "Occupation", "Seamstress" },
                                                { "Book", "A book was found in their house and was written in an unrecognizable language." },
                                                { "Book", "Bloody feathers were found stamped inside the front cover." },
                                                { "Nationality", "Dutch" },
                                                { "Nationality", "Mexican" },
                                                { "Nationality", "American" },
                                                { "Nationality", "African" } };

        //innocentEvidenceName = new string[42,2] { "Knife", "Poultice", "Missing Livestock", "Church Attendance", "Occupation" };
        //innocentEvidenceDescription = new string[5] { "This knife was discovered hidden underneath the floorboards wrapped in deer skin.",
        //                    "Natural remedies may be a mark of the antichrist.", "They are accused of being vegetarian and having a box full of chicken feet.",
        //                    "Luke-warm Christian. Poser.", "Schizophrenic"};
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
                int gIndex = guiltyIndex.Next() % 28;
                string gName = guiltyEvidence[gIndex,0];
                string gDesc = guiltyEvidence[gIndex,1];
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
                int iIndex = guiltyIndex.Next() % 44;
                string iName = innocentEvidence[iIndex,0];
                string iDesc = innocentEvidence[iIndex,1];
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
                int gIndex = guiltyIndex.Next() % 28;
                string gName = guiltyEvidence[gIndex,0];
                string gDesc = guiltyEvidence[gIndex,1];
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
                int iIndex = guiltyIndex.Next() % 44;
                string iName = innocentEvidence[iIndex,0];
                string iDesc = innocentEvidence[iIndex,1];
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
