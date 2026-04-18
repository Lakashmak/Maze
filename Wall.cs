/*
 * Сделано в SharpDevelop.
 * Пользователь: Лаврентий
 * Дата: 21.03.2019
 * Время: 21:47
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace лаберинт
{
	/// <summary>
	/// Description of Wall.
	/// </summary>
	public class Wall
	{
		public Graphics gr;
		public Pen pen;
		public int x1;
		public int y1;
		public int x2;
		public int y2;
		public Wall(Graphics gr, Pen pen, int x1, int y1, int x2, int y2)
		{
			this.gr=gr;
			this.pen=pen;
			this.x1=x1;
			this.y1=y1;
			this.x2=x2;
			this.y2=y2;
		}
		public void drawWall()
		{
			gr.DrawRectangle(pen, x1, y1, x2, y2);
		}
	}
}
