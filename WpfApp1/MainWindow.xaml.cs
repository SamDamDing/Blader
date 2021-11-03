using System.IO;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Diagnostics;

namespace Blader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FbxFilePathButton_Click(object sender, RoutedEventArgs e)
        {
            var fbxPath = GetFilePath(folderPicker: false);
            FBXFilePathBox.Text = fbxPath;
        }

        private void MapShaderDirectoryButton_Click(object sender, RoutedEventArgs e)
        {
            var shadersPath = GetFilePath(folderPicker: true);
            MapsShadersFilePathBox.Text = shadersPath;
        }

        private void GenerateShadersButton_Click(object sender, RoutedEventArgs e)
        {
            var fbxDir = FBXFilePathBox.Text;
            var shaderDir = MapsShadersFilePathBox.Text;
            var errorMsg = string.Empty;
            var gameSelection = (Game)GameSelectComboBox.SelectedIndex;

            if (!File.Exists(fbxDir) || string.IsNullOrEmpty(fbxDir))
                errorMsg += "FBX file directory not found! \n";
            if (!Directory.Exists(shaderDir) || string.IsNullOrEmpty(shaderDir))
                errorMsg += "Shader path directory not found! \n";
            if (!string.IsNullOrEmpty(errorMsg))
                System.Windows.MessageBox.Show(errorMsg, 
                                               "Blader Error!",
                                               MessageBoxButton.OK,
                                               MessageBoxImage.Error);
            else
            {
                ShaderManager.CreateFiles(fbxDir, shaderDir, gameSelection);
                System.Windows.MessageBox.Show($"Shader files created successfully at {shaderDir}",
                                                "Blader",
                                                MessageBoxButton.OK,
                                                MessageBoxImage.Information);
            }
        }

        private string GetFilePath(bool folderPicker = false)
        {
            var dir = string.Empty;
            var browserDialog = new CommonOpenFileDialog();
            var fbxFilter = new CommonFileDialogFilter("FBX File", ".fbx");
            browserDialog.IsFolderPicker = folderPicker;

            if (!folderPicker)
                browserDialog.Filters.Add(fbxFilter);
            else browserDialog.Filters.Clear();

            if (browserDialog.ShowDialog() == CommonFileDialogResult.Ok)
                dir = browserDialog.FileName;

            return dir;
        }

        private void Icon_Click(object sender, RoutedEventArgs e)
        {
            var uri = @"https://github.com/arkryl/Blader";

            var startInfo = new ProcessStartInfo
            {
                FileName = uri,
                UseShellExecute = true
            };

            Process.Start(startInfo);
        }
    }
}
