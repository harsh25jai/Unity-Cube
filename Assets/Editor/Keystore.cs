using UnityEngine;
using UnityEditor;
using System.IO;

[InitializeOnLoad]
public class PreloadSigningAlias
{

    static PreloadSigningAlias()
    {
        PlayerSettings.Android.keystorePass = "android";
        PlayerSettings.Android.keyaliasName = "cube_release";
        PlayerSettings.Android.keyaliasPass = "android";
    }

}