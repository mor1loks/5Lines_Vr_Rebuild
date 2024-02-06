using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
public class RadioButton : BaseButton
{
    [SerializeField] private Diet _diet;
    [SerializeField] protected Transform _dietPosition;
    private bool _radio = false;
    private void OnEnable()
    {
        BackButton.BackButtonClickedEvent += OnBackClicked;
    }
    private void OnDisable()
    {
        BackButton.BackButtonClickedEvent -= OnBackClicked;
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        DietEnabler();
    }
    private void DietEnabler()
    {
  
    }
    private void OnBackClicked()
    {

    }
}
