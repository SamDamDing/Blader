# Blader
### By ark_ryl
Generate (as of now, mostly empty) Halo .shader files from FBX files.

Tired of having to manually create dozens and dozens of shader files for your new map? 
Well tire no more! This tool analyzes exported FBX files and will produce all the .shader tags 
necessary for your .ass file to be imported using Tool/Osoyoos.

Currently supported: Halo 2 and Halo 3.

## Requirements
+ Windows Vista/7/8/8.1/10/11
+ Latest .NET runtime

## How to Use
+ Export desired FBX file from your 3d software of choice
+ Select in Blader
+ Select a destination for the new .shader files
+ Navigate to the destiantion to find your freshly baked .shaders!

# Inlcuded Python Scripts
### By SamDamDing
These scripts do the following

### BlenderRenameTexturesToCharLimit - Run 1st.py
Renames the textures in a model in Blender to be 40 characters long

### BlenderRenameMaterialToTexture - Run 2nd.py
Renames the materials the model uses to the name of the texture in the first slot.

### H3ShaderBitmapTool Modify and Run 3rd.py
Modify this file to use the directory of your shaders. It will hex edit the shader to use the name of the shader file itself as the bitmap. The bitmaps must be placed in the H3EK\tags\objects\bitmaps\custom directory. This directory can be modified if you really wanted to by editing the default_3 template.
