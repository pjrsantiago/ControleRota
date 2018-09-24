using ControleDeRota.Modelos;
using ControleDeRota.DAO;
using System.Collections.Generic;

namespace ControleDeRota.Negocios
{
    public class VendedoresNeg
    {
        public bool salvar(VendedoresMod _Vendedor)
        {
            VendedoresDao _VendedoresDao = new VendedoresDao();
            if(_Vendedor.iCodigoVendedor != 0)
            {
                return _VendedoresDao.update(_Vendedor);
            }
            else
            {
                return _VendedoresDao.insert(_Vendedor);
            }
        }

        public bool excluir(int iCodigoVendedor)
        {
            VendedoresDao _VendedorDao = new VendedoresDao();
            VendedoresMod _VendedorMod = new VendedoresMod();
            _VendedorMod.iCodigoVendedor = iCodigoVendedor;
            return _VendedorDao.delete(_VendedorMod);
        }

        public List<VendedoresMod> listaVendedores()
        {
            VendedoresDao _VendedorDao = new VendedoresDao();
            return _VendedorDao.listaVendedores();
        }

        public List<VendedoresMod> listaVendedores(VendedoresMod _VendedorMod)
        {
            VendedoresDao _VendedorDao = new VendedoresDao();
            return _VendedorDao.listaVendedores(_VendedorMod);
        }
    }
}