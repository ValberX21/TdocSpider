using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TdocSpider.Application.Models.Entities;
using TdocSpider.Application.Models.ViewModels;
using TdocSpider.Application.Services;
using TdocSpider.Repository.Interfaces;
using TdocSpider.Tests.TestHelpers;

namespace TdocSpider.Tests.Services
{
    public class DocumentoServiceTests
    {
        private DocumentoService _service;
        private Mock<IDocumentoRepository> _mockRepo;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IDocumentoRepository>();
            _service = new DocumentoService(_mockRepo.Object);
        }

        [Test]
        public async Task Adiciona_Documento()
        {
            var docVm = new DocumentoViewModel
            {
                Id = 1,
                Titulo = "Teste",
                Descricao = "Descrição Teste",
                NomeArquivo = "arquivo.pdf",
                Arquivo = new FormFileMock("arquivo.pdf")
            };

            await _service.AddAsync(docVm);

            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Documento>()), Times.Once);
        }
    }
}
