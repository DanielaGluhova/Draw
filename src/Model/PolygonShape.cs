using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class PolygonShape : Shape
	{
		#region Constructor

		public PolygonShape(RectangleF rect) : base(rect)
		{
		}

		public PolygonShape(PolygonShape polygon) : base(polygon)
		{
		}

		#endregion

		/// <summary>
		/// Проверка за принадлежност на точка point към правоъгълника.
		/// В случая на правоъгълник този метод може да не бъде пренаписван, защото
		/// Реализацията съвпада с тази на абстрактния клас Shape, който проверява
		/// дали точката е в обхващащия правоъгълник на елемента (а той съвпада с
		/// елемента в този случай).
		/// </summary>
		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
				// Проверка дали е в обекта само, ако точката е в обхващащия правоъгълник.
				// В случая на правоъгълник - директно връщаме true
				return true;
			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;
		}

		/// <summary>
		/// Частта, визуализираща конкретния примитив.
		/// </summary>
		public override void DrawSelf(Graphics grfx)
		{

			Point point1 = new Point(50, 50);
			Point point2 = new Point(100, 25);
			Point point3 = new Point(200, 5);
			Point point4 = new Point(250, 50);
			Point point5 = new Point(300, 100);
			Point point6 = new Point(350, 200);
			Point point7 = new Point(250, 250);
			Point[] curvePoints =
					 {
				 point1,
				 point2,
				 point3,
				 point4,
				 point5,
				 point6,
				 point7 };

			base.DrawSelf(grfx);

			grfx.FillPolygon(new SolidBrush(FillColor), curvePoints);
			grfx.DrawPolygon(Pens.Black, curvePoints);
			
			 
		}
	}
}