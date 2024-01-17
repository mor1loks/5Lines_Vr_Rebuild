using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Diet : MonoBehaviour
{
    [SerializeField] private GameObject _diet;
    [SerializeField] private GameObject _buttonPlus;
    [SerializeField] private GameObject _buttonMinus;
    [SerializeField] private StrelkaButton _strelkaMinus;
    [SerializeField] private StrelkaButton _strelkaPlus;
    [SerializeField] private GameObject[] _dietMeshParts;
    private DietButtonNames _dietButtonNames= new DietButtonNames();

    public void EnableDiet(bool value, Transform position)
    {
        if (value)
        {
            _strelkaMinus.GetComponent<Collider>().enabled = true;
            _strelkaPlus.GetComponent<Collider>().enabled = true;
            _diet.transform.position = position.position;
            _diet.transform.rotation = position.rotation;
        }
        StartCoroutine(DietMover(value));
    }
    private IEnumerator DietMover(bool value)
    {
        if (value)
        {
            SoundPlayer.Instance.PlayRadioSound();
            _buttonMinus.SetActive(false);
            _buttonPlus.SetActive(false);
        }

        int x = 0;
        while (x <= 32)
        {
            if (value)
            {
                _diet.SetActive(true);
                _diet.transform.position += new Vector3(0, 0.0125f, 0);
            }
            else
            {
                _buttonPlus.SetActive(false);
                _buttonMinus.SetActive(false);
                _diet.transform.position -= new Vector3(0, 0.0125f, 0);
            }
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        if (!value)
        {
            _diet.SetActive(false);
        }
    }
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
