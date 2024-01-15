using UnityEngine;

public abstract class BaseMenuScreen : MonoBehaviour
{
    public abstract void SetMenuText(string headText, string commentText, string exitSureText);
    public abstract void SetExitText(string exitText, string warntext);
    public abstract void ShowMessageScreen(string headText, string commentText);
    public abstract void ShowLastScteen(string headText, string commentText, string evaltext);
}
