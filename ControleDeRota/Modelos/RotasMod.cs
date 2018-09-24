
namespace ControleDeRota.Modelos
{
    public class RotasMod
    {
        public RotasMod()
        {
            iCodigoRota = 0;
            sDescricao = string.Empty;
            iCodVendedor = 0;
            sVendedor = string.Empty;
        }

        public int iCodigoRota { get; set; }
        public string sDescricao { get; set; }
        public int iCodVendedor { get; set; }
        public string sVendedor { get; set; }

    }
}