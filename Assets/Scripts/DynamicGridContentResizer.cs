using UnityEngine;
using UnityEngine.UI;

public class DynamicGridContentResizer : MonoBehaviour
{
    public GridLayoutGroup gridLayout;       // Grid mit Zellen, Padding und Abstand
    public RectTransform contentRect;        // RectTransform des Containers, dessen Höhe angepasst wird
    public int columnCount = 3;               // Anzahl Spalten (z.B. 3 Karten pro Zeile)

    void Start()
    {
        ResizeContent();
    }

    public void ResizeContent()
    {
        int totalItems = contentRect.childCount;                           // Anzahl der Kinder (Karten)
        int rowCount = Mathf.CeilToInt((float)totalItems / columnCount);  // Anzahl Zeilen, aufgerundet

        // Höhe berechnen: Padding oben + Höhe der Zeilen + Abstände + Padding unten
        float totalHeight = gridLayout.padding.top +
                            (rowCount * gridLayout.cellSize.y) +
                            ((rowCount - 1) * gridLayout.spacing.y) +
                            gridLayout.padding.bottom;

        // Content-Rect transform auf neue Höhe setzen (Breite bleibt gleich)
        contentRect.sizeDelta = new Vector2(contentRect.sizeDelta.x, totalHeight);
    }
}
