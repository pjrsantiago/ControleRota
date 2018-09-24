using ControleDeRota.Modelos;
using ControleDeRota.DAO;
using System.Collections.Generic;

namespace ControleDeRota.Negocios
{
    public class ClientesNeg
    {
        public bool salvar(ClientesMod _Cliente)
        {
            ClientesDao _ClientesDao = new ClientesDao();
            if(_Cliente.iCodigoCliente != 0)
            {
                return _ClientesDao.update(_Cliente);
            }
            else
            {
                return _ClientesDao.insert(_Cliente);
            }
        }

        public bool excluir(int iCodigoCliente)
        {
            ClientesDao _ClienteDao = new ClientesDao();
            ClientesMod _ClienteMod = new ClientesMod();
            _ClienteMod.iCodigoCliente = iCodigoCliente;
            return _ClienteDao.delete(_ClienteMod);
        }

        public List<ClientesMod> listaClientes()
        {
            ClientesDao _ClienteDao = new ClientesDao();
            return _ClienteDao.listaClientes();
        }

        public List<ClientesMod> listaClientes(ClientesMod _ClienteMod)
        {
            ClientesDao _ClienteDao = new ClientesDao();
            return _ClienteDao.listaClientes(_ClienteMod);
        }
    }
}