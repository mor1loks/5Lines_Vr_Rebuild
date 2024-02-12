using System.Collections;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class VoltButton : BaseButton
{
    public UnityAction<int> ButtonDownEvent;
    public UnityAction<string> NaprChangedEvent;
    
    [SerializeField] private GameObject _buttonBox;
    [SerializeField] private int _index;
    [SerializeField] private Napr _currentNapr;
    
    private enum Napr
    {
        Post,
        Sopr,
        Perem
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);   
        StartCoroutine(MoveButton(true));
        NaprChangedEvent?.Invoke(_currentNapr.ToString());
    }
    public void ResetButton() => StartCoroutine(MoveButton(false));

    private IEnumerator MoveButton(bool down)
    {
        if(down)
        {
            GetComponent<Collider>().enabled = false;
            ButtonDownEvent?.Invoke(_index);
       
            while(_buttonBox.transform.localPosition.y>=0.058f)
            {
                _buttonBox.transform.localPosition -= new Vector3(0, 0.001f, 0);
                yield return new WaitForSeconds(0.005f);
            }
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            while (_buttonBox.transform.localPosition.y <= 0.0605f)
            {
                _buttonBox.transform.localPosition += new Vector3(0, 0.001f, 0);
                yield return new WaitForSeconds(0.005f);
            }
            GetComponent<Collider>().enabled = true;
        }
    }
}
