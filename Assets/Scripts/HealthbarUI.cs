using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private LifeController life;
    [SerializeField] private Image fill;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private Gradient grad;

    private void Start()
    {
        life.AddLifeListener(UpdateGraphics);
    }

    private void OnDestroy()
    {
        life.RemoveLifeListener(UpdateGraphics);
    }

    public void UpdateGraphics(float currentHp, float maxHp)
    {
        lifeText.text = $"HP: {currentHp} / {maxHp}";
        fill.fillAmount = currentHp / maxHp;
        fill.color = grad.Evaluate(currentHp / maxHp);
    }
}
