using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Draw
{
	/// <summary>
	/// Върху главната форма е поставен потребителски контрол,
	/// в който се осъществява визуализацията
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Агрегирания диалогов процесор във формата улеснява манипулацията на модела.
		/// </summary>
		private DialogProcessor dialogProcessor = new DialogProcessor();
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		/// <summary>
		/// Изход от програмата. Затваря главната форма, а с това и програмата.
		/// </summary>
		void ExitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Close();
		}
		
		/// <summary>
		/// Събитието, което се прихваща, за да се превизуализира при изменение на модела.
		/// </summary>
		void ViewPortPaint(object sender, PaintEventArgs e)
		{
			dialogProcessor.ReDraw(sender, e);
		}
		
		/// <summary>
		/// Бутон, който поставя на произволно място правоъгълник със зададените размери.
		/// Променя се лентата със състоянието и се инвалидира контрола, в който визуализираме.
		/// </summary>
		void DrawRectangleSpeedButtonClick(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomRectangle();
			
			statusBar.Items[0].Text = "Последно действие: Рисуване на правоъгълник";
			
			viewPort.Invalidate();
		}
		void EllipseButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomEllipse();

			statusBar.Items[0].Text = "Последно действие: Рисуване на елипса";

			viewPort.Invalidate();
		}

		void LineButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomLine();

			statusBar.Items[0].Text = "Последно действие: Рисуване на линия";

			viewPort.Invalidate();
		}

		void PolygonButton_Click(object sender, EventArgs e)
		{
			dialogProcessor.AddRandomPolygon();

			statusBar.Items[0].Text = "Последно действие: Рисуване на многоъгълник";

			viewPort.Invalidate();
		}

		/// <summary>
		/// Прихващане на координатите при натискането на бутон на мишката и проверка (в обратен ред) дали не е
		/// щракнато върху елемент. Ако е така то той се отбелязва като селектиран и започва процес на "влачене".
		/// Промяна на статуса и инвалидиране на контрола, в който визуализираме.
		/// Реализацията се диалогът с потребителя, при който се избира "най-горния" елемент от екрана.
		/// </summary>
		void ViewPortMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (pickUpSpeedButton.Checked) {
				dialogProcessor.Selection = dialogProcessor.ContainsPoint(e.Location);
				if (dialogProcessor.Selection != null) {
					statusBar.Items[0].Text = "Последно действие: Селекция на примитив";
					dialogProcessor.IsDragging = true;
					dialogProcessor.LastLocation = e.Location;
					viewPort.Invalidate();
				}
			}
		}

		/// <summary>
		/// Прихващане на преместването на мишката.
		/// Ако сме в режм на "влачене", то избрания елемент се транслира.
		/// </summary>
		void ViewPortMouseMove(object sender, MouseEventArgs e)
		{
			if (dialogProcessor.IsDragging) {
				if (dialogProcessor.Selection != null) statusBar.Items[0].Text = "Последно действие: Влачене";
				dialogProcessor.TranslateTo(e.Location);
				viewPort.Invalidate();
			}
		}

		/// <summary>
		/// Прихващане на отпускането на бутона на мишката.
		/// Излизаме от режим "влачене".
		/// </summary>
		void ViewPortMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dialogProcessor.IsDragging = false;
		}

         void btnFill_Click(object sender, EventArgs e)
        {

			if (colorDialog1.ShowDialog() == DialogResult.OK)
			{
                dialogProcessor.Selection.FillColor = colorDialog1.Color;
				viewPort.Invalidate();
            }
        }

        private void SquareButton_Click(object sender, EventArgs e)
        {
			dialogProcessor.AddRandomSquare();

			statusBar.Items[0].Text = "Последно действие: Рисуване на квадрат";

			viewPort.Invalidate();
		}

 
	}
}
