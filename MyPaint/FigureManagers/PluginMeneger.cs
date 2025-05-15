using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InterfaceLib;

namespace MyPaint.FigureManagers
{
    internal class PluginMeneger
    {
        public static Type[] GetInternelPlugins()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IFigure))).ToArray();
        }
        public static Type[] GetExternelPlugins(string pth)
        {
            Type[] plugins = new Type[0];
            foreach (string dllFile in Directory.GetFiles(pth, "*.dll"))
                try
                {
                    Assembly loadedAssembly = Assembly.LoadFrom(dllFile);
                    Type[] types = loadedAssembly.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IFigure))).ToArray();
                    plugins = plugins.Concat(types).ToArray();
                }
                catch (Exception e)
                {
                }
            return plugins;
        }
    }
}
