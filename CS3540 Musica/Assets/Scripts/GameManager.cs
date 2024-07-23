using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GuitarInteraction> correctSequence;
    private List<GuitarInteraction> playerSequence = new List<GuitarInteraction>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NotePlayed(GuitarInteraction guitar)
    {
        playerSequence.Add(guitar);
        CheckSequence();
    }

    void CheckSequence()
    {
        if (playerSequence.Count == correctSequence.Count)
        {
            bool isCorrect = true;
            for (int i = 0; i < correctSequence.Count; i++)
            {
                if (playerSequence[i] != correctSequence[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                Debug.Log("Correct Sequence!");
            }
            else
            {
                Debug.Log("Wrong Sequence. Try Again.");
                playerSequence.Clear();
            }
        }
    }
}
