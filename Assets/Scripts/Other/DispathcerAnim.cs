using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispathcerAnim : MonoBehaviour
{
    [SerializeField] private StrelkaButton _minusButton;
    [SerializeField] private StrelkaButton _plusButton;

    private Animator _anim;
    private void OnEnable()
    {
        _plusButton.OnStrelkaButtonClicked += OnPlayStrelkaAnim;
        _minusButton.OnStrelkaButtonClicked += OnPlayStrelkaAnim;
    }
    private void OnDisable()
    {
        _plusButton.OnStrelkaButtonClicked -= OnPlayStrelkaAnim;
        _minusButton.OnStrelkaButtonClicked -= OnPlayStrelkaAnim;
    }
    private void Start()
    {
        _anim= GetComponent<Animator>();
    }
    private void OnPlayStrelkaAnim()
    {
        _anim.SetTrigger("Perevod");
    }
}
