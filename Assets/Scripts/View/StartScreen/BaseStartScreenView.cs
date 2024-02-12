using TMPro;
using UnityEngine;

public abstract class BaseStartScreenView : MonoBehaviour
{
    [SerializeField] protected ModeController ModeController;
    [SerializeField] protected GameObject NextButtonGameObject;
    [SerializeField] protected GameObject _exitButtonMidle;
    [SerializeField] protected GameObject _exitButton;
    [SerializeField] protected GameObject _loadImage;
    [SerializeField] protected GameObject _catoImage;
    [SerializeField] protected GameObject _lineImage;
    [Space]
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
    public virtual void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        if (state == NextButtonState.Start)
        {
            _catoImage.SetActive(true);
            buttonText = "Далее";
        }
        else
        {
            _catoImage.SetActive(false);
            buttonText = "Начать";
        }
        NextButtonGameObject.SetActive(true);
        _exitButtonMidle.SetActive(false);
        _exitButton.SetActive(true);
        _loadImage.SetActive(false);
        HeaderText.text = headerText;
        CommentText.text = commentText;
        NextButtonText.text = buttonText;
        NextButton.CurrentState = state;
    }
    protected virtual void OnHideStartScreen(string text)
    {
        if (text == "start")
        {
            DisableStartScreen();
            ModeController.CurrentInteractScreen.EnableAllHelperObjects(true);
            ModeController.CurrentMenuController.CanTeleport = true;
            _lineImage.SetActive(true);
        }
    }
    protected abstract void DisableStartScreen();
  
}
