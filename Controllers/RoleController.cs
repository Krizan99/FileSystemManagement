﻿using FileSystemManagement.Data;
using FileSystemManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileSystemManagement.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDBContext _db;

        public RoleController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: RoleController
        public ActionResult Index()
        {
            List<Post> posts = _db.Posts.ToList();
            return Ok(posts);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            Post temp = _db.Posts.Find(id);
            return Ok(temp);
        }

        // GET: RoleController/Create
        public ActionResult Create(Post post)
        {
            try
            {
                _db.Posts.Add(post);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
            }
            return NotFound();
        }


        // GET: RoleController/Edit/5
        public ActionResult Edit(Post post,int id)
        {
            _db.Posts.Update(post);
            _db.SaveChanges();
            return Ok();
        }

        

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            Post temp = _db.Posts.Find(id);
            _db.Posts.Remove(temp);
            _db.SaveChanges();
            return Ok();
        }

       
    }
}