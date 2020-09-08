using System;
using System.Reflection;
using System.Text;

namespace UFO.Utilities
{
    class AssemlyInfoHelper
    {
        static Assembly asm;
        static string assemblyName = "";
        static string assemblyFullName = "";
        static string assemblyVersion = "";
        static string assemblyCopyright = "";
        static string assemblyTitle = "";

        public static string AssemblyName
        {
            get { return assemblyName; }
        }

        public static string AssemblyFullName
        {
            get { return assemblyFullName; }
        }

        public static string AssemblyVersion
        {
            get { return assemblyVersion; }
        }

        public static string AssemblyCopyright
        {
            get { return assemblyCopyright; }
        }

        public static string AssemblyTitle
        {
            get { return assemblyTitle; }
        }

        public static System.Drawing.Icon AssemblyIcon
        {
            get
            {
                return System.Drawing.Icon.ExtractAssociatedIcon(asm.Location);
            }
        }

        static AssemlyInfoHelper()
        {
            asm = Assembly.GetExecutingAssembly();
            assemblyName = asm.GetName().Name.ToString();
            assemblyFullName = asm.GetName().FullName.ToString();
            assemblyVersion = asm.GetName().Version.ToString();

            object[] obj = asm.GetCustomAttributes(false);
            foreach (object o in obj)
            {
                if (o.GetType() == typeof(System.Reflection.AssemblyCopyrightAttribute))
                {
                    AssemblyCopyrightAttribute aca = (AssemblyCopyrightAttribute)o;
                    assemblyCopyright = aca.Copyright;
                }
                if (o.GetType() == typeof(System.Reflection.AssemblyTitleAttribute))
                {
                    AssemblyTitleAttribute ata = (AssemblyTitleAttribute)o;
                    assemblyTitle = ata.Title;
                }
            }
        }   
    }
}
