
	using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateQuestionWithAnswers : MonoBehaviour {
    
	[SerializeField] private Text questionText;
	[SerializeField] private GameObject answersParents;
	[SerializeField] private GameObject buttonPrefab;
	[SerializeField] private int howManyButtons;

	private int indexButtonCreated;
	private List<int> indexOfAnswersUsed = new List<int>();

	// Use this for initialization
	void Start () {
		indexButtonCreated = 0;
		AddButtons ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AddButtons()
	{		
		EraseLayout ();
		if (indexButtonCreated < QuestionsCreator.Instance.amountOfQuestions) {
			questionText.text = QuestionsCreator.questionsChoosed [indexButtonCreated].question;
			List<int> indexesToUse = new List<int> ();
			for (int i = 0; i < howManyButtons; i++) {
				indexesToUse.Add(i);
			}
			for (int i = 0; i < howManyButtons; i++) {
				
				Button button = Instantiate (buttonPrefab.GetComponent<Button> ());
				
				var rectTransform = button.GetComponent<RectTransform> ();
				rectTransform.SetParent (answersParents.transform, false);
				rectTransform.offsetMin = Vector2.one * 50;
				rectTransform.offsetMax = Vector2.one * 50;
				
				rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, GetComponent<RectTransform> ().rect.height / (howManyButtons + 1));
				rectTransform.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, GetComponent<RectTransform> ().rect.width / 1.2f);
				int randomIndex = Random.Range (0, indexesToUse.Count);
				int randomNumber = indexesToUse[randomIndex];
				indexesToUse.RemoveAt (randomIndex);
				/*if (indexOfAnswersUsed.Count != 0) {
					for (int checkAnswerIndex = 0; checkAnswerIndex < indexOfAnswersUsed.Count; checkAnswerIndex++) {
						if (randomNumber == indexOfAnswersUsed [checkAnswerIndex])
							randomNumber = Random.Range (0, 3);
					}
				}*/

				button.GetComponentInChildren<Text> ().text = QuestionsCreator.questionsChoosed [indexButtonCreated].answers [randomNumber].answer;
				button.GetComponent<ButtonSelect> ().isCorrect = QuestionsCreator.questionsChoosed [indexButtonCreated].answers [randomNumber].isCorrect;

				button.onClick.AddListener (() => ScoreManager.instance.CheckAnswer (button.GetComponent<ButtonSelect> ().isCorrect));
				button.onClick.AddListener (() => AddButtons ());
			}
			indexButtonCreated++;
		}
	}

	private void EraseLayout()
	{
		questionText.text = "";
		ButtonSelect[] layoutChilds = answersParents.GetComponentsInChildren<ButtonSelect> ();

		if (layoutChilds.Length != 0) {
			for (int i = 0; i < layoutChilds.Length; i++) {
				Destroy (layoutChilds [i].gameObject);
			}
		}
	}
}
