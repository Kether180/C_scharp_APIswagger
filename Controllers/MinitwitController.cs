using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Minitwit7.data;
using Minitwit7.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minitwit7.Controllers
{
    [Route("api/[controller]")]
    public class MinitwitController : ControllerBase
    {
        private readonly DataContext _context;

        public MinitwitController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("/RegisterUser")]
        public async Task<ActionResult<List<User>>> RegisterUser(User user) // registration endpoint - check user's registration errors on models
        {                                                               //  we need to use  BCrypt.Net.BCrypt.HashPassword
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        [Route("/AddUser")]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(_context.Users.ToList());
        }


        [HttpGet]
        [Route("/GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = _context.Users.ToList();

            return Ok(users);
        }

        [HttpPost]
        [Route("/AddMsg")]
        public async Task<ActionResult<List<Message>>> AddUMsg(Message msg)
        {
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();

            return Ok(_context.Messages.ToList());
        }

        [HttpGet]
        [Route("/GetMsgs")]
        public async Task<ActionResult<List<Message>>> GetMsgs()
        {
            var msgs = _context.Messages.ToList();

            return Ok(msgs);
        }

        [HttpGet]
        [Route("/GetMsgsByUser")]
        public async Task<ActionResult<List<Message>>> GetMsgsByUser(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            var msgs = _context.Messages.Where(x => x.AuthorId == user.UserId).ToList();

            return Ok(msgs);
        }

        [HttpPost]
        [Route("/AddFollower")]
        public async Task<ActionResult<List<Follower>>> AddFollower(Follower follower)
        {
            _context.Followers.Add(follower);
            await _context.SaveChangesAsync();

            return Ok(_context.Followers.ToList());
        }

        [HttpGet]
        [Route("/GetUserFollowers")]
        public async Task<ActionResult<List<User>>> GetUserFollowers(string username)
        {
            var followers = new List<User>();
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();
            var flws = _context.Followers.Where(x => x.WhoId == user.UserId).ToList();
            foreach (var follower in flws)
            {
                var userF = _context.Users.Where(x => x.UserId == follower.WhomId).FirstOrDefault();
                followers.Add(userF);
            }


            return Ok(followers);
        }


    }
}

