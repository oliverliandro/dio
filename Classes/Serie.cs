using System.Text;
using Enums;

namespace Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, E_Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        private E_Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Gênero: {Genero}");
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Descrição: {Descricao}");
            sb.AppendLine($"Ano de Início: {Ano}");
            sb.AppendLine($"Excluido: {Excluido}");

            return sb.ToString();
        }

        public string RetornaTitulo()
        {
            return Titulo;
        }

        public int RetornaId()
        {
            return Id;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}