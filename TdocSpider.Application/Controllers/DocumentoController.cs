using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using System;
using TdocSpider.Application.Validations;
using TdocSpider.Application.Services.Interfaces;
using TdocSpider.Application.Helper;
using TdocSpider.Application.Models.ViewModels;
using System.Linq;

namespace TdocSpider.Application.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly ILogger<DocumentoController> _logger;
        private readonly DocumentoValidator _documentoValidator;
        private readonly IDocumentos _documentos;
        private readonly Conversoes _conversoes;

        public DocumentoController(ILogger<DocumentoController> logger,
                                    DocumentoValidator documentoValidator,
                                    IDocumentos documentos,
                                    Conversoes conversoes)
        {
            _logger = logger;
            _documentoValidator = documentoValidator;
            _documentos = documentos;
            _conversoes = conversoes;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> CriaDocumento(DocumentoViewModel document)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", document);
            }

            if (_documentoValidator.TituloJaExiste(document.Titulo))
            {
                ModelState.AddModelError("Titulo", "Já existe um documento com este título !");
                return View("Index", document);
            }

            if (!_documentoValidator.TipoArquivoPermitido(document.Arquivo))
            {
                ModelState.AddModelError("Arquivo", "O tipo de arquivo não é permitido.");
                return View("Index", document);

            }

            await _documentos.AddAsync(document);
            TempData["success"] = "Documento cadastrado com sucesso !";
            return RedirectToAction("ListDocumentos", "Documento");
        }

        public async Task<IActionResult> ListDocumentos(int page = 1, string filtroTitulo = "", string ordenarPor = "DataHoraCriacao", string direcao = "desc")
        {
            const int pageSize = 10;
            var todosDocumentos = await _documentos.GetAllAsync();

            if (!string.IsNullOrEmpty(filtroTitulo))
            {
                todosDocumentos = todosDocumentos
                    .Where(d => d.Titulo != null && d.Titulo.Contains(filtroTitulo, StringComparison.OrdinalIgnoreCase));
            }

            todosDocumentos = ordenarPor switch
            {
                "Titulo" => direcao == "asc" ? todosDocumentos.OrderBy(d => d.Titulo) : todosDocumentos.OrderByDescending(d => d.Titulo),
                _ => direcao == "asc" ? todosDocumentos.OrderBy(d => d.DataHoraCriacao) : todosDocumentos.OrderByDescending(d => d.DataHoraCriacao)
            };

            var totalItens = todosDocumentos.Count();
            var documentosPaginados = todosDocumentos
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var viewModel = new DocumentoPaginadoViewModel
            {
                Documentos = documentosPaginados,
                PaginaAtual = page,
                TotalPaginas = (int)Math.Ceiling(totalItens / (double)pageSize),
                FiltroTitulo = filtroTitulo
            };

            return View("ListarDocumentos", viewModel);
        }

        public async Task<IActionResult> DeletarDocumentos(int id)
        {
            var deletadoComSucesso = await _documentos.DeleteAsync(id);

            if (!deletadoComSucesso)
                return NotFound();

            TempData["success"] = "Documento deletado com sucesso !";
            return RedirectToAction("ListDocumentos");
        }

        public async Task<IActionResult> BaixaArquivo(int id)
        {
            var documento = await _documentos.GetByIdAsync(id);

            if (documento == null || documento.Arquivo == null)
            {
                return NotFound("Documento não encontrado.");
            }

            var contentType = _conversoes.GetContentType(documento.NomeArquivo);

            return File(
                    documento.Arquivo,
                    contentType,
                    Path.ChangeExtension(documento.NomeArquivo, documento.TipoArquivo)
                );
        }

        public async Task<IActionResult> Visualizar(int id)
        {
            var documento = await _documentos.GetByIdAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        public async Task<IActionResult> EditarDocumento(int id)
        {
            var documento = await _documentos.GetByIdAsync(id);

            if (documento == null)
            {
                return NotFound();
            }

            var viewModel = new DocumentoAtualizaViewModel
            {
                Id = documento.Id,
                Titulo = documento.Titulo,
                Descricao = documento.Descricao,
                NomeArquivo = documento.NomeArquivo,
                Arquivo = Conversoes.ByteArrayToFormFile(documento.Arquivo, documento.NomeArquivo)
            };

            return View("AtualizarDocumento", viewModel);
        }

        public async Task<IActionResult> AtualizaDoc(DocumentoAtualizaViewModel document)
        {
            if (document.Arquivo != null)
            {
                if (!_documentoValidator.TipoArquivoPermitido(document.Arquivo))
                {
                    ModelState.AddModelError("Arquivo", "O tipo de arquivo não é permitido.");
                    return View("AtualizarDocumento", document);
                }
            }

            await _documentos.UpdateAsync(document);
            TempData["success"] = "Documento atualizado com sucesso !";
            return RedirectToAction("ListDocumentos");
        }
    }
}
