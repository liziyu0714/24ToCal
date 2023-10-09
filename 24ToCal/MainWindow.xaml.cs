using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _24ToCal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool found = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Find(int.Parse(t1.Text), int.Parse(t2.Text), int.Parse(t3.Text), int.Parse(t4.Text));
        }

        private void Find(int t1, int t2, int t3, int t4)
        {
            found = false;
            output.Text = "";
            List<Node> nodes = new List<Node>
            {
                new Node(t1, t1.ToString()),
                new Node(t2, t2.ToString()),
                new Node(t3, t3.ToString()),
                new Node(t4, t4.ToString())
            };
            countProcess(nodes);
            if(!found)
            {
                output.Text += "No solution!!!\r\n";
            }
            output.Text += "Powered by liziyu0714 , open source at in GPLv3 , happy coding!";
        }
        private void countProcess(List<Node> list)
        {
            if (list.Count < 2)
                return;
            if (list.Count == 2)
            {
                if (list[0].value + list[1].value == 24)
                {
                    output.Text += (list[0].exp + "+" + list[1].exp) + "=24\r\n"; found = true;
                }
                if (list[0].value * list[1].value == 24)
                {
                    output.Text += (list[0].exp + "*" + list[1].exp) + "=24\r\n"; found = true;
                }
                if (list[0].value / list[1].value == 24)
                {
                    output.Text += (list[0].exp + "/" + list[1].exp) + "=24\r\n"; found = true;
                }
                if (list[1].value / list[0].value == 24)
                {
                    output.Text += (list[1].exp + "/" + list[0].exp) + "=24\r\n"; found = true;
                }
                if (list[0].value - list[1].value == 24)
                {
                    output.Text += (list[0].exp + "-" + list[1].exp) + "=24\r\n"; found = true;
                }
                if (list[1].value - list[0].value == 24)
                {
                    output.Text += (list[1].exp + "-" + list[0].exp) + "=24\r\n"; found = true;
                }
                
                return;
            }
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    List<Node> clist = new List<Node>(list);
                    //clist.CopyTo()
                    //clist = list;
                    //list.CopyTo(clist);
                    clist.Remove(list[i]);
                    clist.Remove(list[j]);

                    double a = list[i].value + list[j].value;
                    Node aa = new Node();
                    aa.value = a;
                    aa.exp = "(" + list[i].exp + "+" + list[j].exp + ")";
                    clist.Add(aa);
                    countProcess(clist);
                    clist.Remove(aa);

                    double b = list[i].value * list[j].value;
                    Node bb = new Node();
                    bb.value = b;
                    bb.exp = "(" + list[i].exp + "*" + list[j].exp + ")";
                    clist.Add(bb);
                    countProcess(clist);
                    clist.Remove(bb);

                    double c = list[i].value - list[j].value;
                    Node cc = new Node();
                    cc.value = c;
                    cc.exp = "(" + list[i].exp + "-" + list[j].exp + ")";
                    clist.Add(cc);
                    countProcess(clist);
                    clist.Remove(cc);


                    double d = list[j].value - list[i].value;
                    Node dd = new Node();
                    dd.value = d;
                    dd.exp = "(" + list[j].exp + "-" + list[i].exp + ")";
                    clist.Add(dd);
                    countProcess(clist);
                    clist.Remove(dd);

                    if (list[j].value != 0)
                    {
                        double e = list[i].value / list[j].value;
                        Node ee = new Node();
                        ee.value = e;
                        ee.exp = "(" + list[i].exp + "/" + list[j].exp + ")";
                        clist.Add(ee);
                        countProcess(clist);
                        clist.Remove(ee);
                    }


                    if (list[i].value != 0)
                    {
                        double f = list[j].value / list[i].value;
                        Node ff = new Node();
                        ff.value = f;
                        ff.exp = "(" + list[j].exp + "/" + list[i].exp + ")";
                        clist.Add(ff);
                        countProcess(clist);
                        clist.Remove(ff);
                    }




                }
            }
        }
        class Node
        {
            public Node(double val, String e)
            {
                value = val;
                exp = e;
            }
            public Node()
            {

            }
            public double value;
            public String exp;
        }


    }   
}

