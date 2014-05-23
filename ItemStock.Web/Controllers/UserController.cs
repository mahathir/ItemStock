using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ItemStock.Api.Client;
using ItemStock.DTO.Implementation;

namespace ItemStock.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public async Task<ActionResult> Index()
        {
            var users = await HttpClientHelper.Get<ICollection<AppUser>>("user");
            return View(users);
        }

        //
        // GET: /User/Details/5

        public async Task<ActionResult> Details(Guid id)
        {
            var user = await HttpClientHelper.Get<AppUser>("user/" + id);
            return View(user);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public async Task<ActionResult> Create(AppUser user)
        {
            try
            {
                await HttpClientHelper.Post<AppUser>("user", user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public async Task<ActionResult> Edit(Guid id)
        {
            var user = await HttpClientHelper.Get<AppUser>("user/" + id);
            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public async Task<ActionResult> Edit(AppUser user)
        {
            try
            {
                await HttpClientHelper.Put<AppUser>("user", user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await HttpClientHelper.Get<AppUser>("user/" + id);
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public async Task<ActionResult> Delete(AppUser user)
        {
            try
            {
                await HttpClientHelper.Delete("user/" + user.Id.ToString());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
