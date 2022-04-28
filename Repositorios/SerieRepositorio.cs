using Classes;
using Interfaces;

namespace Repositorios
{
    public class SerieRepositorio : IRepositorioBase<Serie>
    {
        List<Serie> series = new List<Serie>();
        public void Atualizar(int id, Serie entidade)
        {
            series[id] = entidade;
        }

        public void Excluir(int id)
        {
            series[id].Excluir();
        }

        public void Inserir(Serie entidade)
        {
            series.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return series;
        }

        public int ProximoId()
        {
            return series.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return series[id];
        }
    }
}