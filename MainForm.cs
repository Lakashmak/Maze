/*
 * Сделано в SharpDevelop.
 * Пользователь: Лаврентий
 * Дата: 21.03.2019
 * Время: 21:44
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace лаберинт
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int pob = 0;
		int pob2 = 0;
		int onul = 0;
		int colpl = 0;
		Random rnd = new Random();
		int x = 50;
		int y = 50;
		int z1;
		int z2;
		int colen;
		int nap;
		Graphics gr;
		Pen pen;
		Pen pen2;
		Pen pen3;
		Pen pen4;
		Bitmap bitmap;
		List<Playar> list = new List<Playar>();
		List<Wall> walls = new List<Wall>();
		List<Playar> enemies = new List<Playar>();
		List<Playar> playars = new List<Playar>();
		List<Playar> playar1 = new List<Playar>();
		Playar finish;
		public MainForm()
		{
			InitializeComponent();
			label1.Text="безсмертность: "+pob+"/250";
			label2.Text="новый друг:"+pob2+"/25";
			label3.Text="друзей:"+colpl;
			colen = rnd.Next(1,4);
			z1 = rnd.Next(0,37);
			z2 = rnd.Next(0,25);
			nap = rnd.Next(1,5);
			pen = new Pen(Color.White);
			pen2 = new Pen(Color.Red);
			pen3 = new Pen(Color.Green);
			pen4 = new Pen(Color.Yellow);
			bitmap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
			gr = Graphics.FromImage(bitmap);
			gr.Clear(Color.Black);
			finish = new Playar(z1*25,z2*25,gr,pen3);
			z1 = rnd.Next(0,37);
			z2 = rnd.Next(0,25);
			Generator();
			list.Add(new Playar(x,y,gr,pen));
			for(int i = 0; i < colen; i++)
			{
				enemies.Add(new Playar(z1*25,z2*25,gr,pen2));
				z1 = rnd.Next(0,37);
				z2 = rnd.Next(0,25);
			}
			for(int i = 0; i < colen; i++)
			{
				playars.Add(new Playar(z1*25,z2*25,gr,pen4));
				z1 = rnd.Next(0,37);
				z2 = rnd.Next(0,25);
			}
			list[0].drawPlayar();
			finish.drawPlayar();
			foreach(Wall element in walls)
			{
				element.drawWall();
			}
			foreach(Playar element in enemies)
			{
				element.drawPlayar();
			}
			foreach(Playar element in playars)
			{
				element.drawPlayar();
			}
			pictureBox1.Image = bitmap;
		}
		
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			if(pob >= 250)
			{
				label1.Text="вы безсмертны";
			}
			if(pob < 250)
			{
				label1.Text="безсмертность: "+pob+"/250";
			}
			if(pob2 >= 25)
			{
				playar1.Add(new Playar(z1*25,z2*25,gr,pen));
				z1 = rnd.Next(0,37);
				z2 = rnd.Next(0,25);
				pob2 = pob2 - 25;
				colpl++;
			}
			z1 = rnd.Next(0,37);
			z2 = rnd.Next(0,25);
			colen = rnd.Next(1,4);
			gr.Clear(Color.Black);
			if(e.KeyCode == Keys.D)
			{
				if(list[0].x+25 < pictureBox1.Width-25)
				{
					list[0].x+=25;
				}
			}
			gr.Clear(Color.Black);
			if(e.KeyCode == Keys.A)
			{
				if(list[0].x-25 > 0)
				{
					list[0].x+=-25;
				}
			}
			gr.Clear(Color.Black);
			if(e.KeyCode == Keys.S)
			{
				if(list[0].y+25 < pictureBox1.Height-25)
				{
					list[0].y+=25;
				}
			}
			gr.Clear(Color.Black);
			if(e.KeyCode == Keys.W)
			{
				if(list[0].y-25 > 0)
				{
					list[0].y+=-25;
				}
			}
			foreach(Playar element in enemies)
			{
				if(nap == 1)
				{
					if(element.x+25 < pictureBox1.Width-25)
					{
						element.x+=25;
					}
				}
				if(nap == 2)
				{
					if(element.y+25 < pictureBox1.Height-25)
					{
						element.y+=25;
					}
				}
				if(nap == 3)
				{
					if(element.x-25 > 0)
					{
						element.x+=-25;
					}
				}
				if(nap == 4)
				{
					if(element.y-25 > 0)
					{
						element.y+=-25;
					}
				}
				nap = rnd.Next(1,5);
			}
			foreach(Playar element in playars)
			{
				if(nap == 1)
				{
					if(element.x+25 < pictureBox1.Width-25)
					{
						element.x+=25;
					}
				}
				if(nap == 2)
				{
					if(element.y+25 < pictureBox1.Height-25)
					{
						element.y+=25;
					}
				}
				if(nap == 3)
				{
					if(element.x-25 > 0)
					{
						element.x+=-25;
					}
				}
				if(nap == 4)
				{
					if(element.y-25 > 0)
					{
						element.y+=-25;
					}
				}
				nap = rnd.Next(1,5);
			}
			if(nap == 1)
			{
				if(finish.x+25 < pictureBox1.Width-25)
				{
					finish.x+=25;
				}
			}
			if(nap == 2)
			{
				if(finish.y+25 < pictureBox1.Height-25)
				{
					finish.y+=25;
				}
			}
			if(nap == 3)
			{
				if(finish.x-25 > 0)
				{
					finish.x+=-25;
				}
			}
			if(nap == 4)
			{
				if(finish.y-25 > 0)
				{
					finish.y+=-25;
				}
			}
			nap = rnd.Next(1,5);
			foreach(Playar element in playar1)
			{
				if(nap == 1)
				{
					if(element.x+25 < pictureBox1.Width-25)
					{
						element.x+=25;
					}
				}
				if(nap == 2)
				{
					if(element.y+25 < pictureBox1.Height-25)
					{
						element.y+=25;
					}
				}
				if(nap == 3)
				{
					if(element.x-25 > 0)
					{
						element.x+=-25;
					}
				}
				if(nap == 4)
				{
					if(element.y-25 > 0)
					{
						element.y+=-25;
					}
				}
				nap = rnd.Next(1,5);
			}
			foreach(Wall element in walls)
			{
				if(list[0].x+25 > element.x1 && list[0].x-25 < element.x1+element.x2)
				{
					if(list[0].y+25 > element.y1 && list[0].y-25 < element.y1+element.y2)
					{
						if(pob < 250)
						{
							onul = 1;
							list[0].x = 50;
							list[0].y = 50;
							finish.x = rnd.Next(0,37);
							finish.y = rnd.Next(0,25);
							finish.x = finish.x*25;
							finish.y = finish.y*25;
						}
					}
				}
			}
			foreach(Playar element in enemies)
			{
				if(list[0].x+25 > element.x-25 && list[0].x-25 < element.x+25)
				{
					if(list[0].y+25 > element.y-25 && list[0].y-25 < element.y+25)
					{
						if(pob < 250)
						{
							onul = 1;
							list[0].x = 50;
							list[0].y = 50;
							finish.x = rnd.Next(0,37);
							finish.y = rnd.Next(0,25);
							finish.x = finish.x*25;
							finish.y = finish.y*25;
						}
					}
				}
			}
			foreach(Playar element in playars)
			{
				if(element.x+25 > finish.x-25 && element.x-25 < finish.x+25)
				{
					if(element.y+25 > finish.y-25 && element.y-25 < finish.y+25)
					{
						onul = 1;
						list[0].x = 50;
						list[0].y = 50;
						finish.x = rnd.Next(0,37);
						finish.y = rnd.Next(0,24);
						finish.x = finish.x*25;
						finish.y = finish.y*25;
					}
				}
			}
			foreach(Playar element in playar1)
			{
				if(element.x+25 > finish.x-25 && element.x-25 < finish.x+25)
				{
					if(element.y+25 > finish.y-25 && element.y-25 < finish.y+25)
					{
						pob2++;
						pob++;
						onul = 1;
						list[0].x = 50;
						list[0].y = 50;
						finish.x = rnd.Next(0,37);
						finish.y = rnd.Next(0,24);
						finish.x = finish.x*25;
						finish.y = finish.y*25;
					}
				}
			}
			if(list[0].x+25 > finish.x-25 && list[0].x-25 < finish.x+25)
			{
				if(list[0].y+25 > finish.y-25 && list[0].y-25 < finish.y+25)
				{
					if(pob < 250)
					{
						pob++;
						label1.Text="безсмертность: "+pob+"/250";
					}
					else
					{
						label1.Text="вы безсмертны";
					}
					pob2++;
					onul = 1;
					list[0].x = 50;
					list[0].y = 50;
					finish.x = rnd.Next(0,37);
					finish.y = rnd.Next(0,24);
					finish.x = finish.x*25;
					finish.y = finish.y*25;
				}
			}
			if(onul == 1)
			{
				Generator();
				for(int i = 0; i < colen; i++)
				{
					enemies.Add(new Playar(z1*25,z2*25,gr,pen2));
					z1 = rnd.Next(0,37);
					z2 = rnd.Next(0,25);
				}
				for(int i = 0; i < colen; i++)
				{
					playars.Add(new Playar(z1*25,z2*25,gr,pen4));
					z1 = rnd.Next(0,37);
					z2 = rnd.Next(0,25);
				}
				onul = 0;
			}
			list[0].drawPlayar();
			foreach(Wall element in walls)
			{
				element.drawWall();
			}
			foreach(Playar element in enemies)
			{
				element.drawPlayar();
			}
			foreach(Playar element in playars)
			{
				element.drawPlayar();
			}
			foreach(Playar element in playar1)
			{
				element.drawPlayar();
			}
			finish.drawPlayar();
			label2.Text="новый друг:"+pob2+"/25";
			label3.Text="друзей:"+colpl;
			pictureBox1.Image = bitmap;
		}
		
		void Generator()
		{
			walls.Clear();
			enemies.Clear();
			playars.Clear();
			int col = rnd.Next(6,25);
			for(int i = 0,pol = rnd.Next(1,3); i < col ; i++, pol = rnd.Next(1,3))
			{
				int a = rnd.Next(0,37)*25;
				int b = rnd.Next(0,25)*25;
				int dli = rnd.Next(1,10)*25;
				if(pol == 1)
				{
					walls.Add(new Wall(gr,pen2,a,b,25,dli));
				}
				if(pol == 2)
				{
					walls.Add(new Wall(gr,pen2,a,b,dli,25));
				}
			}
		}
	}
}

