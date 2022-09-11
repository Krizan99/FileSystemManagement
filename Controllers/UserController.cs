using FileSystemManagement.Data;
using FileSystemManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext _db;

        public UserController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: UserController
        public ActionResult Index()
        {
            List<User> users = _db.Users.ToList();
            return Ok(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            User temp = _db.Users.Find(id);
            return Ok(temp);
        }

        // GET: UserController/Create
        public ActionResult Create(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex) 
            {
            }
            return NotFound();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(User user, int id)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok();
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            User temp = _db.Users.Find(id);
            _db.Users.Remove(temp);
            _db.SaveChanges();
            return Ok();
        }

    }
}
