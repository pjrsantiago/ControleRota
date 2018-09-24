using ControleDeRota.Modelos;
using ControleDeRota.DAO;
using System.Collections.Generic;

namespace ControleDeRota.Negocios
{
    public class RotasNeg
    {
        public bool salvar(RotasMod _Rota)
        {
            RotasDao _RotasDao = new RotasDao();
            if(_Rota.iCodigoRota != 0)
            {
                return _RotasDao.update(_Rota);
            }
            else
            {
                return _RotasDao.insert(_Rota);
            }
        }

        public bool excluir(int iCodigoRota)
        {
            RotasDao _RotaDao = new RotasDao();
            RotasMod _RotaMod = new RotasMod();
            _RotaMod.iCodigoRota = iCodigoRota;
            return _RotaDao.delete(_RotaMod);
        }

        public List<RotasMod> listaRotas()
        {
            RotasDao _RotaDao = new RotasDao();
            return _RotaDao.listaRotas();
        }

        public List<RotasMod> listaRotas(RotasMod _RotaMod)
        {
            RotasDao _RotaDao = new RotasDao();
            return _RotaDao.listaRotas(_RotaMod);
        }
    }
}