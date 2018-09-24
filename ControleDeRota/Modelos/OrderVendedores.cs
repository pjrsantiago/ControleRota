using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ControleDeRota.Modelos
{
    public class OrderVendedores : IComparer<VendedoresMod>
    {
        public enum SortType
        {
            iCodigoVendedor,
            sNome,
        }

        private SortType _sortType;

        private string direcao = string.Empty;

        public OrderVendedores(SortType sortType, string sortDirection)
        {
            this._sortType = sortType;
            direcao = sortDirection;
        }

        public int Compare(VendedoresMod x, VendedoresMod y)
        {
            if(direcao == "Ascending")
            {
                switch (this._sortType)
                {
                    case SortType.iCodigoVendedor:
                        return x.iCodigoVendedor.CompareTo(y.iCodigoVendedor);

                    case SortType.sNome:
                        return x.sNome.CompareTo(y.sNome);
                }
            }

            if(direcao == "Descending")
            {
                switch (this._sortType)
                {
                    case SortType.iCodigoVendedor:
                        return y.iCodigoVendedor.CompareTo(x.iCodigoVendedor);

                    case SortType.sNome:
                        return y.sNome.CompareTo(x.sNome);
                }
            }

            return 0;
        }
    }
}