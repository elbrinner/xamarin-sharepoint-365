using System;
namespace SharepointXamarin.Constants
{
    public class WebServiceConstant
    {

        /// <summary>
        /// Mi perfil
        /// </summary>
        public const string Me = "https://graph.microsoft.com/v1.0/me/";

        /// <summary>
        /// Mi foto
        /// </summary>
        public const string Photo = "https://graph.microsoft.com/v1.0/me/photo/$value";

        /// <summary>
        /// Personas que trabajan comigo
        /// </summary>
        public const string People = "https://graph.microsoft.com/v1.0/me/people";

        /// <summary>
        /// Bandeja del correo
        /// </summary>
        public const string MailInbox = "https://graph.microsoft.com/v1.0/me/mailFolders/Inbox/messages/delta";





    }
}
