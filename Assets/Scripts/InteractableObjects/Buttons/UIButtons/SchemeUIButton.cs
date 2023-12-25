using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchemeUIButton : BaseUIButton
{
    [SerializeField] private Sprite[] _sprites;
    private int _curSprite;
    protected override void Click() => ChangeSprite();
    private void ChangeSprite()
    {
        _curSprite++;
        if (_curSprite > _sprites.Length - 1)
            _curSprite = 0;
        GetComponent<Image>().sprite = _sprites[_curSprite];
    }
}
