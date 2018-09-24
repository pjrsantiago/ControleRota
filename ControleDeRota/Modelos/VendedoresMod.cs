
namespace ControleDeRota.Modelos
{
    public class VendedoresMod
    {
        public VendedoresMod()
        {
            iCodigoVendedor = 0;
            sNome = string.Empty;
            sCpf = string.Empty;
            sEndereco = string.Empty;
            sNumero = string.Empty;
            sCidade = string.Empty;
            sUF = string.Empty;
            sCEP = string.Empty;
        }

        public int iCodigoVendedor { get; set; }
        public string sNome { get; set; }
        public string sCpf { get; set; }
        public string sEndereco { get; set; }
        public string sNumero { get; set; }
        public string sCidade { get; set; }
        public string sUF { get; set; }
        public string sCEP { get; set; }

    }
}