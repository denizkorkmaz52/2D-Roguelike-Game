using UnityEngine;

public class HealthBar : MonoBehaviour
{
    #region Header GameObject REFERENCES
    [Header("GameObject REFERENCES")]
    #endregion Header GameObject REFERENCES
    #region Tooltip
    [Tooltip("Populate with the child Bar game object")]
    #endregion
    [SerializeField] private GameObject healthBar;

    public void EnableHealthBar()
    {
        gameObject.SetActive(true);
    }

    public void DisableHealthBar()
    {
        gameObject.SetActive(false);
    }

    public void SetHealthBarValue(float healthPercent)
    {
        healthBar.transform.localScale = new Vector3(healthPercent, 1f, 1f);
    }
}
