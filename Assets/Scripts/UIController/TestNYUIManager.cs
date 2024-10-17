using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TestNYUIManager : MonoBehaviour
{
    public RectTransform stagePanel;
    public RectTransform stageMainPanel;

    public void StageButton()
    {
        stageMainPanel.DOAnchorPos(new Vector2(-1080, 0), 0.25f);
        stagePanel.DOAnchorPos(new Vector2(0, 0), 0.25f);
    }

    public void BackButton()
    {
        stageMainPanel.DOAnchorPos(new Vector2(0, 0), 0.25f);
        stagePanel.DOAnchorPos(new Vector2(1080, 0), 0.25f);
    }
}
