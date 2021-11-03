using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;


namespace Blader
{
    public enum Game
    {
        HaloCE,
        Halo2,
        Halo3
    }
    public static class ShaderManager
    {
        public static void CreateFiles(string fbxDirectory, string shaderDirectory, Game game)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var materialNames = FBXParser.GetMaterialNames(fbxDirectory);
            var defaultName = "";

            switch (game)
            {
                case Game.HaloCE:
                    defaultName = "default_1";
                    break;
                case Game.Halo2:
                    defaultName = "default_2";
                    break;
                case Game.Halo3:
                    defaultName = "default_3";
                    break;
            }
            var defaultFilePath = $"{currentDir}\\{defaultName}";

            if (!ValidateFileWithMessage(defaultFilePath)) return;

            foreach (var name in materialNames)
            {
                File.Copy(defaultFilePath, $"{shaderDirectory}/{name}.shader");
            }
            return;
        }

        private static bool ValidateFileWithMessage(string fileName)
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show($"Error, epxected to find file {fileName} but it could not be found.", 
                                "Blader Error!", 
                                MessageBoxButton.OK, 
                                MessageBoxImage.Error);
                return false;
            }
            else return true;
        }
    }
}
