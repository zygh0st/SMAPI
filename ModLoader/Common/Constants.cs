using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ModLoader.Common
{
    class Constants
    {
        public static string GamePath { get; } = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path, "SMDroid/");
        public static string AssemblyPath { get; } = Path.Combine(GamePath, "Game/assemblies/");
        public static string ModPath { get; } = Path.Combine(GamePath, "Mods");
        public static string ContentPath { get; } = Path.Combine(Constants.GamePath, "Game/assets/Content");
    }
}
