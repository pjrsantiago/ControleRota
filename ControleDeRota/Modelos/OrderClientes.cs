using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ControleDeRota.Modelos
{
    public class OrderClientes : IComparer<ClientesMod>
    {
        public enum SortType
        {
            iCodigoCliente,
            sDescricao,
        }

        private SortType _sortType;

        private string direcao = string.Empty;

        public OrderClientes(SortType sortType, string sortDirection)
        {
            this._sortType = sortType;
            direcao = sortDirection;
        }

        public int Compare(ClientesMod x, ClientesMod y)
        {
            if(direcao == "Ascending")
            {
                switch (this._sortType)
                {
                    case SortType.iCodigoCliente:
                        return x.iCodigoCliente.CompareTo(y.iCodigoCliente);

                    case SortType.sDescricao:
                        return x.sDescricao.CompareTo(y.sDescricao);
                }
            }

            if(direcao == "Descending")
            {
                switch (this._sortType)
                {
                    case SortType.iCodigoCliente:
                        return y.iCodigoCliente.CompareTo(x.iCodigoCliente);

                    case SortType.sDescricao:
                        return y.sDescricao.CompareTo(x.sDescricao);
                }
            }

            return 0;
        }
    }
}