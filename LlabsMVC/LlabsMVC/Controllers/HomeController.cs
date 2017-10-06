using System;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Configuration;

namespace LlabsMVC.Controllers
{
    public class HomeController : Controller
    {
        private string UrlApi = ConfigurationManager.AppSettings["UrlApi"];
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List(int PageNumber=1, int PageSize=10)
        {
            LlabsDomain.Result lstEmployees = new LlabsDomain.Result();

            var client = new RestClient(UrlApi);

            var request = new RestRequest("/api/Employee?PageNumber="+PageNumber.ToString()+"&PageSize=" + PageSize.ToString(), Method.GET);

            IRestResponse RestResponseEmployee = client.Execute<LlabsDomain.Result>(request);

            if (RestResponseEmployee.StatusCode == HttpStatusCode.OK)
            {
                lstEmployees = JsonConvert.DeserializeObject<LlabsDomain.Result>(RestResponseEmployee.Content);

                return View(lstEmployees);
            }
            else
            {
                return View(RestResponseEmployee.Content);
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        [Route("acaocadastrar")]
        public JsonResult AcaoCadastrar(LlabsDomain.Employee Employee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var client = new RestClient(UrlApi);

                    var request = new RestRequest(string.Concat("api/Employee"), Method.POST);
                    request.AddJsonBody(Employee);
                    IRestResponse RestResponse = client.Execute<LlabsDomain.Employee>(request);

                    if (RestResponse.StatusCode == HttpStatusCode.Created)
                    {
                        TempData["MensagemSucesso"] = "Cadastrado efetuado com sucesso!";
                        return Json(new { Sucesso = true });
                    }
                    else
                    {
                        var message = JsonConvert.DeserializeObject<dynamic>(RestResponse.Content);

                        if (message.message != null)
                            return Json(new { Sucesso = false, Mensagem = string.Concat("Não foi possível efetuar o cadastro solicitado! <br /> Erro: ", message.message.Value) });
                        else
                            return Json(new { Sucesso = false, Mensagem = string.Concat("Não foi possível efetuar o cadastro solicitado! <br /> Erro: Não informado") });
                    }
                }
                else
                {
                    var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    string msg = "";

                    foreach (var erro in allErrors)
                    {
                        msg += (string.IsNullOrEmpty(msg) ? erro.ErrorMessage : string.Concat("<br />", erro.ErrorMessage));
                    }

                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Successo = false, Mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int PageNumber = 1, int PageSize = 10)
        {
            LlabsDomain.Result lstEmployees = new LlabsDomain.Result();

            var client = new RestClient(UrlApi);
            var request = new RestRequest("/api/Employee?PageNumber=" + PageNumber.ToString() + "&PageSize=" + PageSize.ToString(), Method.GET);

            IRestResponse RestResponseEmployee = client.Execute<LlabsDomain.Result>(request);

            if (RestResponseEmployee.StatusCode == HttpStatusCode.OK)
            {
                lstEmployees = JsonConvert.DeserializeObject<LlabsDomain.Result>(RestResponseEmployee.Content);

                return View(lstEmployees);
            }
            else
            {
                return View(RestResponseEmployee.Content);
            }
        }

        [HttpPost]
        [Route("acaodeletar")]
        public JsonResult AcaoDeletar(int Id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var client = new RestClient(UrlApi);

                    var request = new RestRequest(string.Concat("api/Employee/" + Id.ToString()), Method.DELETE);
                    IRestResponse RestResponse = client.Execute<LlabsDomain.Employee>(request);

                    if (RestResponse.StatusCode == HttpStatusCode.OK)
                    {
                        TempData["MensagemSucesso"] = "Item excluido com sucesso!";
                        return Json(new { Sucesso = true });
                    }
                    else
                    {
                        var message = JsonConvert.DeserializeObject<dynamic>(RestResponse.Content);

                        if (message.message != null)
                            return Json(new { Sucesso = false, Mensagem = string.Concat("Não foi possível excluir! <br /> Erro: ", message.message.Value) });
                        else
                            return Json(new { Sucesso = false, Mensagem = string.Concat("Não foi possível excluir! <br /> Erro: Não informado") });
                    }
                }
                else
                {
                    var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    string msg = "";

                    foreach (var erro in allErrors)
                    {
                        msg += (string.IsNullOrEmpty(msg) ? erro.ErrorMessage : string.Concat("<br />", erro.ErrorMessage));
                    }

                    throw new Exception(msg);
                }
            }
            catch (Exception ex)
            {
                return Json(new { Successo = false, Mensagem = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}