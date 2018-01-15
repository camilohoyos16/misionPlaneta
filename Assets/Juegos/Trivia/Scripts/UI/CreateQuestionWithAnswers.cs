using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateQuestionWithAnswers : MonoBehaviour {
    
	[SerializeField] private Text questionText;
	[SerializeField] private GameObject answersParents;
	[SerializeField] private GameObject buttonPrefab;
	[SerializeField] private int howManyButtons;
	[Header ("BackgroundSettings")]
	[SerializeField] private Image backGround;
	[SerializeField] private Sprite energyBackgorund;
	[SerializeField] private Sprite localBackgorund;
	[SerializeField] private Sprite environmentBackgorund;

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

				button.GetComponentInChildren<Text> ().text = string .Format("-{0}",QuestionsCreator.questionsChoosed [indexButtonCreated].answers [randomNumber].answer);
				button.GetComponent<ButtonSelect> ().isCorrect = QuestionsCreator.questionsChoosed [indexButtonCreated].answers [randomNumber].isCorrect;
				ChangeBackgorund(QuestionsCreator.questionsChoosed [indexButtonCreated].answerType);
				button.onClick.AddListener (() => ScoreManager.instance.CheckAnswer (button.GetComponent<ButtonSelect> ().isCorrect));
				button.onClick.AddListener (() => AddButtons ());
			}
			indexButtonCreated++;
		}
	}

	private void ChangeBackgorund(TypeOfAnswer answerType)
	{
		switch (answerType) {
		case TypeOfAnswer.energy:
			backGround.sprite = energyBackgorund;
			break;
		case TypeOfAnswer.environment:
			backGround.sprite = environmentBackgorund;
			break;
		case TypeOfAnswer.local:
			backGround.sprite = localBackgorund;
			break;
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
