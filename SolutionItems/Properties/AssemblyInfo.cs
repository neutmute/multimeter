using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

#if DEBUG
    [assembly: AssemblyProduct("Multimeter (Debug)")]
    [assembly: AssemblyConfiguration("Debug")]
#else
    [assembly: AssemblyProduct("Multimeter (Release)")]
    [assembly: AssemblyConfiguration("Release")]
#endif

[assembly: ComVisible(false)]
[assembly: AssemblyVersion("4.5.0.35")]
[assembly: AssemblyInformationalVersion("Developer Build")]
[assembly: InternalsVisibleToAttribute("Tests.Multimeter")]