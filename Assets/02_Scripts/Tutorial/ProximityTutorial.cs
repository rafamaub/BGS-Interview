using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class ProximityTutorial : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutorialText.DOComplete();
        tutorialText.DOFade(1f, 0.5f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tutorialText.DOComplete();
        tutorialText.DOFade(0, 0.5f);
    }
}
