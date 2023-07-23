using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleGridLayout : LayoutGroup
{
    public int rows;
    public int columns;
    public Vector2 CellSize;
    public Vector2 Spacing;

    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float SquareRoot = Mathf.Sqrt(transform.childCount);
        rows = Mathf.CeilToInt(SquareRoot);
        columns = Mathf.CeilToInt(SquareRoot);

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = parentWidth / (float)columns - ((Spacing.x / (float)columns) * 2);
        float cellHeight = parentHeight / (float)rows - ((Spacing.y / (float)rows) * 2);

        CellSize.x = cellWidth;
        CellSize.y = cellHeight;

        int columnCount = 0;
        int rowCount = 0;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            rowCount = i / columns;
            columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = (CellSize.x * columnCount) + (Spacing.x * columnCount);
            var yPos = (CellSize.y * rowCount) + (Spacing.y * rowCount);

            SetChildAlongAxis(item, 0, xPos, CellSize.x);
            SetChildAlongAxis(item, 1, yPos, CellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
    }
    public override void SetLayoutHorizontal()
    {
    }
    public override void SetLayoutVertical()
    {
    }
}
