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

using ApiAccesser;

namespace ApiAccesserGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string PREVCALL_PATH = @".\lastCall.txt";

        public MainWindow()
        {
            InitializeComponent();
            //See if a previous apicall is saved. If there is, load it.
            string previousCall = GUIHelper.ReadFromFile(PREVCALL_PATH);
            if (previousCall != "")
            {
                string[] uris = previousCall.Split(',');
                baseUriInput.Text = uris[0];
                requestUriInput.Text = uris[1];
            }
        }

        async void GoClickedAsync(object sender, RoutedEventArgs e)
        {
            string baseUri = baseUriInput.Text;
            string requestUri = requestUriInput.Text;

            Task<string[]> apiAccesTask;
            string[] response = new string[2];
            try
            {
                apiAccesTask = ApiAccess.ApiCallAsync(baseUri, requestUri);
                response = await apiAccesTask;
                //If successfull, save previous URI to a text file
                GUIHelper.WriteToFile(PREVCALL_PATH, baseUri + "," + requestUri);
            }
            catch(Exception err){
                response[0] = err.ToString();
                response[1] = "";
            }

            MessageBox.Show(response[0]);
            result.Text = response[1];
        }



    }
}
