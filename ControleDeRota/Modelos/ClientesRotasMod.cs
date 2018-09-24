
namespace ControleDeRota.Modelos
{
    public class ClientesRotasMod
    {
        public ClientesRotasMod()
        {
            iCodigoClientesRotas = 0;
            iCodRota = 0;
            sRota = string.Empty;
            iCodVendedor = 0;
            sVendedor = string.Empty;
            iCodCliente = 0;
            sCliente = string.Empty;
            sEndereco = string.Empty;
            sNumero = string.Empty;
            sCidade = string.Empty;
            sUF = string.Empty;
            sCEP = string.Empty;
            iSequencialRota = 0;
        }

        public int iCodigoClientesRotas { get; set; }
        public int iCodRota { get; set; }
        public string sRota { get; set; }
        public int iCodVendedor { get; set; }
        public string sVendedor { get; set; }
        public int iCodCliente { get; set; }
        public string sCliente { get; set; }
        public string sEndereco { get; set; }
        public string sNumero { get; set; }
        public string sCidade { get; set; }
        public string sUF { get; set; }
        public string sCEP { get; set; }
        public int iSequencialRota { get; set; }

    }
}