using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assimp;

namespace Blader
{
    public static class FBXParser
    {
        public static List<string> GetMaterialNames(string filePath)
        {
            var fileImporter = new AssimpContext();
            var scene = fileImporter.ImportFile(filePath);

            List<string> materialNames = new List<string>();
            var materials = scene.Materials;

            foreach (var mat in materials) 
            {
                var matName = mat.Name;
                if(!matName.StartsWith("+"))
                    materialNames.Add(matName);
            }

            return materialNames;
        }
    }
}
