using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploWebAPIJWT.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Pendente { get; set; }

        public TodoItem()
        {

        }

        public TodoItem(int id, string descricao, bool pendente)
        {
            Id = id;
            Descricao = descricao;
            Pendente = pendente;
        }
    }




}
