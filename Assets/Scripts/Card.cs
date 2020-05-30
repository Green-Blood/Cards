using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Card : MonoBehaviour
{
    // To make sure that not any card will flipped
    public static bool DO_NOT = false;

    [SerializeField]
    int _state;
    [SerializeField]
    int _cardValue;
    [SerializeField]
    bool _initalized = false;

    Sprite _cardBack;
    Sprite _cardFace;

    GameObject _manager;

    void Start()
    {
        _state = 1;
        // Usually we shouldn't do this, but this is a small game, so noone cares
        _manager = GameObject.FindGameObjectWithTag("Manager");   
    }
    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    } 

    // Function that flips the card
    public void flipCard()
    {
        if (_state == 0) _state = 1;       
        else if(_state == 1) _state = 0;

        // If card hasn't changed (user is wrong) flip to the backside
        if(_state == 0 && !DO_NOT)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        // If card has changed (match) flit to the face side
        else if(_state == 1 && !DO_NOT)
        {
             GetComponent<Image>().sprite = _cardFace;
        
        }
    }

    // Getters and Setters
    public int cardValue
    {
        get {return _cardValue;}
        set {_cardValue = value;}
    }
    public int state 
    {
        get { return _state; }
        set { _state = value; } 

    }
    public bool initalized 
    {
        get { return _initalized; }
        set { _initalized = value; } 

    }
    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    // Pause enumerator to pause for a second before changing card back
    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if(_state == 0)
        {
            GetComponent<Image>().sprite = _cardBack;
        }
        else if (_state == 1)
        {
            GetComponent<Image>().sprite = _cardFace;
        }
        DO_NOT = false;
    }
}
