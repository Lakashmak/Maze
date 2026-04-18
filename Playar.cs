/*
 * Сделано в SharpDevelop.
 * Пользователь: Лаврентий
 * Дата: 21.03.2019
 * Время: 21:48
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace лаберинт
{
	/// <summary>
	/// Description of Playar.
	/// </summary>
	public class Playar
	{
		public int x;
		public int y;
		public Graphics gr;
		public Pen pen;
		public Playar(int x, int y, Graphics gr, Pen pen)
		{
			this.x=x;
			this.y=y;
			this.gr=gr;
			this.pen=pen;
		}
		public void drawPlayar()
		{
			gr.DrawLine(pen , x+25 , y+25 , x+25 , y-25);
			gr.DrawLine(pen , x-25 , y-25 , x+25 , y-25);
			gr.DrawLine(pen , x-25 , y-25 , x-25 , y+25);
			gr.DrawLine(pen , x+25 , y+25 , x-25 , y+25);
			gr.DrawLine(pen , x+25 , y+25 , x-25 , y-25);
			gr.DrawLine(pen , x+25 , y-25 , x-25 , y+25);
		}
	}
}
