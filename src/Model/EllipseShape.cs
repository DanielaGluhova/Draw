using System;
using System.Drawing;

namespace Draw
{
	/// <summary>
	/// Класът правоъгълник е основен примитив, който е наследник на базовия Shape.
	/// </summary>
	public class EllipseShape : Shape
	{
		#region Constructor

		public EllipseShape(RectangleF ellipse) : base(ellipse)
		{
		}

		public EllipseShape(EllipseShape ellipse) : base(ellipse)
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


		/*
		 * public static int checkpoint(int Rectangle.X, int Rectangle.Y, int Rectangle.Height, int Rectangle.With)
		{

			int p = ((int)Math.Pow((x ), 2) /
					 (int)Math.Pow(a, 2)) +
					((int)Math.Pow((y ), 2) /
					 (int)Math.Pow(b, 2));

			return p;
		}
		*/



		public override bool Contains(PointF point)
		{
			if (base.Contains(point))
			{

				/*


				if (checkpoint(x,y,a,b) < 1)

					return true;

				else return false;*/
				return true;
			}

			else
				// Ако не е в обхващащия правоъгълник, то неможе да е в обекта и => false
				return false;



		}
	

	/// <summary>
	/// Частта, визуализираща конкретния примитив.
	/// </summary>
		public override void DrawSelf(Graphics grfx)
		{
			base.DrawSelf(grfx);

			grfx.FillEllipse(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Width);
			grfx.DrawEllipse(new Pen(BorderColor), Rectangle.X, Rectangle.Y, Rectangle.Height, Rectangle.Width);

		}
	}

}
