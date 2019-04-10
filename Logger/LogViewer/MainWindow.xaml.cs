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

namespace LogViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private LogViewerController logViewerController;
        public MainWindow(LogViewerController logViewerController)
        {

           
            InitializeComponent();
            this.logViewerController = logViewerController;

        }

        private void Button_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Open_Click(object sender, RoutedEventArgs e)
        {
            logViewerController.openFile();

        }
    }
}
