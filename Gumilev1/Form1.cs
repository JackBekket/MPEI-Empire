using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Gumilev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // Объяснение задачи и переменных
        //
        // A - знакопеременный параметр пассионарной напряженности
        // x - G - "сложность" гос-ва (структуры)
        // l1 - лимит капитала на укрепление политического режима
        // l2 - лимит капитала на экономику
        // y - E - уровень эконом. развития (кол-во фондов)
        // k1 - коэффицент вливания капитала в гос-во
        // k2 - коэффицент вливания капитала в экономику
        //




        //Определение входных, выходных данных, правила рассчета МОДЕЛИ

        //константы
      //  const double alfa = 0.2;

        //функции рассчета точек МОДЕЛИ

        //для данной задачи
        
        //возвращает график развития гос-ва (структуры)
        double o1(double a, double x1, double l1, double y1, double k1)
        {
            return (a * x1 + l1 * y1 - k1 * Math.Pow(y1,2));
        }

        //возвращает график развития экономики
        double o2(double a, double x1, double l2, double y1, double k2)
        {
            return (a * y1 - l2 * x1 + k2 * Math.Pow(x1, 2));
        }


      


        //функция рисования ГРАФИКА

     
        //задача
        void DrawGraph11(double a, double x1, double y1, double l1, double l2, double k1, double k2 )
        {
            // Получим панель для рисования
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.XAxis.Title.Text = "x, Развитие Государственной структуры";
            pane.YAxis.Title.Text = "y, Развитие Экономической структуры";
            pane.Title.Text = "Модель 'политика-экономика'";

            // Очистим компонент
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList tr_list = new PointPairList();
            PointPairList tr_list2 = new PointPairList();
     //       PointPairList tr_list3 = new PointPairList();

            double xmin = -5;
            double xmax = 5;

            double ymin = -5;
            double ymax = 5;

        /*
            //Двойной
            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                for (double y = ymin; y <= ymax; y += 0.01)
                {
                    // добавим в список точку

                    //  tr_list2.Add(x, o2(a, x, l2, y1, k2));
                    tr_list.Add(x, o1(a, x, l1, y, k1));

                    tr_list2.Add(y, o2(a, x, l2, y, k2));
                    //orig
                    //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
                    //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
                }
            }
            */
          



            
            // Заполняем список точек
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                // добавим в список точку
            
                //  tr_list2.Add(x, o2(a, x, l2, y1, k2));
                tr_list.Add(x, o1(a, x1, l1, x, k1));


                //orig
           //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
                //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
            }

            // Заполняем список точек
            for (double y = ymin; y <= ymax; y += 0.01)
            {
                // добавим в список точку
        
             //   tr_list.Add(y, o1(a, x1, l1, y, k1));
                tr_list2.Add(o2(a, y, l2, y1, k2),y);

                //orig
                //     tr_list.Add(x, o1(a, x1, l1, y1, k1));
            //    tr_list2.Add(y, o2(a,x1,l2,y1,k2));
            }
            



            /*
            for (double x = xmin; x <= xmax; x += 0.01)
            {
                tr_list3.Add(x, n);
            }
              */

            // Создадим кривую 
            // которая будет рисоваться голубым цветом (Color.Blue),
            // Опорные точки выделяться не будут (SymbolType.None)
            LineItem myCurve1 = pane.AddCurve("Развитие гос.структур", tr_list, Color.Blue, SymbolType.None);
            LineItem myCurve2 = pane.AddCurve("Развитие экономики", tr_list2, Color.Green, SymbolType.None);

      //      LineItem myCurve3 = pane.AddCurve("Минимально допустимый уровень лекарства", tr_list3, Color.Red, SymbolType.None);

            // Включим отображение сетки
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraphControl1.AxisChange();

            // Обновляем график
            zedGraphControl1.Invalidate();
        }


        //Функция загрузки формы
        //и чего-то еще
        // и еще чего-то еще
        private void Form1_Load(object sender, EventArgs e)
        {
            //Первый таб
            //ВВОДИМ ПЕРЕМЕНЫЕ

           // double m = trackBar11.Value * 0.001;

         //   double a = trackBar1.Value;

            double a = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Пассионарная напряженность= " + a.ToString();

            double x1 = Convert.ToDouble(trackBar2.Value);
            groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();

            double y1 = Convert.ToDouble(trackBar3.Value);
            groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
           // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);

            /*
            label1.Text = "Объем препарата равен " + m.ToString();
            double v = Convert.ToDouble(trackBar12.Value) / 20 + 5;
            label12.Text = "Объем крови равен " + v.ToString();
            double k1 = (Convert.ToDouble(trackBar13.Value) - 20) / 10;
            label13.Text = "Коэффициент удаления первого препарата равен " + k1.ToString();
            double k2 = (Convert.ToDouble(trackBar14.Value) - 20) / 10;
            label14.Text = "Коэффициент удаления второго препарата равен " + k2.ToString();
            label15.Text = "Концентрация первого препарата убывает, т.к. коэффициент удаления (k1) > 0";
            label16.Text = "Концентрация второго препарата убывает, т.к. коэффициент удаления (k2) > 0";
            double n = trackBar15.Value * 0.00005;
            label17.Text = "Объем препарата равен " + n.ToString();
            DrawGraph1(m, v, k1, k2, n);
            */

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            groupBox1.Text = "Пассионарная напряженность= " + a.ToString();
            //правила если-то

            double x1 = Convert.ToDouble(trackBar2.Value);
          //  groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();

            double y1 = Convert.ToDouble(trackBar3.Value);
       //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
        //    groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
       //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
        //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
         //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
          //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();
            

            double x1 = Convert.ToDouble(trackBar2.Value);
              groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();
            //правила если-то

            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            //    groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
          //  groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();
           

            double y1 = Convert.ToDouble(trackBar3.Value);
                 groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();
            //правила если-то

            double l1 = Convert.ToDouble(trackBar4.Value);
            //    groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();

            double k1 = Convert.ToDouble(trackBar5.Value);
            //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
         //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();
            

            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
               groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();
            //  ПРАВИЛА


            double k1 = Convert.ToDouble(trackBar5.Value);
            //     groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();

            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
            //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();


            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
         //   groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();
            


            double k1 = Convert.ToDouble(trackBar5.Value);
                 groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();
            //ПРАВИЛА


            double l2 = Convert.ToDouble(trackBar6.Value);
            //    groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
            //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();


            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            //   groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();



            double k1 = Convert.ToDouble(trackBar5.Value);
          //  groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();
            


            double l2 = Convert.ToDouble(trackBar6.Value);
                groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();
            //ПРАВИЛА

            double k2 = Convert.ToDouble(trackBar7.Value);
            //   groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(trackBar1.Value);
            //  groupBox1.Text = "Пассионарная напряженность= " + a.ToString();


            double x1 = Convert.ToDouble(trackBar2.Value);
            //   groupBox2.Text = "Базовая сложность структуры государства= " + x1.ToString();


            double y1 = Convert.ToDouble(trackBar3.Value);
            //     groupBox3.Text = "Базовая сложность экономической структуры= " + y1.ToString();

            double l1 = Convert.ToDouble(trackBar4.Value);
            //   groupBox4.Text = "Лимит вливаний в гос-структуру= " + l1.ToString();



            double k1 = Convert.ToDouble(trackBar5.Value);
            //  groupBox5.Text = "Коэффицент вливания капитала в государство " + k1.ToString();



            double l2 = Convert.ToDouble(trackBar6.Value);
         //   groupBox6.Text = "Лимит вливаний в экономику= " + l2.ToString();
            

            double k2 = Convert.ToDouble(trackBar7.Value);
               groupBox7.Text = "Коэффицент вливания капитала в экономику= " + k2.ToString();
            //ПРАВИЛА

            //Отрисовываем графы
            //первый граф
            // DrawGraph11
            DrawGraph11(a, x1, y1, l1, l2, k1, k2);
        }

        






    }

}
