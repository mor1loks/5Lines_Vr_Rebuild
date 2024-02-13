using System;
using AosSdk.Core.Utils;
using Newtonsoft.Json.Linq;
using UnityEngine;
public enum NextButtonState
{
    Start,
    Fault
}

[AosSdk.Core.Utils.AosObject(name: "АПИ")]
public class API : AosObjectBase
{
    public Action ShowPlaceEvent;
    public Action ResetMeasureButtonsEvent;
    public Action<float> SetMeasureValueEvent;
    public Action<string> SetTeleportLocationEvent;
    public Action<string> SetNewLocationTextEvent;
    public Action<string> SetLocationEvent;
    public Action<string> SetLocationForFieldCollidersEvent;
    public Action<string> ActivateBackButtonEvent;
    public Action<string> EnableDietButtonsEvent;
    public Action<string> SetTimerTextEvent;
    public Action<string> AddMeasureButtonEvent;
    public Action<string> ReactionEvent;
    public Action<string, string> EnableRactionButtonEvent;
    public Action<string, string> ResultNameTextButtonSingleEvent;
    public Action<string, string, string> ActivateByNameEvent;
    public Action<string, string, string> ResultNameTextButtonEvent;
    public Action<string, string,string,string> SetMessageTextEvent;
    public Action<string, string, string> SetResultTextEvent;
    public Action<string, string> ShowExitTextEvent;
    public Action<string, string, string> ShowMenuTextEvent;
    public Action<string, string, string, NextButtonState> SetStartTextEvent;

    [AosEvent(name: "Перемещение игрока")]
    public event AosEventHandlerWithAttribute EndTween;
    [AosEvent(name: "Клик по кнопке далее")]
    public event AosEventHandlerWithAttribute navAction;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnMeasure;
    [AosEvent(name: "Результат измерения")]
    public event AosEventHandlerWithAttribute OnReason;
    [AosEvent(name: "Открыть меню")]
    public event AosEventHandler OnMenu;
    public void Teleport([AosParameter("Задать локацию для перемещения")] string location)
    {
        SetTeleportLocationEvent?.Invoke(location);
        EndTween?.Invoke(location);
    }
    [AosAction(name: "Задать текст приветствия")]
    public void showWelcome(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Start);
        //OnSetTeleportLocation?.Invoke("start");
    }
    [AosAction(name: "Показать информацию отказа")]
    public void showFaultInfo(JObject info, JObject nav)
    {
        string headerText = info.SelectToken("name").ToString();
        string commentText = info.SelectToken("text").ToString();
        string buttonText = nav.SelectToken("ok").SelectToken("caption").ToString();
        SetStartTextEvent?.Invoke(headerText, commentText, buttonText, NextButtonState.Fault);
    }
    public void OnInvokeNavAction(string value)
    {
        navAction.Invoke(value);
    }
    [AosAction(name: "Показать место")]
    public void showPlace(JObject place, JArray data, JObject nav)
    {
        string location = place.SelectToken("apiId").ToString();
        if (location != null)
            SetLocationEvent?.Invoke(location);
        if (place.SelectToken("name") != null)
        {
            SetNewLocationTextEvent?.Invoke(place.SelectToken("name").ToString());
        }
        ShowPlaceEvent?.Invoke();
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("apiId");
            var id = "";
            var name = "";
            var time = "";
            if (temp != null)
            {
                id = temp.ToString();
                name = item.SelectToken("name").ToString();
            }
            var timeText = item.SelectToken("result");
            if (timeText != null)
            {
                var timeToShow = timeText.SelectToken("tm");
                if (timeToShow != null)
                {
                    time = timeText.SelectToken("tm").ToString();
                }
            }
            ActivateByNameEvent?.Invoke(id, name, time);
        }

        if (nav.SelectToken("back") != null && nav.SelectToken("back").SelectToken("action") != null && nav.SelectToken("back").SelectToken("action").ToString() != String.Empty)
        {
            ActivateBackButtonEvent?.Invoke(nav.SelectToken("back").SelectToken("action").ToString());
        }
    }
    [AosAction(name: "Обновить место")]
    public void updatePlace(JArray data)
    {
        Debug.Log("Enter UpdatePlace");
        foreach (JObject item in data)
        {
            var temp = item.SelectToken("points");
            if (temp != null)
            {
                EnableDietButtonsEvent(null);
                if (temp is JArray)
                {
                    foreach (var temp2 in temp)
                    {
                        string buttonName = temp2.SelectToken("apiId").ToString();
                        EnableDietButtonsEvent(buttonName);
                    }
                }
            }
        }
    }


    [AosAction(name: "Показать реакцию")]
    public void showReaction(JObject info, JObject nav)
    {
        if (info.SelectToken("text") != null)
        {
            var reactionText = info.SelectToken("text").ToString();
            ReactionEvent?.Invoke(reactionText);
        }
    }

    [AosAction(name: "Показать сообщение")]
    public void showMessage(JObject info, JObject nav)
    {
        string footerText = "";
        var header = info.SelectToken("header");
        var footer = info.SelectToken("footer");
        var comment = info.SelectToken("text");
        var alarm = info.SelectToken("alarm");
        if (header != null && footer != null && comment != null && alarm != null)
        {
            footerText = HtmlToText.Instance.HTMLToTextReplace(footer.ToString());
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            string headText = header.ToString();
            string alarmImg = alarm.ToString();
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        else if (header != null && comment != null && alarm != null)
        {

            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            string headText = header.ToString();
            string alarmImg = alarm.ToString();
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        else if (comment != null)
        {
            string commentText = HtmlToText.Instance.HTMLToTextReplace(comment.ToString());
            footerText = "";
            string headText = "";
            string alarmImg = "none";
            SetMessageTextEvent?.Invoke(headText, footerText, commentText, alarmImg);
        }
        //string headText = info.SelectToken("name").ToString();
        //string commentText = info.SelectToken("text").ToString();
        //SetMessageTextEvent?.Invoke(headText, commentText);
    }
    [AosAction(name: "Показать сообщение")]
    public void showResult(JObject info, JObject nav)
    {
        string resultText = "";
        Debug.Log("RESULT " + info.ToString());
        string headText = info.SelectToken("name").ToString();
        string commentText = HtmlToText.Instance.HTMLToTextReplace(HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("text").ToString()));
        string evalText = HtmlToText.Instance.HTMLToTextReplace(info.SelectToken("eval").ToString());
        SetResultTextEvent?.Invoke(headText, commentText, evalText);
        var result = info.SelectToken("result");


        if (result != null)
        {
            foreach (JObject item in result)
            {
                resultText = "";
                var name = item.SelectToken("name").ToString();
                var penalty = item.SelectToken("penalty").ToString();
                var msg = item.SelectToken("msg");
                if (msg == null)
                {
                    ResultNameTextButtonSingleEvent?.Invoke(name, penalty);
                }
                else
                {

                    foreach (var item2 in msg)
                    {
                        var message2 = item2.SelectToken("msg");
                        var name2 = item2.SelectToken("name");
                        if (message2 != null && name2 != null)
                        {
                            resultText += name2.ToString() + message2.ToString();
                        }
                        else
                        {
                            resultText += HtmlToText.Instance.HTMLToTextReplace(item2.ToString()) + "\n";
                        }
                    }
                    ResultNameTextButtonEvent?.Invoke(name, penalty, resultText);
                }

            }

        }
    }
    [AosAction(name: "Показать точки")]
    public void showPoints(string info, JArray data)
    {

        EnableRactionButtonEvent?.Invoke(null, null);
        foreach (JObject item in data)
        {
            if (item == null)
                return;
            if (item.SelectToken("tool") != null && item.SelectToken("name") != null)
            {
                if (item.SelectToken("tool").ToString() == "eye")
                {
                    string eye = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableRactionButtonEvent?.Invoke(eye, text);
                }
                if (item.SelectToken("tool").ToString() == "hand")
                {
                    string hand = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableRactionButtonEvent?.Invoke(hand, text);
                }
                if (item.SelectToken("tool").ToString() == "tool")
                {
                    string tool = item.SelectToken("tool").ToString();
                    string text = item.SelectToken("name").ToString();
                    EnableRactionButtonEvent?.Invoke(tool, text);
                }
            }

            else if (item.SelectToken("apiId") != null)
            {
                string buttonName = item.SelectToken("apiId").ToString();
                EnableDietButtonsEvent?.Invoke(buttonName);
            }
        }
    }

    [AosAction(name: "Показать реакцию")]
    public void showTime(string time)
    {
        SetTimerTextEvent?.Invoke(time);
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasure(JArray measureDevices, JArray measurePoints)
    {
        ResetMeasureButtonsEvent?.Invoke();
        foreach (JObject item in measurePoints)
        {
            var tmpArray = item.SelectToken("points");
            if (tmpArray != null && tmpArray is JArray)
            {
                foreach (JObject item2 in tmpArray)
                {
                    string butonName = item2.SelectToken("apiId").ToString();
                    AddMeasureButtonEvent?.Invoke(butonName);
                }
            }
        }
    }
    [AosAction(name: "Показать точки измерения")]
    public void showMeasureResult(JObject result, JObject nav)
    {
        Debug.Log("in showFaultInfo Measure Result");
        if (result.SelectToken("result") != null)
        {
            float measureValue = float.Parse(result.SelectToken("result").ToString());
            SetMeasureValueEvent?.Invoke(measureValue);
            Debug.Log("in showFaultInfo Measure Result " + measureValue);
        }
    }
    [AosAction(name: "Показать меню")]
    public void showMenu(JObject faultInfo, JObject exitInfo, JObject resons)
    {
        string headtext = faultInfo.SelectToken("name").ToString();
        string commentText = faultInfo.SelectToken("text").ToString();
        string exitSureText = exitInfo.SelectToken("quest").ToString();
        ShowMenuTextEvent?.Invoke(headtext, commentText, exitSureText);
        if (exitInfo.SelectToken("text") != null && exitInfo.SelectToken("warn") != null)
        {
            string exitText = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("text").ToString());
            string warntext = HtmlToText.Instance.HTMLToTextReplace(exitInfo.SelectToken("warn").ToString());
            ShowExitTextEvent?.Invoke(exitText, warntext);
        }
    }
    public void InvokeOnMeasure(string text)
    {
        OnMeasure?.Invoke(text);
    }
    public void OnReasonInvoke(string name)
    {
        OnReason?.Invoke(name);
    }
    public void OnMenuInvoke()
    {
        OnMenu?.Invoke();
    }
    public void InvokeEndTween(string location)
    {
        EndTween?.Invoke(location);
    }
}
