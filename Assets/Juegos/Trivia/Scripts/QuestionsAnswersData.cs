using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum TypeOfAnswer{
	energy,
	local,
	environment
}

[Serializable]
public class Answers
{
    public bool isCorrect;
    public string answer;
}

[Serializable]
public class AnswersNQuestions
{
	public TypeOfAnswer answerType;
    public string question;
    [SerializeField] public List<Answers> answers;
}

public class QuestionsAnswersData : MonoBehaviour
{
    
}
