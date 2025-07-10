using Microsoft.AspNetCore.Mvc;
using System;
using TdocSpider.Application.Models.ViewModels;

namespace TdocSpider.Application.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            SobreViewModel dtSistema = new SobreViewModel
            {
                NomeSistema = "DocSpider",
                Versao = "1.0.0",
                DataAtualizacao = DateTime.Now.ToString(),
                Desenvolvedor = "Valber",
                MensagemRodape = "Este sistema é uma demonstração com dados fictícios.",
                LogoUrl = Url.Content("~/images/logo.png")
            };

            return View(dtSistema);
        }
    }
}
