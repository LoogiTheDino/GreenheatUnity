using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCard : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private Image spriteRenderer;
    SolitareGame solitaire;

    public bool faceUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [System.Obsolete]
    void Start()
    {
        List<string> deck = SolitareGame.GenerateDeck();
        solitaire = FindObjectOfType<SolitareGame>();

        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (faceUp) spriteRenderer.sprite = cardFace;
        else spriteRenderer.sprite = cardBack;
    }
}
