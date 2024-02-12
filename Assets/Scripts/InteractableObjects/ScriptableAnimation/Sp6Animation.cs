using AosSdk.Core.PlayerModule;
using System.Collections;
using UnityEngine;

public class Sp6Animation : ObjectWithAnimation
{
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _roof;

    private bool _isAmimated = false;

    private IEnumerator PlaySp6Anim(bool value)
    {
        if (!_isAmimated)
        {
            if(value)
            Player.Instance.CanMove = false;
            _isAmimated = true;
            if(value)
            _anim.SetTrigger("kurbelOut");
            yield return new WaitForSeconds(GetAnimLenght());
            StartCoroutine(RoofRotator(value));
            if (value)
                _anim.SetTrigger("kurbelIn");
            yield return new WaitForSeconds(GetAnimLenght());
            _isAmimated = false;
            yield return new WaitForSeconds(2f);
            Player.Instance.CanMove = true;
        }
    }
    private IEnumerator RoofRotator(bool value)
    {
        if (value)
        {
            int z = 0;
            while (z <= 120)
            {
                _roof.transform.localRotation = Quaternion.Euler(0, 0, z);
                z++;
                yield return new WaitForSeconds(0.001f);
            }
        }
        else
        {
            int z = 120;
            while (z >= 0)
            {
                _roof.transform.localRotation = Quaternion.Euler(0, 0, z);
                z--;
                yield return new WaitForSeconds(0.001f);
            }
        }
    }
    private float GetAnimLenght()
    {
        AnimatorStateInfo info = _anim.GetCurrentAnimatorStateInfo(0);
        float animLenght = info.length;
        return animLenght;
    }

    public override void PlayScriptableAnimationClose()
    {
        StartCoroutine(PlaySp6Anim(false));
    }

    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(PlaySp6Anim(true));
    }
}
