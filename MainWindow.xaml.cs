using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PortMapper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool hasInputedA = false;
        public bool hasInputedB = false;
        public class dropDownList
        {
            public string content { get; set; }
            public int id { get; set; }
            public int ids { get; set; }
        }
        public MainWindow()
        {
            List<dropDownList> typeA_dropDown = new List<dropDownList>();
            List<dropDownList> typeB_dropDown = new List<dropDownList>();
            InitializeComponent();
            typeA_dropDown.Add(new dropDownList
            {
                content = "TCP-IPv6",
                id = 0,
                ids = 1
            });
            typeA_dropDown.Add(new dropDownList
            {
                content = "TCP-IPv4",
                id = 1,
                ids = 2
            });
            typeA_dropDown.Add(new dropDownList
            {
                content = "UDP-IPv4",
                id = 2,
                ids = 3
            });
            typeA_dropDown.Add(new dropDownList
            {
                content = "UDP-IPv6",
                id = 3,
                ids = 4
            });
            typeB_dropDown.Add(new dropDownList
            {
                content = "TCP-IPv6",
                id = 0,
                ids = 1
            });
            typeB_dropDown.Add(new dropDownList
            {
                content = "TCP-IPv4",
                id = 1,
                ids = 2
            });
            typeB_dropDown.Add(new dropDownList
            {
                content = "UDP-IPv4",
                id = 2,
                ids = 3
            });
            typeB_dropDown.Add(new dropDownList
            {
                content = "UDP-IPv6",
                id = 3,
                ids = 4
            });
            typeA.ItemsSource = typeA_dropDown;
            typeA.DisplayMemberPath = "content";
            typeA.SelectedValuePath = "ids";
            typeA.SelectedIndex = 0;
            typeB.ItemsSource = typeB_dropDown;
            typeB.DisplayMemberPath = "content";
            typeB.SelectedValuePath = "ids";
            typeB.SelectedIndex = 1;
        }

        private void portA_TextChanged(object sender, TextChangedEventArgs e)
        {
            hasInputedA = true;
        }

        private void portB_TextChanged(object sender, TextChangedEventArgs e)
        {
            hasInputedB = true;
        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (port.Text == "Port")
                hasInputedA = false;
            else
                hasInputedA = true;
            if (ipAddr.Text == "IP Address")
                hasInputedB = false;
            else
                hasInputedB = true;
            if (!(hasInputedA && hasInputedB))
            {
                MessageBox.Show("Please enter Port and IP Address");
                return;
            }
            object a = typeA.SelectedValue;
            object b = typeB.SelectedValue;
            string typeContentA = "TCP6";
            string typeContentB = "TCP4";
            if (a.ToString() == "1")
                typeContentA = "TCP6";
            if (a.ToString() == "2")
                typeContentA = "TCP4";
            if (a.ToString() == "3")
                typeContentA = "UDP4";
            if (a.ToString() == "4")
                typeContentA = "UDP6";
            if (b.ToString() == "1")
                typeContentB = "TCP6";
            if (b.ToString() == "2")
                typeContentB = "TCP4";
            if (b.ToString() == "3")
                typeContentB = "UDP4";
            if (b.ToString() == "4")
                typeContentB = "UDP6";
            //socat TCP4-LISTEN:188,reuseaddr,fork TCP4:192.168.1.22:123
            //MessageBox.Show("socat " + typeContentA + "-LISTEN:" + port.Text + ",reuseaddr,fork " + typeContentB + ":" + ipAddr.Text);
            Process prc = Process.Start("socat\\socat.exe", typeContentA + "-LISTEN:" + port.Text + ",reuseaddr,fork " + typeContentB + ":" + ipAddr.Text);
        }
    }
}
