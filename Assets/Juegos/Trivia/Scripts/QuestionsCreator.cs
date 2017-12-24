using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsCreator : MonoBehaviour {

	private static QuestionsCreator instance;
	public static QuestionsCreator Instance{ get { return instance; } }

	[SerializeField] public int amountOfQuestions;
    [SerializeField] private DataContainer scriptableData;

    public List<AnswersNQuestions> questions = new List<AnswersNQuestions>();
    private List<int> indexAlreadyUsed = new List<int>();

    public static List<AnswersNQuestions> questionsChoosed = new List<AnswersNQuestions>();

    private void Awake()
    {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}
        SelectQuestions();
    }

    private void SelectQuestions()
    {
        for(int i = 0; i < amountOfQuestions; i++)
        {
            int random = IndexSelector();
            questions.Add(scriptableData.data[random]);
            indexAlreadyUsed.Add(random);
        }

        questionsChoosed = questions;
    }

    private int IndexSelector()
    {
        int random = 0;
        bool isGoodIndex = false;
        random = Random.Range((int)0, (int)scriptableData.data.Count);

        while (!isGoodIndex)
        {
            if (indexAlreadyUsed.Count == 0)
            {
                isGoodIndex = true;
                break;
            }
            else
            {
                for (int j = 0; j < indexAlreadyUsed.Count; j++)
                {
                    if (indexAlreadyUsed[j] == random)
                    {
                        random = Random.Range((int)0, (int)scriptableData.data.Count);
                        j = 0;
                    }
                    else
                    {
                        isGoodIndex = true;
                    }
                }
            }
        }
        
        
        return random;
    }
}
