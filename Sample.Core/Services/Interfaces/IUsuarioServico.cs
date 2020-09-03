﻿using System.Collections.Generic;
using TeachMe.Core.Entities;

namespace TeachMe.Core.Services.Interfaces
{
    public interface IUsuarioServico
    {
        List<Usuario> ObterTodos();
        Usuario ObterPorId(long Id);
        int Cadastrar(Usuario usuario);
        Usuario Alterar(Usuario usuario);
        int Excluir(long Id);
    }
}
