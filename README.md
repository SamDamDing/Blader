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
These scripts do the following:

### Tex2Limit2Mat2Shader.py
+ This script takes your objects in a scene, gets their materials textures, renames them to be 40 characters long as specified in the neededlength variable, then exports them to a folder specified by n.image.filepath_raw

+ If that folder does not exist, change it to somewhere that does.

+ Those Tifs are generated there and then the material for the object is renamed to the name of that texture that was just renamed. Why? It's hacky bitswapping.

+ If you were to generate bitmaps from these Tifs outright, Tool wouldn't like that, so I use my Gimp to convert them into a proper TIFF using the Batch Image Manipulation addon https://alessandrofrancesconi.it/projects/bimp/

+ The output for proper tifs should be in your data/objects/bitmaps/custom directory. Don't have it? Make one.

+ You can now have tool make bitmaps from those tiffs that will end up in your tags/objects/bitmaps/custom directory.

+ Export your blender file as an fbx

+ Use my fork of blader to generate shaders to your directory. Why my fork? It has a custom default_3 file blader uses to generate template shaders. This is my template.

+ Modify the default_directory variable in the "H3ShaderBitmapTool Modify and Run 3rd.py" script to the directory you have your blader generated shaders in and run it.

+ It'll probably mess up a few of them because this script is ~~hacky ass shit~~ unrefined tbh. Like, it doesn't check for it duplicates. I'll probably get around to fixing it, but if that happens you'll have shaders with an invalid texture that looks red and rainbowy. It's kinda cool. 

+ Finally, you can import your ass with Tool and hopefully your textures will look right.

### H3ShaderBitmapToolModifyAndRunLast.py
+ Modify this file to use the directory of your shaders. It will hex edit the shader to use the name of the shader file itself as the bitmap. The bitmaps must be placed in the H3EK\tags\objects\bitmaps\custom directory.
