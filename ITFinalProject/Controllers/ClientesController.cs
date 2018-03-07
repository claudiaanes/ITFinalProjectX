using ITFinalProject.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ITFinalProject.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clientes
        public ActionResult Index(string term, string numeroident, string numeroclient, string datanasc, string tipodoc, string numconta, string sortOrder, string currentFilter, int? page, int? pageSize, string TipoCliente)
        {
            var contas = db.Contas.Include(r => r.ClienteID);


            var tipodocm = db.TipoDocumentoes.ToList();
            List<SelectListItem> listaTipoDoc = new List<SelectListItem>();

            tipodocm.ForEach(x =>
            {
                listaTipoDoc.Add(new SelectListItem
                {
                    Value = x.TipoDocumentoID.ToString(),
                    Text = x.Descricao
                });
            });


            ViewBag.tipodocm = listaTipoDoc;

            ViewBag.pageSizes = new SelectList(new[] { 3,6, 10, 15 });
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_asc";
            int rPagesSize = pageSize ?? 5;
            int pageNumber = (page ?? 1);
            if (term != null)
            {
                page = 1;
            }
            else
            {
                term = currentFilter;

            }

            ViewBag.CurrentFilter = term;
            ViewBag.CurrentFilterNumeroIdentificacao = numeroident;
            ViewBag.CurrentFilterNumeroCliente = numeroclient;
            ViewBag.CurrentFilterDataNascimento = datanasc;
            ViewBag.CurrentFilterTipoDocumento = tipodoc;
            ViewBag.CurrentFilterNumeroConta = numconta;


            IEnumerable<Cliente> res = db.Clientes.ToList();

            
            if (!string.IsNullOrEmpty(term) || !string.IsNullOrEmpty(numeroident) || !string.IsNullOrEmpty(numeroclient) || !string.IsNullOrEmpty(datanasc) || !string.IsNullOrEmpty(tipodoc) || !string.IsNullOrEmpty(numconta))
            {
                //TODO: rever ideia
                int clienteId = 0;
                contas = contas.Where(x => x.NumeroConta.ToString() == numconta);
                if (contas.FirstOrDefault() != null)
                {
                    clienteId = contas.FirstOrDefault().ClienteID.ClienteID;
                    //TODO: Ver alternativas
                    res = res.Where(x => x.Nome.StartsWith(term, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.NumeroIdentificacao.StartsWith(numeroident, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.NumeroCliente.ToString().StartsWith(numeroclient, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.DataNascimento.Date.ToString().StartsWith(datanasc, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.TipoDocumento.TipoDocumentoID.ToString().StartsWith(tipodoc, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.ClienteID == clienteId);
                }
                if(numconta == "")
                {
                    res = res.Where(x => x.Nome.StartsWith(term, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.NumeroIdentificacao.StartsWith(numeroident, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.NumeroCliente.ToString().StartsWith(numeroclient, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.DataNascimento.Date.ToString().StartsWith(datanasc, StringComparison.InvariantCultureIgnoreCase))
                        .Where(x => x.TipoDocumento.TipoDocumentoID.ToString().StartsWith(tipodoc, StringComparison.InvariantCultureIgnoreCase));
                }
                else
                {
                    res = res.Where(x=> x.ClienteID == 0);
                }
                
                
                    
            }
            ViewBag.nResultados = res.Count();

            switch (sortOrder)
            {
                case "name_desc":
                    res = res.OrderByDescending(s => s.Nome);
                    break;
                case "name_asc":
                    res = res.OrderBy(s => s.Nome);
                    break;
                    //outros filtros
            }

            return View(res.ToPagedList(pageNumber, rPagesSize));
        }

        // POST: Clientes/Details/ trás o Id do Cliente
        [HttpPost]
        public ActionResult Details([Bind(Include = "selectIdClient")] string selectIdClient)
        {
            //Redirecionamos para a lista de detalhes e passamos -lhe o id do cliente que vamos mostrar
            return RedirectToAction("Details", new { id = int.Parse(selectIdClient) });

        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,Nome,DataNascimento,NumeroIdentificacao,NIF,NumeroCliente,Morada,Nacionalidade,Telemovel,Email,Balcao,Contrato")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nome,DataNascimento,NumeroIdentificacao,NIF,NumeroCliente,Morada,Nacionalidade,Telemovel,Email,Balcao,Contrato")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
