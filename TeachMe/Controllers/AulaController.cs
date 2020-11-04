﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using TeachMe.API.Models.DTO;
using TeachMe.API.Models.ViewModel;
using TeachMe.Core.Dominio;
using TeachMe.Service.Services.Interfaces;

namespace TeachMe.API.Controllers
{
    [Route("api/v1/aula")]
    [ApiController]
    public class AulaController : ControllerBase
    {
        private readonly IAulaServico _servico;
        private readonly IMapper _mapper;
        private readonly ILogger<AulaController> _logger;

        public AulaController(IAulaServico servico, IMapper mapper, ILogger<AulaController> logger)
        {
            _servico = servico;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        [Route("contratarAula")]
        [Authorize]
        public ActionResult<ContratoAulaViewModel> ContratarAula(ContratoAulaDTO contrato)
        {
            _logger.LogDebug("ContratarAula");
            var resultado = _servico.ContratarAula(_mapper.Map<ContratoAula>(contrato));

            return resultado != null 
                ? (ActionResult)Ok(_mapper.Map<ContratoAulaViewModel>(resultado))
                : NoContent();
        }

        [HttpGet]
        [Route("pendenciaAvaliacao")]
        [Authorize]
        public ActionResult<List<ContratoAulaViewModel>> ObterAulaParaAvaliar(long alunoId)
        {
            _logger.LogDebug("ObterAulaParaAvaliar");
            var resultado = _servico.ObterAulaParaAvaliar(alunoId);

            return resultado.Count > 0
                ? (ActionResult)Ok(resultado.Select(r => _mapper.Map<ContratoAulaViewModel>(r)).ToList())
                : NoContent();
        }

        [HttpPost]
        [Route("avaliarProfessor")]
        [Authorize]
        public ActionResult<AvaliacaoProfessorViewModel> AvaliarProfessor(AvaliacaoProfessorDTO avaliacao)
        {
            _logger.LogDebug("AvaliarProfessor");
            var resultado = _servico.AvaliarProfessor(_mapper.Map<AvaliacaoProfessor>(avaliacao), avaliacao.AlunoId);

            return resultado != null
                ? (ActionResult)Ok(_mapper.Map<AvaliacaoProfessorViewModel>(resultado))
                : NoContent();
        }
    }
}
