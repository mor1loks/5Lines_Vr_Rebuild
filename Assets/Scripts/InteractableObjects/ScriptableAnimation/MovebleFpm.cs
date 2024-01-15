using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;


public class MovebleFpm : MovebleObject
{
    [SerializeField] private GameObject _fpmObject;

    public override void RepairObject()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        int x = 0;
        canMove = false;
        while (x <= 32)
        {
            if (!_yPoz)
                transform.position += new Vector3(0.012f, 0, 0);
            else
                transform.position += new Vector3(0, 0.012f, 0);
            yield return new WaitForSeconds(0.02f);
            x++;
        }
        _fpmObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        _fpmObject.SetActive(true);
        while (x > 0)
        {
            if (!_yPoz)
                transform.position -= new Vector3(0.012f, 0, 0);
            else
                transform.position -= new Vector3(0, 0.012f, 0);
            yield return new WaitForSeconds(0.02f);
            x--;
        }
        canMove = true;
    }
}
