using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class SetTextAOSObject : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    public void SetLocationText( string text)
    {
        _textMesh.text = text;
    }

}
