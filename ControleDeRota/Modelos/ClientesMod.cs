
namespace ControleDeRota.Modelos
{
    public class ClientesMod
    {
        public ClientesMod()
        {
            iCodigoCliente = 0;
            sDescricao = string.Empty;
            sCpfCnpj = string.Empty;
            sEndereco = string.Empty;
            sNumero = string.Empty;
            sCidade = string.Empty;
            sUF = string.Empty;
            sCEP = string.Empty;
        }

        public int iCodigoCliente { get; set; }
        public string sDescricao { get; set; }
        public string sCpfCnpj { get; set; }
        public string sEndereco { get; set; }
        public string sNumero { get; set; }
        public string sCidade { get; set; }
        public string sUF { get; set; }
        public string sCEP { get; set; }

    }
}