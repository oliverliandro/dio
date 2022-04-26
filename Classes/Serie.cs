using System.Text;
using Enums;

namespace Classes
{
    public class Serie : EntidadeBase
    {
        public Serie(int id, E_Genero genero, string titulo, string descricao, int ano, bool excuido)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excuido = excuido;
        }

        private E_Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excuido { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Gênero: {Genero}");
            sb.AppendLine($"Titulo: {Titulo}");
            sb.AppendLine($"Descrição: {Descricao}");
            sb.AppendLine($"Ano de Início: {Ano}");

            return sb.ToString();
        }
    }
}