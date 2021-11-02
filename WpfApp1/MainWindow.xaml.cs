using System.IO;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Forms;

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
            string errorMsg = string.Empty;

            if (!File.Exists(fbxDir) || string.IsNullOrEmpty(fbxDir))
                errorMsg += "Error: FBX file directory not found! \n";
            if (!Directory.Exists(shaderDir) || string.IsNullOrEmpty(shaderDir))
                errorMsg += "Error: Shader path directory not found! \n";
            if (!string.IsNullOrEmpty(errorMsg))
                System.Windows.MessageBox.Show(errorMsg);
            else
            {
                ShaderManager.CreateFiles(fbxDir, shaderDir);
                System.Windows.MessageBox.Show($"Shader files created successfully at {shaderDir}!");
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
    }
}
