using SampleProjectTwo.Data;
using SampleProjectTwo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleProjectTwo.Controllers
{
    public class UserController : ApiController
    {
        //[HttpGet]
        //public string Get(string name)
        //{
        //    return "Welcome" + name;
        //}
        DatabaseContext db = new DatabaseContext();
        //api/user
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }
        //api/user/id
        public User Get(int id)
        {
            return db.Users.Find(id);
        }
        //api/user
        public HttpResponseMessage Post(User model)
        {
            try
            {
                db.Users.Add(model);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            catch (Exception exception)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return response;
            }
        }
        public HttpResponseMessage Put(int id,User model)
        {
            try
            {
                if (id == model.UserId)
                {
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
               
            }
            catch (Exception exception)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

                return response;

            }
        }
        //api/user/id 
        public HttpResponseMessage Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }
        }
    }
}
