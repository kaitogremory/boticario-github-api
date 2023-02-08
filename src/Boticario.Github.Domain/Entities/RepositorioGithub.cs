﻿using Boticario.Github.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boticario.Github.Domain.Entities
{
    public class RepositorioGithub : EntityBase
    {
        public RepositorioGithub(string nome, string linguagem, int qntEstrelas)
        {
            Linguagem = linguagem;            
            Nome = nome;
            QntEstrelas= qntEstrelas;
        }

        public string Nome { get; private set; }
        public string Linguagem { get; private set; }
        public int QntEstrelas { get; private set; }
    }
}
