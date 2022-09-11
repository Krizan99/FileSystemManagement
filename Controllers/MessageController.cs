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
    public class MessageController : Controller
    {
        private readonly ApplicationDBContext _db;

        public MessageController(ApplicationDBContext db) 
        {
            _db = db;
        }
        // GET: MessageController
        public ActionResult Index()
        {
            List<Message> messages = _db.Messages.ToList();
            return Ok(messages);
        }

        // GET: MessageController/Details/5
        public ActionResult Details(int id)
        {
            Message temp = _db.Messages.Find(id);
            _db.Entry(temp).Reference(t => t.Sender).Load();
            _db.Entry(temp).Reference(t => t.Receiver).Load();
            return Ok(temp);
        }

        // GET: MessageController/Create
        public ActionResult Create(int senderId, int receiverId, Message message)
        {
            try
            {
                User sender = _db.Users.Find(1);
                User receiver = _db.Users.Find(5);
                message.Sender = sender;
                message.Receiver = receiver;
                sender.SentMessages.Add(message);
                receiver.ReceivedMessages.Add(message);
                _db.Messages.Add(message);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
            }
            return NotFound();
        }

        
        // GET: MessageController/Edit/5
        public ActionResult Edit(Message message, int id)
        {
            _db.Messages.Update(message);
            _db.SaveChanges();
            return Ok();
        }

       
        // GET: MessageController/Delete/5
        public ActionResult Delete(int id)
        {
            Message temp = _db.Messages.Find(id);
            _db.Messages.Remove(temp);
            _db.SaveChanges();
            return Ok();
        }

       
    }
}
