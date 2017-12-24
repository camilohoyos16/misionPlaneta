using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "QuestionsNAswers", menuName = "TrviaData", order = 1)]
public class DataContainer : ScriptableObject
{
    [SerializeField] public List<AnswersNQuestions> data;
}
