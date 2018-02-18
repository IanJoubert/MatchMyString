using System;
using System.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Autofac;
using Mms.Business.Services;
using Mms.Business.Services.Module;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mms.Presentation.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static IContainer Container { get; set; }
        private StorageFile _file;
        public MainPage()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            Container = builder.Build();
            this.InitializeComponent();
        }

        private async void BtnBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            var openPicker = new FileOpenPicker
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.ComputerFolder
            };
            openPicker.FileTypeFilter.Add(".txt");

            _file = await openPicker.PickSingleFileAsync();
            if (_file == null)
            {
                TbxFileName.PlaceholderText = "";
                TbxOutputMessage.Text = "Operation cancelled.";
            }
            else
            {
                TbxOutputMessage.Text = "";
                TbxFileName.PlaceholderText = _file.Name;
            }
        }

        private async void BtnSubmit_OnClick(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(TbxSearch.Text))
            {
                TbxOutputMessage.Text = "Please provide a search string";
            }
            else if (_file == null)
            {
                TbxOutputMessage.Text = "Please provide a file";
            }
            else
            {
                var searchString = TbxSearch.Text;
                var file = await FileIO.ReadTextAsync(_file);
                using (var scope = Container.BeginLifetimeScope())
                {
                    var validationService = scope.Resolve<IFileValidationService>();
                    var matcherService = scope.Resolve<IMatcherService>();

                    try
                    {
                        validationService.Verify(file);
                        var results = matcherService.GetMatches(searchString, file);

                        TbxOutputMessage.Text = results.Any() ? $"Results found: {results}" : "No results found";
                    }
                    catch (Exception exception)
                    {
                        TbxOutputMessage.Text = $"The file does not meet the validation rules. {exception.Message}";
                    }
                }
            }
        }
    }
}
