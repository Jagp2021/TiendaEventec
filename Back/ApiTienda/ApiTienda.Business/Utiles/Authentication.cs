namespace ApiTienda.Business.Utiles
{
    #region Librerias
    using ApiTienda.Business.DTO.Payment;
    using System.Text;
    #endregion
    public class Authentication
    {
        #region Variables y Propiedades
        public AuthDTO Auth { get; set; }
        private string secrectKey { get; set; }
        #endregion

        #region Constructor
        public Authentication()
        {
            this.Auth = new AuthDTO();
            this.Auth.login = Settings.Default.Login;
            this.secrectKey = Settings.Default.TranKey;
            GenerateAuth();
        }
        #endregion

        #region Métdos y Funciones
        /// <summary>
        /// Método que genera los datos para el objeto Auth
        /// </summary>
        private void GenerateAuth()
        {
            var nonce = Utiles.generateNonce();
            this.Auth.seed = Utiles.generateSeed();
            this.Auth.nonce = Utiles.encodeBase64(Encoding.ASCII.GetBytes(nonce));
            this.Auth.tranKey = Trankey(nonce);
        }

        /// <summary>
        /// Función que genera el tranKey
        /// </summary>
        /// <param name="nonce"></param>
        /// <returns></returns>
        private string Trankey(string nonce)
        {
            string trankey = "";


            trankey = nonce + this.Auth.seed + this.secrectKey;


            return Utiles.encodeBase64(Utiles.generateSha1(trankey));
        }
        #endregion
    }
}
