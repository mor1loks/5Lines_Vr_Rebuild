using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasObjectHelperController : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI _textMesh;
    [SerializeField] private GameObject _canvasObject;


    private string _name;
    private Transform _helperPos;
    private float _timer = 0.3f;

    public void ShowTextHelper(string name, Transform newPos)
    {
        _name = name;
        _helperPos = newPos;
        StartCoroutine("GetHelpName");
    }
    public void HidetextHelper()
    {
        _timer = 0.3f;
        StopCoroutine("GetHelpName");
        _canvasObject.SetActive(false);
    }
    private IEnumerator GetHelpName()
    {
        yield return new WaitForSeconds(_timer);
        _textMesh.text = _name;
        transform.position = _helperPos.position;
        yield return new WaitForSeconds(0.01f);
        _canvasObject.SetActive(true);
    }
}
