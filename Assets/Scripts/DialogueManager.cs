using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;
using System;
using System.Net;
using UnityEngine.U2D;

public class DialogueManager : MonoBehaviour
{

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Image profPic;

    public GameObject dialogueChoices;
    public Button choice1;
    public Button choice2;
    public Button choice3;

    public GameObject characterChoice;
    public Button blobButton;
    public Button axoButton;
    public Button slugButton;
    public bool blobTalk = false;
    public bool axoTalk = false;
    public bool slugTalk = false;

    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;

    public Animator animator;

    private Queue<string> sentences;

    public int nodeCtr = 0;

    public Dialogue currDialogue;

    // Use this for initialization
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        //int n = 4;
        Dialogue root = new Dialogue(1, "Rock", "I am Dwayne Johnson",1);
        root.sentences[0] = new Dialogue(1, "", "Plop.", 0);
        root.sentences[0].sentences[0] = new Dialogue(1, "Rocky", "...", 1);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Where am I ?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "Oh, there you are!", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I'm sorry, who are you?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "...We're students at the University of the Seas—or U Sea, as they call it around here.", 4);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "You must be the transfer student!", 3);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "...the what?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Your eyes swivel to the outside, and it dawns on you that you’re in an aquarium tank.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(3, "???", "The clamcellor told us we’d have a new transfer student! You must be the one!", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Yup, that’s me! Nice to meet you!", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "I don’t know what you’re talking about...", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[2] = new Dialogue(1, "Rocky", "I’m just a rock...I don’t think I belong here.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "Nice to meet you too! My name’s Axolola, by the way.", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "???", "Nonsense, we’re glad to have you here! You can call me Sluglie, darling.", 3);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "???", "Well, the clamcellor did say that the university would be broadening its diversity recruitment efforts...and I’m Blobert. Pleased to make your acquaintance.", 4);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "Well I’ve got nothing else going for me... I might as well be a student here!", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "???", "Well I’ve got nothing else going for me... I might as well be a student here!", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "???", "Well I’ve got nothing else going for me... I might as well be a student here!", 1);


        //foreach (string sentence in dialogue.sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}



        DisplayNextSentence();
        currDialogue = root;
    }

    public void DisplayNextSentence()
    {
        characterChoice.SetActive(false);
        if (currDialogue.sentences.Length == 0 || currDialogue.sentences == null)
        {
             return;
        }
        if (currDialogue.sentences.Length > 1 || currDialogue.sentences.Length == 0)
        {
            EndDialogue();
            dialogueChoices.SetActive(true);
            if (currDialogue.sentences.Length == 2)
            {
                choice3.gameObject.SetActive(false);
                choice1.GetComponentInChildren<TMP_Text>().text = currDialogue.sentences[0].dialogue;
                choice2.GetComponentInChildren<TMP_Text>().text = currDialogue.sentences[1].dialogue;
                nameText.text = currDialogue.sentences[0].name;
            }
            else
            {
                choice3.gameObject.SetActive(true);
                choice1.GetComponentInChildren<TMP_Text>().text = currDialogue.sentences[0].dialogue;
                choice2.GetComponentInChildren<TMP_Text>().text = currDialogue.sentences[1].dialogue;
                choice3.GetComponentInChildren<TMP_Text>().text = currDialogue.sentences[2].dialogue;
                nameText.text = currDialogue.sentences[0].name;
            }
            
            StopAllCoroutines();
            Debug.Log("i am not here" + currDialogue.sentences.Length);
        }
        else
        {
            Debug.Log("i am here" + currDialogue.sentences.Length);
            dialogueChoices.SetActive(false);
            animator.SetBool("IsOpen", true);
            nameText.text = currDialogue.sentences[0].name;
            switch(currDialogue.sentences[0].id)
            {
                case 0:
                    profPic.GetComponent<Image>().sprite = Resources.Load<Sprite>("");
                    break;
                case 1:
                    profPic.GetComponent<Image>().sprite = sprite1;
                    break;
                case 2:
                    profPic.GetComponent<Image>().sprite = sprite2;
                    break;
                case 3:
                    profPic.GetComponent<Image>().sprite = sprite3;
                    break;
                case 4:
                    profPic.GetComponent<Image>().sprite = sprite4;
                    break;
            }
            

            StopAllCoroutines();
            StartCoroutine(TypeSentence(currDialogue.sentences[0].dialogue));
            if (currDialogue.sentences[0].dialogue == "Well I’ve got nothing else going for me... I might as well be a student here!")
            {
                TalktoChars();
            }
            else
            {
                currDialogue = currDialogue.sentences[0];
            }
        }
        //if (sentences.Count == 0)
        //{
        //    EndDialogue();
        //    return;
        //}

        //string sentence = sentences.Dequeue();
        //StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
    
    public void OnOption1Click()
    {
        currDialogue = currDialogue.sentences[0];
        DisplayNextSentence();
    }

    public void OnOption2Click() 
    {
        currDialogue = currDialogue.sentences[1];
        DisplayNextSentence();
    }
    public void OnOption3Click() 
    {
        currDialogue = currDialogue.sentences[2];
        DisplayNextSentence();
    }

    public void TalktoChars()
    {
        animator.SetBool("IsOpen", false);
        dialogueChoices.SetActive(false);
        characterChoice.SetActive(true);
        if(slugTalk)
            slugButton.gameObject.SetActive(false);
        if (axoTalk)
            axoButton.gameObject.SetActive(false);
        if (blobTalk)
            blobButton.gameObject.SetActive(false);
    }

    public void axoTedTalk()
    {
        Dialogue root = new Dialogue(1, "", "Tomorrow’s the big swim match against Ocean Institute.", 0);
        root.sentences[0] = new Dialogue(1, "", "You hear that Axolola, the team captain, will not be participating due to an injury sustained from crashing into the aquarium glass.", 0);
        root.sentences[0].sentences[0] = new Dialogue(2, "", "She sadly floats around the tank as she sees her teammates getting ready for the swim meet.", 0);

        root.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, want to go get some food? It might make you feel better.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Yeah, that’d be a good idea! Let’s go get some larva pizza; it’s my favorite food.!", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "There’s a large turnout at the campus movie event for Bass Lives. It’s a sad movie, and you notice Axolola crying next to you.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Are you alright?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(2, "Axolola", "It’s just so sad! I can’t believe they don’t end up together!", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Right? They’re so perfect for each other.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You pass her a piece of kelp to wipe her tears. She’s grateful for your act of kindness.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Thanks a lot, Rocky! Did you know that ‘axolotl’ means ‘water monster’ in Nahuatl? I hope I don’t come off as too scary!", 2);


        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Come on, it’s just a movie.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Axolola", "Oh, ok. I’m sorry.", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "She sniffles quietly and is silent for the rest of the movie.", 0);


        root.sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Come on, don’t be sad. At least you can still swim.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Axolola", "I guess you’re right...", 2);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(2, "", "She looks down, avoiding eye contact with you.", 0);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Why don’t we practice some light exercises together? That way you can start building your strength up as you recover.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Yeah, that’d be a good idea! And after this, we could get some larva pizza. It’s my favorite food!”", 2);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "There’s a large turnout at the campus movie event for Bass Lives. It’s a sad movie, and you notice Axolola crying next to you.", 0);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, do you mind? I’m trying to watch a movie here.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Oh, ok. I’m sorry.", 2);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "She sniffles quietly and is silent for the rest of the movie.", 0);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(2, "", "You hear Axolola’s belly rumble. You realize she didn’t get anything to eat earlier.", 0);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, do you want to share my popcorn? It’s too large for me to finish by myself.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "I actually haven’t eaten all day, so this means so much to me! ‘Axolotl’ means ‘water monster’ in Nahuatl, and my appetite definitely lives up to that, haha.", 2);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Hey, The popcorn here is really good! I would recommend you grab some next time", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Axolola looks confused and a little hurt.", 0);



        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "It’s not that bad! I don’t even qualify for the swim team, so you should be lucky.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Axolola", "You do have a point...I guess it’s not fair for me to mope about it.", 2);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "There’s a large turnout at the campus movie event for Bass Lives. It’s a sad movie, and you notice Axolola crying next to you.", 0);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, do you mind? I’m trying to watch a movie here.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Oh, ok. I’m sorry.", 2);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "She sniffles quietly and is silent for the rest of the movie.", 0);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(2, "", "You hear Axolola’s belly rumble. You realize she didn’t get anything to eat earlier.", 0);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, do you want to share my popcorn? It’s too large for me to finish by myself.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "I actually haven’t eaten all day, so this means so much to me! ‘Axolotl’ means ‘water monster’ in Nahuatl, and my appetite definitely lives up to that, haha.", 2);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Hey, The popcorn here is really good! I would recommend you grab some next time", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Axolola looks confused and a little hurt.", 0);


        currDialogue = root;
        DisplayNextSentence();
    }
}   