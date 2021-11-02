using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blader
{
    public static class ShaderManager
    {
        public static void CreateFiles(string fbxDirectory, string shaderDirectory)
        {
            var currentDir = Directory.GetCurrentDirectory();
            var materialNames = FBXParser.GetMaterialNames(fbxDirectory);

            foreach (var name in materialNames)
            {
                File.Copy($"{currentDir}\\default", $"{shaderDirectory}/{name}.shader");
            }
            return;
        }
    }
}
