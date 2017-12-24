using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Answers
{
    public bool isCorrect;
    public string answer;
}

[Serializable]
public class AnswersNQuestions
{
    public string question;
    [SerializeField] public List<Answers> answers;
}

public class QuestionsAnswersData : MonoBehaviour
{
    
}
