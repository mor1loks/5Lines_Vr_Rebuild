using UnityEngine;
public class Diet : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPlus;
    [SerializeField] private GameObject _buttonMinus;
    private DietButtonNames _dietButtonNames= new DietButtonNames();

    public void EnablePlusOrMinus(string buttonName)
    {
        if (_dietButtonNames.HasPlusButton(buttonName)) 
            _buttonPlus.SetActive(true);
        if (_dietButtonNames.HasMinusButton(buttonName))
            _buttonMinus.SetActive(true);
        else if (buttonName == null)
        {
            _buttonMinus.SetActive(false);
            _buttonPlus.SetActive(false);
        }
    }
}
