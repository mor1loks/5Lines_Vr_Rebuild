using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchemeImageChanger : MonoBehaviour
{
    [SerializeField] private SchemeUIButton _left;
    [SerializeField] private SchemeUIButton _right;
    [SerializeField] private Sprite[] _sprites;
    private int _lenght;
    private int _curSprite;
    private void Start()
    {
        _left.ClickEvent += OnChangeSprite;
        _right.ClickEvent += OnChangeSprite;
        _lenght = _sprites.Length;
    }
    private void OnChangeSprite(bool side)
    {
       if(side)
        _curSprite++;
       else
            _curSprite--;
        if (_curSprite > _lenght - 1)
            _curSprite = _lenght - 1;
        if(_curSprite<0)
            _curSprite = 0;
        GetComponent<Image>().sprite = _sprites[_curSprite];
    }
}
