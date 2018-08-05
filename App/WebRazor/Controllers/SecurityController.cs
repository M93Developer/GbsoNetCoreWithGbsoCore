using Gbso.App.Business;
using Gbso.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gbso.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Gbso.App.Web.Controllers
{
    public class SecurityController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Este es el módulo de seguridad";
            return View();
        }

        public ProfilesCollection PerfilesCargados {
            get {
                return (Session["SecurityController-PerfilesCargados"] as ProfilesCollection) ?? ((Session["SecurityController-PerfilesCargados"] = new ProfilesCollection()) as ProfilesCollection);
            }
            set {
                Session["SecurityController-PerfilesCargados"] = value;
            }
        }

        public ActionResult RegistroPerfiles()
        {
            ViewBag.Message = "Cargué los perfiles a registrar";
            ViewBag.PerfilesCargados = PerfilesCargados;
            return View(new ProfileEntity());
        }

        [HttpPost]
        public ActionResult RegistroPerfiles(ProfileEntity perfil)
        {
            PerfilesCargados.Create(perfil);
            ViewBag.PerfilesCargados = PerfilesCargados;
            return View(new ProfileEntity());
        }

        [HttpPost]
        public ActionResult RegistrarPerfiles()
        {
            using (var business = new SecurityBusiness())
            {
                ViewBag.Message = string.Format("Se registraron {0} perfiles", business.RegisterProfiles(PerfilesCargados));
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
            if (Session["RegistrarPerfil-Perfiles"] == null) Session["RegistrarPerfil-Perfiles"] = new ProfilesCollection();
            ViewBag.Perfiles = Session["RegistrarPerfil-Perfiles"];
            ViewBag.Message = "Registre los perfiles";
            return View(new ProfileEntity());
        }

        [HttpPost]
        public ActionResult RegistrarPerfil(ProfileEntity perfil)
        {
            ((ProfilesCollection) (HttpContext.Session.Get(""))).Add(perfil);
            ViewBag.Perfiles = Session["RegistrarPerfil-Perfiles"];
            ViewBag.Message = "Perfil registrado con éxito";
            return View(perfil);
        }
    }
}