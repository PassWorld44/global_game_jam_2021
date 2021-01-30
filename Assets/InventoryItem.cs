using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_image;
    [SerializeField] private Inventory m_inventory;
    [SerializeField] private SpriteRenderer m_inBounds;
    [SerializeField] private Vector3Int m_cellIndex;

    void Start()
    {

    }

    void Update()
    {
        // Mouse follow
        var point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(point.x, point.y, 0f);

        // Check if over inventory
        var inventoryBounds = m_inventory.GetBounds();
        var overInventory = inventoryBounds.Contains(transform.position);

        m_inBounds.gameObject.SetActive(overInventory);

        if (overInventory)
        {
            m_cellIndex = m_inventory.GetCellIndexFromPosition(transform.position);
            transform.position = m_inventory.GetPositionFromCellIndex(m_cellIndex);
        }
    }
}