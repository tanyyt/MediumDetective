using System.Collections;
using System.Collections.Generic;
using Febucci.UI;
using TMPro;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    private TextMeshPro m_TextMeshPro;
    private TypewriterByCharacter m_Typewriter;
    public float hideTime = 1.0f;
    public bool isLoop;
    
    void OnEnable()
    {
        m_TextMeshPro = GetComponent<TextMeshPro>();
        m_Typewriter = GetComponent<TypewriterByCharacter>();
        StartCoroutine(Looping());
    }

    private IEnumerator Looping()
    {
        m_Typewriter.ShowText(m_TextMeshPro.text);
        yield return new WaitForSeconds(hideTime);
        m_Typewriter.StartDisappearingText();
        
        while (isLoop)
        {
            m_Typewriter.ShowText(m_TextMeshPro.text);
            yield return new WaitForSeconds(hideTime);
            m_Typewriter.StartDisappearingText();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
