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

            Task<ForapiResponseObject> apiAccesTask;
            ForapiResponseObject response;
            apiAccesTask = ApiAccess.GetApiResponseAsync(baseUri, requestUri);
            response = await apiAccesTask;
            //If successfull, save previous URI to a text file
            if(response.Success)
                GUIHelper.WriteToFile(PREVCALL_PATH, baseUri + "," + requestUri);
            else
            {
                MessageBox.Show(response.HttpResponse, "An error occurred while calling api");
            }

            result.Text = response.Response;
            httpResponse.Text = response.HttpResponse;
        }



    }
}
