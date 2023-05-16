using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] snake s1;
    [SerializeField] snake s2;
    private int score_t;
    private int score_previous=0;

    private bool ischanging=false;

    void Update()
    {
        score_t = s1.get_l() + s2.get_l();
        score.text= "SCoRe:" + score_t.ToString();

        if (score_t > score_previous)
        {
            if(!ischanging)
                StartCoroutine(changing());
        }
        score_previous = score_t;
    }
    protected IEnumerator changing() {
        ischanging= true;
        Color c=score.color;
        int s=score.fontSize;
        score.fontSize += 2;
        score.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        score.fontSize = s;
        score.color = c;
        ischanging= false;
    }
}
