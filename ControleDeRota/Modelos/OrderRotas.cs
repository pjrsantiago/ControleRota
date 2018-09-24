using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ControleDeRota.Modelos
{
    public class OrderRotas : IComparer<RotasMod>
    {
        public enum SortType
        {
            iCodigoRota,
            sDescricao,
        }

        private SortType _sortType;

        private string direcao = string.Empty;

        public OrderRotas(SortType sortType, string sortDirection)
        {
            this._sortType = sortType;
            direcao = sortDirection;
        }

        public int Compare(RotasMod x, RotasMod y)
        {
            if(direcao == "Ascending")
            {
                switch (this._sortType)
                {
                    case SortType.iCodigoRota:
                        return x.iCodigoRota.CompareTo(y.iCodigoRota);

                    case SortType.sDescricao:
                        return x.sDescricao.CompareTo(y.sDescricao);
                }
            }

            if(direcao == "Descending")
            {
                switch (this._sortType)
                {
                    case SortType.iCodigoRota:
                        return y.iCodigoRota.CompareTo(x.iCodigoRota);

                    case SortType.sDescricao:
                        return y.sDescricao.CompareTo(x.sDescricao);
                }
            }

            return 0;
        }
    }
}