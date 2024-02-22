using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;
using System;
using System.Net;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

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
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "...We're students at the University of the Seas—or U Sea, as they call it around here.", 3);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "???", "You must be the transfer student!", 4);
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
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Who would you like to learn more about?", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Who would you like to learn more about?", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Who would you like to learn more about?", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END", 1);

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
            if (currDialogue.sentences[0].dialogue == "END" || currDialogue.sentences[0].dialogue == "END1" )
            {
                if (blobTalk && axoTalk && slugTalk)
                {
                    DateTime();
                }
                else
                {
                    TalktoChars();
                    blobButton.onClick.RemoveAllListeners();
                    axoButton.onClick.RemoveAllListeners();
                    slugButton.onClick.RemoveAllListeners();
                    blobButton.onClick.AddListener(() => blobTedTalk());
                    axoButton.onClick.AddListener(() => axoTedTalk());
                    slugButton.onClick.AddListener(() => slugTedTalk());
                    if (blobTalk)
                        blobButton.gameObject.SetActive(false);
                    if (axoTalk)
                        axoButton.gameObject.SetActive(false);
                    if (slugTalk)
                        slugButton.gameObject.SetActive(false);
                }
            }
            else if(currDialogue.sentences[0].dialogue == "END2")
            {
                TalktoChars();
                blobButton.gameObject.SetActive(true);
                axoButton.gameObject.SetActive(true);
                slugButton.gameObject.SetActive(true);
                blobButton.onClick.RemoveAllListeners();
                axoButton.onClick.RemoveAllListeners();
                slugButton.onClick.RemoveAllListeners();
                blobButton.onClick.AddListener(() => blobDate());
                axoButton.onClick.AddListener(() => axoDate());
                slugButton.onClick.AddListener(() => slugDate());
            }
            else if(currDialogue.sentences[0].dialogue == "DEAD")
            {
                SceneManager.LoadScene("MainMenu");
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
        axoTalk = true;
        Dialogue root = new Dialogue(1, "", "Tomorrow’s the big swim match against Ocean Institute.", 0);
        root.sentences[0] = new Dialogue(1, "", "You hear that Axolola, the team captain, will not be participating due to an injury sustained from crashing into the aquarium glass.", 0);
        root.sentences[0].sentences[0] = new Dialogue(2, "", "She sadly floats around the tank as she sees her teammates getting ready for the swim meet.", 0);

        root.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, want to go get some food? It might make you feel better.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Yeah, that’d be a good idea! Let’s go get some larva pizza; it’s my favorite food.!", 2);




        root.sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Come on, don’t be sad. At least you can still swim.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Axolola", "I guess you’re right...", 2);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(2, "", "She looks down, avoiding eye contact with you.", 0);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Why don’t we practice some light exercises together? That way you can start building your strength up as you recover.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Yeah, that’d be a good idea! And after this, we could get some larva pizza. It’s my favorite food!”", 2);
        




        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "It’s not that bad! I don’t even qualify for the swim team, so you should be lucky.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Axolola", "You do have a point...I guess it’s not fair for me to mope about it.", 2);


        Dialogue cont = new Dialogue(2, "", "There’s a large turnout at the campus movie event for Bass Lives. It’s a sad movie, and you notice Axolola crying next to you.", 0);

        cont.sentences[0] = new Dialogue(1, "Rocky", "Are you alright?", 1);
        cont.sentences[0].sentences[0] = new Dialogue(2, "Axolola", "It’s just so sad! I can’t believe they don’t end up together!", 2);

        cont.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Right? They’re so perfect for each other.", 1);
        cont.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You pass her a piece of kelp to wipe her tears. She’s grateful for your act of kindness.", 0);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Thanks a lot, Rocky! Did you know that ‘axolotl’ means ‘water monster’ in Nahuatl? I hope I don’t come off as too scary!", 2);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);


        cont.sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Come on, it’s just a movie.", 1);
        cont.sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Axolola", "Oh, ok. I’m sorry.", 2);
        cont.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "She sniffles quietly and is silent for the rest of the movie.", 0);
        cont.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);

        cont.sentences[1] = new Dialogue(1, "Rocky", "Hey, do you mind? I’m trying to watch a movie here.", 1);
        cont.sentences[1].sentences[0] = new Dialogue(1, "Axolola", "Oh, ok. I’m sorry.", 2);
        cont.sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "She sniffles quietly and is silent for the rest of the movie.", 0);
        cont.sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You hear Axolola’s belly rumble. You realize she didn’t get anything to eat earlier.", 0);
        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(2, "", "You hear Axolola’s belly rumble. You realize she didn’t get anything to eat earlier.", 0);

        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Hey, do you want to share my popcorn? It’s too large for me to finish by myself.", 1);
        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "I actually haven’t eaten all day, so this means so much to me! ‘Axolotl’ means ‘water monster’ in Nahuatl, and my appetite definitely lives up to that, haha.", 2);
        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);

        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "The popcorn here is really good! I would recommend you grab some next time.", 1);
        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Axolola looks confused and a little hurt.", 0);
        cont.sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);



        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = cont;




        currDialogue = root;
        DisplayNextSentence();
    }

    public void blobTedTalk()
    {
        blobTalk = true;
        Dialogue root = new Dialogue(1, "", "", 0);
        root.sentences[0] = new Dialogue(1, "", "You find yourself at a local student party. The drinks are pouring, and the bass is trembling. Not the sound system, but the fish. He’s rather anxious.", 0);
        root.sentences[0].sentences[0] = new Dialogue(1, "", "Out of the corner of your eye, you see Blobert approaching you.", 0);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(3, "Blobert", "It’s so lonely here...", 3);

        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I feel you; it’s a bit lonely being the only rock here.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Blobert smiles and begins to look more at ease now.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "You know, the depths that I call home typically range from 6,000 to 12,000 meters below water. You could say I truly feel like a fish out of water here!", 3);

        root.sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Lonely...how so?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(2, "Blobert", "I’m actually an international student, I’m from Australia. There’s no other fishes from there here...", 3);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "To be honest, I don’t know how I ended up here either.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Blobert smiles and begins to look more at ease now.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "You know, the depths that I call are home typically range from 6,000 to 12,000 meters below water. You could say I truly feel like a fish out of water!", 3);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "That can’t possibly be true!", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Blobert begins to look sad, and awkwardly swims to a corner.", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[2] = new Dialogue(1, "Rocky", "Blankly nod.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Blobert begins to look sad, and awkwardly swims to a corner.", 0);

        Dialogue cont = new Dialogue(1, "", "Time passes and you are hard at work, studying in the university library. This SEA ES assignment is rather difficult.", 0);
        cont.sentences[0] = new Dialogue(2, "", "Blobert seems to be breezing through his work.", 0);

        cont.sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I’m having trouble with this, do you think you could help?", 1);
        cont.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "Sure thing, mate! See all you have to do this...", 3);
        cont.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You begin to relax, and you end up acing your assignment thanks to Blobert’s help.", 0);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "Not a lot of students know this, but ‘SEA ES’ actually stands for ‘Seriously Engaging Algorithmic Engineering and Science.", 3);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);

        cont.sentences[0].sentences[1] = new Dialogue(1, "Rocky", "I should do my best to solve the problem on my own.", 1);
        cont.sentences[0].sentences[1].sentences[0] = new Dialogue(2, "Blobert", "I reckon you’re having a tough time there; do you need any help?", 3);

        cont.sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Yeah, I’m having a harder time than I expected...", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "Sure thing, mate! See all you have to do this...", 3);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You begin to relax, and you end up acing your assignment thanks to Blobert’s help.", 0);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "Not a lot of students know this, but ‘SEA ES’ actually stands for ‘Seriously Engaging Algorithmic Engineering and Science.", 3);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);

        cont.sentences[0].sentences[1].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "No thanks, I can solve this on my own.", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Blobert", "Oh alright then...", 3);
        cont.sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Blobert goes back to his work. You sense awkwardness in the air.", 0);
        cont.sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);


        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0] = cont;



        currDialogue = root;
        DisplayNextSentence();
    }

    public void slugTedTalk()
    {
        slugTalk = true;
        Dialogue root = new Dialogue(1, "", "", 0);
        root.sentences[0] = new Dialogue(1, "", "It’s a busy day after classes have let out for the day. Everyone is swimming in different directions, in hope of searching for a study spot.", 0);
        root.sentences[0].sentences[0] = new Dialogue(3, "Sluglie", "Hey, do you want to go get mud facials with me?", 4);

        root.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Yeah, let’s go! Studying for midterms has been so stressful.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "I knew you’d say yes! Let’s go; I know a great spot.", 4);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You find your stress melting away as the crab cosmetologist smears mud on your hardened exterior.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "By the way, did you know that we sea slugs get our color from the food we eat? A lot of us eat coral to get this positively gorgeous shade!", 4);

        root.sentences[0].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "I don’t know...I don’t think it would do anything for me.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(2, "Sluglie", "Well even if you can’t reap the benefits, it’ll be a nice break from school!", 4);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Sure, why not!", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "I knew you’d say yes! Let’s go; I know a great spot.", 4);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "You find your stress melting away as the crab cosmetologist smears mud on your hardened exterior.", 0);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "By the way, did you know that we sea slugs get our color from the food we eat? A lot of us eat coral to get this positively gorgeous shade!", 4);

        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "It’d just be a waste of time.", 1);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Sluglie", "You’re right, I do suppose I’m being rather frivolous right now...", 4);
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Sluglie sulks as they crawl off towards the coral cafe to do their homework.", 0);

        root.sentences[0].sentences[0].sentences[2] = new Dialogue(1, "Rocky", "Why would I need a mud facial? And besides, I’m busy with homework.", 1);
        root.sentences[0].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Sluglie sulks as they crawl off towards the coral cafe to do their homework.", 0);


        Dialogue cont = new Dialogue(1, "", "Midterms have passed, and you get your results back. It turns out that you hadn’t studied enough for Marine Bio 101, and you ended up failing your exam.", 0);
        cont.sentences[0] = new Dialogue(3, "Sluglie", "Do you need a hug right now? You know, I always say some self-affirmations to myself to pick myself up when I’m feeling down in the depths.", 4);

        cont.sentences[0].sentences[0] = new Dialogue(1, "Rocky", "That would help. I don’t know what to say for self-affirmations, but I’ll give it a try.", 1);
        cont.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "Yay! My go-to one is: I am strong, I am worthy, I am more than enough!", 4);
        cont.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I am strong, I am worthy, I am more than enough!", 1);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I am strong, I am worthy, I am more than enough!", 1);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I am strong, I am worthy, I am more than enough!", 1);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Thanks, Sluglie. That made me feel better.", 1);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "It makes me happy when I can help others. You know, sea slugs like me cast away our shells when we’re little. This means we build up interesting defense mechanisms!", 4);
        cont.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);

        cont.sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Self- affirmations?.", 1);
        cont.sentences[0].sentences[1].sentences[0] = new Dialogue(2, "Sluglie", "You know, stuff like ‘I’m strong, I am worthy, I am more than enough!’", 4);

        cont.sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Repeat the affirmation, even if it seems corny.", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I am strong, I am worthy, I am more than enough!", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I am strong, I am worthy, I am more than enough!", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I am strong, I am worthy, I am more than enough!", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Thanks, Sluglie. That made me feel better.", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "It makes me happy when I can help others. You know, sea slugs like me cast away our shells when we’re little. This means we build up interesting defense mechanisms!", 4);
        cont.sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);


        cont.sentences[0].sentences[1].sentences[0].sentences[1] = new Dialogue(1, "Rocky", "Never mind, I’ll try something else...on my own.", 1);
        cont.sentences[0].sentences[1].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "Sluglie", "Hmph! Well then, forget I said anything.", 4);
        cont.sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Sluglie lets out a huff, right before going live to start a “storytime” on FlipFlop about your rude behavior.", 0);
        cont.sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);

        cont.sentences[0].sentences[2] = new Dialogue(1, "Rocky", "That’s so corny...", 1);
        cont.sentences[0].sentences[2].sentences[0] = new Dialogue(1, "Sluglie", "Hmph! Well then, forget I said anything.", 4);
        cont.sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "", "Sluglie lets out a huff, right before going live to start a “storytime” on FlipFlop about your rude behavior.", 0);
        cont.sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END1", 0);


        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = cont;
        root.sentences[0].sentences[0].sentences[2].sentences[0].sentences[0] = cont;



        currDialogue = root;
        DisplayNextSentence();
    }

    public void DateTime()
    {
        Dialogue root = new Dialogue(1, "", "", 0);
        root.sentences[0] = new Dialogue(1, "", "Time has passed, and you find yourself growing closer to the friends you’ve met.", 0);
        root.sentences[0].sentences[0] = new Dialogue(1, "", "You realize that after spending so much time with a special someone, you want to be more than friends.", 0);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "The fish you have in mind is...", 0);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "END2", 0);

        currDialogue = root;
        DisplayNextSentence();
    }

    public void axoDate()
    {
        Dialogue root = new Dialogue(1, "", "", 0);
        root.sentences[0] = new Dialogue(1, "", "You enroll for the swim abroad trip to Paris. Or more specifically, it’s the next tank over, fully decorated with Eiffel Tower aquarium ornament.", 0);
        root.sentences[0].sentences[0] = new Dialogue(1, "", "Axolola is here with you, as the two of you longingly look at the Eiffel Tower. You think about all the things that make her special...", 0);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(3, "", "What is Axolola’s favorite food?", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Larva pizza.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(3, "", "What does the word “axolotl” mean?", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "“Lake dragon” in Serran", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Axolola to get to know her well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "", "“Fish friend” in Cupan", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Axolola to get to know her well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "", "“Water monster” in Nahuatl", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Now that you think about it, you know more about Axolola than the average fish does.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Mustering up all the courage you can, you turn to her.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Axolola?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "Yes, Rocky?", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I’m so glad to have gotten to know you...you’ve taught me how to be vulnerable. I’ve never really done that before, and I’m a better rock now because I was able to be your friend.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Will you be my forever fish?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Axolola", "You...you really mean it? Oh gosh, that’s the nicest thing anyone’s ever said to me! Of course I will be your forever fish!", 2);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "The two of you share a special moment together under the aquarium lights as you dream about a future together.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "", "Ghost shrimp sushi.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Axolola to get to know her well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);


        root.sentences[0].sentences[0].sentences[0].sentences[2] = new Dialogue(1, "", "Worm shawarma.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Axolola to get to know her well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);


        currDialogue = root;
        DisplayNextSentence();
    }
    public void slugDate()
    {
        Dialogue root = new Dialogue(1, "", "", 0);
        root.sentences[0] = new Dialogue(1, "", "You enroll for the swim abroad trip to Paris. Or more specifically, it’s the next tank over, fully decorated with Eiffel Tower aquarium ornament.", 0);
        root.sentences[0].sentences[0] = new Dialogue(1, "", "Sluglie is here with you, as the two of you longingly look at the Eiffel Tower. You think about all the things that make them special...", 0);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(3, "", "How do sea slugs get their color?", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "From their specific habitat", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Sluglie to get to know them well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "", "From their diet", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(3, "", "When do slugs get rid of their shells?", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2] = new Dialogue(1, "", "The shell dissolves and becomes part of their exoskeleton", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Sluglie to get to know them well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1] = new Dialogue(1, "", "They are born without shells", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Sluglie to get to know them well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "They cast them away when they are young", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Now that you think about it, you know more about Sluglie than the average fish does. ", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Mustering up all the courage you can, you turn to them.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Sluglie?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Sluglie", "Yes, Rocky?", 4);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I’m so glad to have gotten to know you...you’ve taught me how to be vulnerable. I’ve never really done that before, and I’m a better rock now because I was able to be your friend.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Will you be my forever fish?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "I never thought you’d come around to your senses! It’s about time. Of course I will be your forever fish!", 3);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "The two of you share a special moment together under the aquarium lights as you dream about a future together.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[2] = new Dialogue(1, "", "8,000 to 16,000 meters deep.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Sluglie to get to know them well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);


        currDialogue = root;
        DisplayNextSentence();
    }
    public void blobDate()
    {
        Dialogue root = new Dialogue(1, "", "", 0);
        root.sentences[0] = new Dialogue(1, "", "You enroll for the swim abroad trip to Paris. Or more specifically, it’s the next tank over, fully decorated with Eiffel Tower aquarium ornament.", 0);
        root.sentences[0].sentences[0] = new Dialogue(1, "", "Blobert is here with you, as the two of you longingly look at the Eiffel Tower. You think about all the things that make him special...", 0);
        root.sentences[0].sentences[0].sentences[0] = new Dialogue(3, "", "How deep are the waters that Blobert is originally from?", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "1,000 to 5,000 meters deep.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Blobert to get to know him well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1] = new Dialogue(1, "", "6,000 to 12,000 meters deep.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0] = new Dialogue(3, "", "Blobert is a SEA ES major. What does SEA ES stand for?", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Seasonal Excellence Amassing Efficient Students.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Blobert to get to know him well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1] = new Dialogue(1, "", "Somewhat Effective Analysis Energizing Studies.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Blobert to get to know him well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[1].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2] = new Dialogue(1, "", "Seriously Engaging Algorithmic Engineering and Science.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Now that you think about it, you know more about Blobert than the average fish does.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "", "Mustering up all the courage you can, you turn to him.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Blobert?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "Yes, Rocky?", 3);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "I’m so glad to have gotten to know you...you’ve taught me how to be vulnerable. I’ve never really done that before, and I’m a better rock now because I was able to be your friend.", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Rocky", "Will you be my forever fish?", 1);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "Blobert", "You are the rock to my blob, Rocky. Of course I will be your forever fish.", 3);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "The two of you share a special moment together under the aquarium lights as you dream about a future together.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[1].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);

        root.sentences[0].sentences[0].sentences[0].sentences[2] = new Dialogue(1, "", "8,000 to 16,000 meters deep.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0] = new Dialogue(1, "", "Looks like you didn’t spend enough time with Blobert to get to know him well. You might want to try harder next time.", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0] = new Dialogue(1, "", "Die Alone", 0);
        root.sentences[0].sentences[0].sentences[0].sentences[2].sentences[0].sentences[0].sentences[0] = new Dialogue(1, "", "DEAD", 0);


        currDialogue = root;
        DisplayNextSentence();

    }
}   