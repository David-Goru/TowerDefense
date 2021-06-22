﻿using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a class
/// </summary>
public class EntityInfoUI : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] GameObject ui = null;

    [Header("Debug")]
    [SerializeField] Entity currentEntity;

    public static EntityInfoUI Instance;

    void Start()
    {
        Instance = this;
        enabled = false;

        if (ui == null) Debug.Log("EntityInfoUI doesn't have a UI defined.");
    }

    void Update()
    {
        if (enabled)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (!Physics.Raycast(ray, out hit) || hit.transform != currentEntity.transform) disableUI();
            }
            else if (currentEntity.IsDead) disableUI();
            else updateUI();
        }
    }

    public void ShowUI(Entity entity)
    {
        if (ui == null) return;

        int yPos = hasUpperScreenSpaceAvailable(240) ? 120 : -120;
        ui.transform.position = Input.mousePosition + new Vector3(0, yPos, 0);
        currentEntity = entity;
        enableUI();
    }

    void updateUI()
    {
        ui.transform.Find("Others").GetComponent<Text>().text = currentEntity.GetExtraInfo();
        ui.transform.Find("Title").GetComponent<Text>().text = currentEntity.Title;
        ui.transform.Find("HP").GetComponent<Text>().text = string.Format("{0}/{1}", currentEntity.CurrentHP, currentEntity.MaxHP);
    }

    void enableUI()
    {
        updateUI();
        if (ui != null) ui.SetActive(true);
        enabled = true;
    }

    void disableUI()
    {
        if (ui != null) ui.SetActive(false);
        enabled = false;
    }

    bool hasUpperScreenSpaceAvailable(int pixelsRequired)
    {
        return (Input.mousePosition.y + pixelsRequired) < Screen.height;
    }
}