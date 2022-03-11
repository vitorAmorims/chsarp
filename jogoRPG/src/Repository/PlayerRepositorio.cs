using System;
using jogoRPG.src.Interfaces;
using System.Collections.Generic;
using jogoRPG.src.Models;
using System.Linq;

namespace jogoRPG.src.Repository
{
    public class PlayerRepositorio : IRepositorio<EntidadeBase>
    {
        private List<EntidadeBase> listaGuerreiros = new List<EntidadeBase>();

        public void Atualizar(int index, EntidadeBase entidade)
        {
            listaGuerreiros[index] = entidade;
        }

        public void Excluir(int index)
        {
            listaGuerreiros.RemoveAt(index);
        }

        public void Inserir(EntidadeBase entidade)
        {
            listaGuerreiros.Add(entidade);
        }

        public void Listar()
        {
            // /listaGuerreiros.ForEach(g => Console.WriteLine(g.Info()));
            foreach (var g in listaGuerreiros)
            {
                Console.WriteLine(g.GetName());
            }
        }

        public int ProximoId()
        {
            return listaGuerreiros.Count();
        }

        public EntidadeBase RetornarPorId(int index)
        {
            return listaGuerreiros[index];
        }

    }
}
