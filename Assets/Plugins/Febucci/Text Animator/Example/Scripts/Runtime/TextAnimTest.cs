using System;
using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TextAnimTest : MonoBehaviour
{
    public TypewriterByCharacter textAnimatorPlayer;
    public string[] textToShow;

    public Button nextBtn;

    private int index = 0;

    private void OnEnable()
    {
        nextBtn.onClick.AddListener(ShowNextText);

        //字体完全播放完毕时的事件注册
        textAnimatorPlayer.onTextShowed.AddListener(Complete);
    }

    private void OnDisable()
    {
        nextBtn.onClick.RemoveListener(ShowNextText);

        textAnimatorPlayer.onTextShowed.RemoveListener(Complete);
    }

    private void ShowNextText()
    {
        //判断当前文本是否在播放
        if (textAnimatorPlayer.isShowingText)
        {
            //跳过文本播放动画的方法
            textAnimatorPlayer.SkipTypewriter();
        }
        else
        {
            //逐字显示文本的方法
            textAnimatorPlayer.ShowText(textToShow[index]);
        }
    }

    //文本播放完毕调用的方法
    private void Complete()
    {
        index++;
        if (index == textToShow.Length)
        {
            index = 0;
        }
        Debug.Log("文本完全显示");
    }
}
