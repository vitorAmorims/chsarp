using System;
using System.Collections.Generic;

namespace jogoRPG.src.Interfaces
{
    public interface IRepositorio<T>
    {
        void Listar();
        T RetornarPorId(int index);
        void Inserir(T entidade);
        void Excluir(int index);
        void Atualizar(int index, T entidade);
        int ProximoId();
    }
}
