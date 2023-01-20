using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answers : MonoBehaviour
{
    public Manager manager;
    public bool isCorrect = false;

    // Checks if the player chose the right answer.
   public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            manager.Correct();
        }
        else
        {
            Debug.Log("Wrong Answer");
            manager.Wrong();
        }
    }
}
