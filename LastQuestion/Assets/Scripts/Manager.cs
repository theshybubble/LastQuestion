using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public List<QuestionsAndAnswers> Quiz;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject GamePanel;
    public GameObject OverPanel;

    public Text QuestionText;
    public Text ScoreText;

    int totalQuestions = 0;
    public int score; 

    private void Start()
    {
        totalQuestions = Quiz.Count;
        OverPanel.SetActive(false);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; 1 < options.Length; i++)
        {
            options[i].GetComponent<Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = Quiz[currentQuestion].Answers[i];

            if(Quiz[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    //when the ansdwer is correct.
    public void Correct()
    {
        score += 1;
        Quiz.RemoveAt(currentQuestion);
        generateQuestion();
    }

    //when the answer is wrong.
    public void Wrong()
    {
        Quiz.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void generateQuestion()
    {
        if(Quiz.Count > 0)
        {
            currentQuestion = Random.Range(0, Quiz.Count);

            QuestionText.text = Quiz[currentQuestion].Questions;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out Of Questions");
            GameOver();
        }
    }

    void GameOver()
    {
        GamePanel.SetActive(false);
        OverPanel.SetActive(true);

        ScoreText.text = score + "/" + totalQuestions;
    }

    // reload the scene
    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
