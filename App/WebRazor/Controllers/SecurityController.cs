using Gbso.App.Business;
using Gbso.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Gbso.App.Web.Controllers
{
    public class SecurityController : Core.Mvc.Controller
    {
        public ProfilesCollection PerfilesRegistrar {
            get {
                get { return (ProfilesCollection)(SessionVewState["RegistrarPerfil-Perfiles"] ?? (SessionVewState["RegistrarPerfil-Perfiles"] = new ProfilesCollection())); }
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
            return View(new ProfileEntity());
        }

        [HttpPost]
        public ActionResult RegistroPerfiles(ProfileEntity perfil)
        {
            PerfilesRegistrar.Create(perfil);
            ViewBag.PerfilesCargados = PerfilesRegistrar;
            return View(new ProfileEntity());
        }

        [HttpPost]
        public ActionResult RegistrarPerfiles()
        {
            using (var business = new SecurityBusiness())
            {
                ViewBag.Message = string.Format("Se registraron {0} perfiles", business.RegisterProfiles(PerfilesRegistrar));
            }
            return View(new ProfileEntity());
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
            return View(new ProfileEntity());
        }

        [HttpPost]
        public ActionResult RegistrarPerfil(ProfileEntity perfil)
        {
            ViewBag.Perfiles = PerfilesRegistrar;
            ViewBag.Message = "Perfil registrado con éxito";
            return View(perfil);
        }
    }
}