using ControleDeRota.Modelos;
using ControleDeRota.DAO;
using System.Collections.Generic;

namespace ControleDeRota.Negocios
{
    public class ClientesRotasNeg
    {
        public bool salvar(ClientesRotasMod _ClienteRota)
        {
            ClientesRotasDao _ClientesRotasDao = new ClientesRotasDao();
            if (_ClienteRota.iCodigoClientesRotas != 0)
            {
                return _ClientesRotasDao.update(_ClienteRota);
            }
            else
            {
                return _ClientesRotasDao.insert(_ClienteRota);
            }
        }

        public bool update(ClientesRotasMod _ClienteRota)
        {
            ClientesRotasDao _ClientesRotasDao = new ClientesRotasDao();
            return _ClientesRotasDao.update(_ClienteRota);
        }

        public bool excluir(int iCodigoClienteRota)
        {
            ClientesRotasDao _ClienteRotaDao = new ClientesRotasDao();
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();
            _ClienteRotaMod.iCodigoClientesRotas = iCodigoClienteRota;
            return _ClienteRotaDao.delete(_ClienteRotaMod);


        }

        public List<ClientesRotasMod> listaClientesRotas()
        {
            ClientesRotasDao _ClienteRotaDao = new ClientesRotasDao();
            return _ClienteRotaDao.listaClientesRotas();
        }

        public List<ClientesRotasMod> listaClientesRotas(ClientesRotasMod _ClienteRotaMod)
        {
            ClientesRotasDao _ClienteRotaDao = new ClientesRotasDao();
            return _ClienteRotaDao.listaClientesRotas(_ClienteRotaMod);
        }

        public void up(int iCodigo, int iCodigoAnterior, int iSequencia, int iSequenciaAnterior)
        {
            ClientesRotasDao _ClienteRotaDao = new ClientesRotasDao();
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();

            _ClienteRotaMod.iCodigoClientesRotas = iCodigo;
            _ClienteRotaMod.iSequencialRota = iSequenciaAnterior;
            _ClienteRotaDao.update(_ClienteRotaMod);

            _ClienteRotaMod.iCodigoClientesRotas = iCodigoAnterior;
            _ClienteRotaMod.iSequencialRota = iSequencia;
            _ClienteRotaDao.update(_ClienteRotaMod);
        }

        public void down(int iCodigo, int iCodigoPosterior, int iSequencia, int iSequenciaPosterior)
        {
            ClientesRotasDao _ClienteRotaDao = new ClientesRotasDao();
            ClientesRotasMod _ClienteRotaMod = new ClientesRotasMod();

            _ClienteRotaMod.iCodigoClientesRotas = iCodigo;
            _ClienteRotaMod.iSequencialRota = iSequenciaPosterior;
            _ClienteRotaDao.update(_ClienteRotaMod);

            _ClienteRotaMod.iCodigoClientesRotas = iCodigoPosterior;
            _ClienteRotaMod.iSequencialRota = iSequencia;
            _ClienteRotaDao.update(_ClienteRotaMod);
        }
    }
}