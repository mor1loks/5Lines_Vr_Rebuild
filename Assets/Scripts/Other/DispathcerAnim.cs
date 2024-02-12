using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispathcerAnim : MonoBehaviour
{

    private Animator _anim;
    private void OnEnable()
    {
        StrelkaAOS.StrelkaChangedEvent += OnPlayStrelkaAnim;
    }
    private void OnDisable()
    {
        StrelkaAOS.StrelkaChangedEvent -= OnPlayStrelkaAnim;
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
