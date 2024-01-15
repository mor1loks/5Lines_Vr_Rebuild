using TMPro;
using UnityEngine;

public abstract class BaseStartScreenView : MonoBehaviour
{
    [SerializeField] protected GameObject NextButtonGameObject;
    [SerializeField] protected GameObject Interacthelpers;
    [SerializeField] protected GameObject Timer;
    [SerializeField] protected GameObject Location;

    [SerializeField] protected TextMeshProUGUI HeaderText;
    [SerializeField] protected TextMeshProUGUI CommentText;
    [SerializeField] protected TextMeshProUGUI NextButtonText;

    protected INextButton NextButton;
    protected virtual void Awake()
    {
        NextButton = NextButtonGameObject.GetComponent<INextButton>();
        if (NextButton == null)
        {
            Debug.Log($"You must inherit gameObject {NextButtonGameObject.name} from INextButton");
            return;
        }
        NextButton.NextButtonPressedEvent += OnHideStartScreen;
    }
    public virtual void EnableStartScreen(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        NextButtonText.gameObject.SetActive(true);
        NextButtonGameObject.SetActive(true);
        HeaderText.text = headerText;
        CommentText.text = commentText;
        NextButtonText.text = buttonText;
        NextButton.CurrentState = state;
        Interacthelpers.SetActive(false);

    }
    protected virtual void OnHideStartScreen(string value)
    {
        if (value == "start")
        {
            DisableStartScreen();
            Interacthelpers.SetActive(true);
            var esc = FindObjectOfType<EscButton>();
            esc.Show = true;
            Timer.SetActive(true);
            Location.SetActive(true);
        }
    }
    protected abstract void DisableStartScreen();
  
}
