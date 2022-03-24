namespace ApiTienda.Business.Utiles
{
    #region Librerias
    using System;
    using System.Security.Cryptography;
    using System.Text;
    #endregion
    public class Utiles
    {
        #region Métodos y Funciones

        /// <summary>
        /// Función que encripta un texto usando el algoritmo SHA1
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static byte[] generateSha1(string text)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return sha1.ComputeHash(Encoding.ASCII.GetBytes(text));
            }
        }

        /// <summary>
        /// Función que codifica un texto en formato Base64
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string encodeBase64(byte[] text)
        {
            return Convert.ToBase64String(text);
        }

        /// <summary>
        /// Función que genera el Nonce para autenticación del servicio de Pagos
        /// </summary>
        /// <returns></returns>
        public static string generateNonce()
        {
            return new Guid().ToString();
            //return "12345";
        }

        /// <summary>
        /// Función que genera el Seed para autenticación del servicio de Pagos
        /// </summary>
        /// <returns></returns>
        public static string generateSeed()
        {
            var fecha = DateTime.Now;
            return (fecha.AddMinutes(5)).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
        }

        public static string generateExpirationDate()
        {
            var fecha = DateTime.Now;
            return (fecha.AddDays(1)).ToString("yyyy-MM-ddTHH\\:mm\\:sszzz");
        }
        #endregion
    }
}
