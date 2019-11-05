using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DesperateDevs.Unity.Editor
{
    public class Graph
    {
        public float xBorder = 48f;
        public float yBorder = 20f;
        public int rightLinePadding = -15;
        public string labelFormat = "{0:0.0}";
        public string axisFormat = "{0:0.0}";
        public int gridLines = 1;
        public float axisRounding = 1f;
        public float anchorRadius = 1f;
        public Color lineColor = Color.magenta;
        private readonly GUIStyle _labelTextStyle;
        private readonly GUIStyle _centeredStyle;
        private readonly Vector3[] _cachedLinePointVerticies;
        private readonly Vector3[] _linePoints;

        public Graph(int dataLength)
        {
            this._labelTextStyle = new GUIStyle(GUI.skin.label);
            this._labelTextStyle.alignment = TextAnchor.UpperRight;
            this._centeredStyle = new GUIStyle();
            this._centeredStyle.alignment = TextAnchor.UpperCenter;
            this._centeredStyle.normal.textColor = Color.white;
            this._linePoints = new Vector3[dataLength];
            this._cachedLinePointVerticies = new Vector3[4]
            {
                new Vector3(-1f, 1f, 0.0f) * this.anchorRadius,
                new Vector3(1f, 1f, 0.0f) * this.anchorRadius,
                new Vector3(1f, -1f, 0.0f) * this.anchorRadius,
                new Vector3(-1f, -1f, 0.0f) * this.anchorRadius
            };
        }

        public void Draw(float[] data, float height)
        {
            Rect rect = GUILayoutUtility.GetRect(EditorGUILayout.GetControlRect().width, height);
            float top = rect.y + this.yBorder;
            float floor = rect.y + rect.height - this.yBorder;
            float availableHeight = floor - top;
            float max = data.Length != 0 ? ((IEnumerable<float>) data).Max() : 0.0f;
            if ((double) max % (double) this.axisRounding != 0.0)
                max = (float) ((double) max + (double) this.axisRounding - (double) max % (double) this.axisRounding);
            this.drawGridLines(top, rect.width, availableHeight, max);
            this.drawAvg(data, top, floor, rect.width, availableHeight, max);
            this.drawLine(data, floor, rect.width, availableHeight, max);
        }

        private void drawGridLines(float top, float width, float availableHeight, float max)
        {
            Color color = Handles.color;
            Handles.color = Color.grey;
            int num1 = this.gridLines + 1;
            float num2 = availableHeight / (float) num1;
            for (int index = 0; index <= num1; ++index)
            {
                float y = top + num2 * (float) index;
                Handles.DrawLine((Vector3) new Vector2(this.xBorder, y), (Vector3) new Vector2(width - (float) this.rightLinePadding, y));
                GUI.Label(new Rect(0.0f, y - 8f, this.xBorder - 2f, 50f), string.Format(this.axisFormat, (object) (float) ((double) max * (1.0 - (double) index / (double) num1))),
                    this._labelTextStyle);
            }

            Handles.color = color;
        }

        private void drawAvg(
            float[] data,
            float top,
            float floor,
            float width,
            float availableHeight,
            float max)
        {
            Color color = Handles.color;
            Handles.color = Color.yellow;
            float num = ((IEnumerable<float>) data).Average();
            float y = floor - availableHeight * (num / max);
            Handles.DrawLine((Vector3) new Vector2(this.xBorder, y), (Vector3) new Vector2(width - (float) this.rightLinePadding, y));
            Handles.color = color;
        }

        private void drawLine(
            float[] data,
            float floor,
            float width,
            float availableHeight,
            float max)
        {
            float num1 = (width - this.xBorder - (float) this.rightLinePadding) / (float) data.Length;
            Color color = Handles.color;
            Rect position = new Rect();
            bool flag = false;
            float num2 = 0.0f;
            Handles.color = this.lineColor;
            Handles.matrix = Matrix4x4.identity;
            HandleUtility.handleMaterial.SetPass(0);
            for (int index = 0; index < data.Length; ++index)
            {
                float num3 = data[index];
                float y = floor - availableHeight * (num3 / max);
                Vector2 vector2_1 = new Vector2(this.xBorder + num1 * (float) index, y);
                this._linePoints[index] = new Vector3(vector2_1.x, vector2_1.y, 0.0f);
                float num4 = 1f;
                if (!flag)
                {
                    float num5 = this.anchorRadius * 3f;
                    float num6 = this.anchorRadius * 6f;
                    Vector2 vector2_2 = vector2_1 - Vector2.up * 0.5f;
                    position = new Rect(vector2_2.x - num5, vector2_2.y - num5, num6, num6);
                    if (position.Contains(Event.current.mousePosition))
                    {
                        flag = true;
                        num2 = num3;
                        num4 = 3f;
                    }
                }

                Handles.matrix = Matrix4x4.TRS(this._linePoints[index], Quaternion.identity, Vector3.one * num4);
                Handles.DrawAAConvexPolygon(this._cachedLinePointVerticies);
            }

            Handles.matrix = Matrix4x4.identity;
            Handles.DrawAAPolyLine(2f, data.Length, this._linePoints);
            if (flag)
            {
                position.y -= 16f;
                position.width += 50f;
                position.x -= 25f;
                GUI.Label(position, string.Format(this.labelFormat, (object) num2), this._centeredStyle);
            }

            Handles.color = color;
        }
    }
}