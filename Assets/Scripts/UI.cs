using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public TimelineAsset resetAsset;
    public TimelineAsset smellAsset;
    public TimelineAsset visionAsset;
    public TimelineAsset hearingAsset;
    public TimelineAsset sunFlowerAsset;

    public GameObject successText;
    public GameObject failureText;
    public GameObject resultPanel;
    public Button retryButton;
    public Button confirmAnswerButton;
    public Button answerButton;
    public Button closeAnswerButton;
    public GameObject answerPanel;
    public GameObject helpPanel;
    public Toggle[] correctAnswers;

    private Coroutine m_Coroutine;

    void Awake()
    {
        answerButton.onClick.AddListener(ShowAnswerPanel);
        closeAnswerButton.onClick.AddListener(HideAnswerPanel);
        confirmAnswerButton.onClick.AddListener(OnAnswerClick);
        retryButton.onClick.AddListener(OnRetryClick);
    }

    private void OnDestroy()
    {
        answerButton.onClick.RemoveListener(ShowAnswerPanel);
        closeAnswerButton.onClick.RemoveListener(HideAnswerPanel);
        confirmAnswerButton.onClick.RemoveListener(OnAnswerClick);
        retryButton.onClick.RemoveListener(OnRetryClick);
    }

    public void ShowAnswerPanel()
    {
        answerPanel.SetActive(true);
    }

    public void HideAnswerPanel()
    {
        answerPanel.SetActive(false);
    }

    public void OnAnswerClick()
    {
        answerPanel.SetActive(false);
        resultPanel.SetActive(true);
        for (var i = 0; i < correctAnswers.Length; i++)
        {
            if (!correctAnswers[i].isOn)
            {
                failureText.SetActive(true);
                successText.SetActive(false);
                return;
            }
        }
        failureText.SetActive(false);
        successText.SetActive(true);
    }

    private void OnRetryClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowHelpPanel()
    {
        helpPanel.SetActive(true);
    }

    public void HideHelpPanel()
    {
        helpPanel.SetActive(false);
    }

    public void OnSmellButtonDown()
    {
        playableDirector.playableAsset = smellAsset;
        playableDirector.Play();
        m_Coroutine = StartCoroutine(WaitForStop((float)playableDirector.playableAsset.duration));
    }

    public void OnVisionButtonDown()
    {
        playableDirector.playableAsset = visionAsset;
        playableDirector.Play();
        m_Coroutine = StartCoroutine(WaitForStop((float)playableDirector.playableAsset.duration));
    }

    public void OnHearingButtonDown()
    {
        playableDirector.playableAsset = hearingAsset;
        playableDirector.Play();
        m_Coroutine = StartCoroutine(WaitForStop((float)playableDirector.playableAsset.duration));
    }

    public void OnSunFlowerButtonDown()
    {
        playableDirector.playableAsset = sunFlowerAsset;
        playableDirector.Play();
        m_Coroutine = StartCoroutine(WaitForStop((float)playableDirector.playableAsset.duration));
    }

    public void OnButtonUp()
    {
        if (null != m_Coroutine)
        {
            StopCoroutine(m_Coroutine);
        }
        playableDirector.playableAsset = resetAsset;
        playableDirector.Play();
        m_Coroutine = null;
    }

    private IEnumerator WaitForStop(float time)
    {
        yield return new WaitForSeconds(time);
        yield return null;
        if (null != m_Coroutine)
        {
            OnButtonUp();
        }
    }
}
