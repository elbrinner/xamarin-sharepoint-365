using System;
using System.Collections.Generic;
using System.Text;

namespace SharepointXamarin.Constants
{
    public class ConfigConstant
    {
        /// <summary>
        /// ID del la aplicacion - https://apps.dev.microsoft.com/#/appList
        /// </summary>
        public const string IdAplication = "57e56e26-dbe6-41f2-b9e1-fd843874a6b6";

        /// <summary>
        /// Permisos que necesita la aplicación.
        /// Algunos permisos deben ser aprobados por el administrador
        /// </summary>
        public static string[] Scopes = { "User.Read" , "Mail.Read"  };



    }
}
