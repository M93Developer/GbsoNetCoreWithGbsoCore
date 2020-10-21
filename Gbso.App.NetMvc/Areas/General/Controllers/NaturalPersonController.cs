using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Gbso.App.Model.General;
using Gbso.Core.Attributes;
using Gbso.Core.Enumerators;
using Gbso.Core.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Gbso.App.NetMvc.Controllers
{
    
    public class NaturalPersonController : AppController
    {
        private string NaturalPersonUrl;
        public NaturalPersonController(IConfiguration configuration) : base(configuration)
        {
            NaturalPersonUrl = MainApiUrl+"NaturalPerson";
        }


        // GET: NaturalPersonController
        public async Task<ActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(NaturalPersonUrl);
                var persons = JsonConvert.DeserializeObject<NaturalPersonCollection>(json);
                return View(persons);
            }
        }

        // GET: NaturalPersonController/Details/5
        public async Task<ActionResult> Details(long key)
        {
            var person = await Get(key);
            return View(person);
        }

        // GET: NaturalPersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NaturalPersonController/Create
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NaturalPersonModel person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(person);
                }
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    
                    var result = await client.PostAsync(NaturalPersonUrl, data);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(person);
            }
        }

        // GET: NaturalPersonController/Edit/5
        public async Task<ActionResult> Edit(long key)
        {
            var person = await this.Get(key);
            person.ActionState = ActionStateEnum.Modified;
            return View(person);
        }

        // POST: NaturalPersonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(long key, NaturalPersonModel person)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(person);
                }
                using (var client = new HttpClient())
                {
                    var json = JsonConvert.SerializeObject(person);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PutAsync(string.Format("{0}/{1}", NaturalPersonUrl, key), data);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View(person);
            }
        }

        // GET: NaturalPersonController/Delete/5
        public async Task<ActionResult> Delete(long key)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    await client.DeleteAsync(string.Format("{0}/{1}", NaturalPersonUrl, key));
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: NaturalPersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(long key, NaturalPersonModel person)
        {
            try
            {
                if(key != person.Key)
                    return View();
                using (var client = new HttpClient())
                {
                    await client.DeleteAsync(string.Format("{0}/{1}", NaturalPersonUrl, key));
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                return View();
            }
        }


        internal async Task<NaturalPersonModel> Get(long key)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(string.Format("{0}/{1}", NaturalPersonUrl, key));
                var person = JsonConvert.DeserializeObject<NaturalPersonModel>(json);
                return person;
            }
        }
    }
}
