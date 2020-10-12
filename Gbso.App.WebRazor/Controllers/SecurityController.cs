using Microsoft.AspNetCore.Mvc;
using Gbso.App.Model.SystemAdministration;
using Gbso.App.Business.General;

namespace Gbso.App.Web.Controllers
{
    public class SecurityController : Core.Mvc.Controller
    {
        public Profiles PerfilesRegistrar {
            get {
                //return SessionVewState["RegistrarPerfil-Perfiles"] as Profiles;
                return (Profiles)(SessionVewState["RegistrarPerfil-Perfiles"] ?? (SessionVewState["RegistrarPerfil-Perfiles"] = new Profiles()));
            }
            set { SessionVewState["RegistrarPerfil-Perfiles"] = value; }
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Este es el módulo de seguridad";
            return View();
        }

        public ActionResult RegistroPerfiles()
        {
            ViewBag.Message = "Cargué los perfiles a registrar";
            ViewBag.PerfilesCargados = PerfilesRegistrar;
            return View(new Profile());
        }

        [HttpPost]
        public ActionResult RegistroPerfiles(Profile perfil)
        {
            PerfilesRegistrar.Add(perfil);
            ViewBag.PerfilesCargados = PerfilesRegistrar;
            return View(new Profile());
        }

        [HttpPost]
        public ActionResult RegistrarPerfiles()
        {
            using (var business = new SecurityBusiness())
            {
                ViewBag.Message = string.Format("Se registraron {0} perfiles", business.RegisterProfiles(PerfilesRegistrar));
            }
            return View(new Profile());
        }

        public ActionResult ConsultarPerfiles()
        {
            using(var business = new SecurityBusiness())
            {
                ViewBag.Perfils = business.ListActiveProfiles();
            }
            ViewBag.Message = "Este es el módulo de seguridad";
            return View();
        }

        public ActionResult RegistrarPerfil()
        {
            ViewBag.Perfiles = PerfilesRegistrar;
            ViewBag.Message = "Registre los perfiles";
            return View(new Profile());
        }

        [HttpPost]
        public ActionResult RegistrarPerfil(Profile perfil)
        {
            ViewBag.Perfiles = PerfilesRegistrar;
            ViewBag.Message = "Perfil registrado con éxito";
            return View(perfil);
        }
    }
}