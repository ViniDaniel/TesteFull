﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinhaApp.Dominio;
using MinhaApp.Repositorio;

namespace MinhaApp.Servico
{
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _repositorio;

        public AlunoServico(IAlunoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void Adicionar(AlunoDto alunoDto)
        {
            var aluno = new Aluno(alunoDto.Nome, alunoDto.Nota);
            _repositorio.Salvar(aluno);
        }


        public IEnumerable<AlunoDto> Listar()
        {
            return _repositorio.Listar().Select(aluno => new AlunoDto()
            {
                Nome = aluno.Nome,
                Nota = aluno.Nota
            }); 
        }
    }
}
