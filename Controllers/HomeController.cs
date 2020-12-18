using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Publicaciones.Models;

namespace Publicaciones.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly Context db;
        public HomeController(ILogger<HomeController> logger,
            Context contexto)
        {
            this.logger = logger;
            this.db=contexto;
        }
        
        

        /****** VISTAS *****/

        public IActionResult Index()
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            var m = new IndexViewModel();
            var p = new List<Publicacion>();
            m.Seguido = db.Seguido.Where(s => s.UsuarioID == u_sesion.UsuarioID).ToList();
            foreach(var publi in db.Publicacion.ToList())
            {
                foreach (var seguido in m.Seguido.Where(s => s.A_Seguir == publi.UsuarioID))
                {
                    p.Add(publi);
                }
                if(publi.UsuarioID == u_sesion.UsuarioID)
                {
                    p.Add(publi);
                }
            }
            m.Publicacion = p.OrderByDescending(f => f.Fecha).ToList();
            return View(m);
        }
        public IActionResult Perfil()
        {
            return View();
        }
        public IActionResult Publicacion(int ID)
        {
            var m = new PubliViewModel();
            var r = new List<Respuesta>();
            m.Publicacion = db.Publicacion.Find(ID);
            m.Comentario = db.Comentario.Where(c => c.PublicacionID == m.Publicacion.PublicacionID).OrderBy(f => f.Fecha).ToList();
            foreach (var coment in m.Comentario.ToList())
            {
                foreach (var resp in db.Respuesta.Where(r => r.ComentarioID == coment.ComentarioID).ToList())
                {
                    r.Add(resp);
                }
            }
            m.Respuesta = r.OrderBy(f => f.Fecha).ToList();
            m.Like = db.Like.ToList();
            return View(m);
        }



        /****** ACCIONES USUARIOS *****/

        public JsonResult CrearUsuario(string user)
        {
            Usuario usuario = new Usuario
            {
                UsuarioID = user,
            };
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return Json(usuario);
        }
        public JsonResult BorrarUsuario(string user)
        {
            foreach (var seguido in db.Seguido.Where(s => (s.UsuarioID == user) || (s.A_Seguir == user)))
            {
                db.Seguido.Remove(seguido);
            }
            foreach (var seguidor in db.Seguidor.Where(s => (s.Un_Seguidor == user) || (s.UsuarioID == user)))
            {
                db.Seguidor.Remove(seguidor);
            }
            foreach (var publicacion in db.Publicacion.Where(s => s.UsuarioID == user))
            {
                foreach (var comentario in db.Comentario.Where(c => (c.PublicacionID == publicacion.PublicacionID) || (c.UsuarioID == user)))
                {
                    foreach (var respuesta in db.Respuesta.Where(r => (r.ComentarioID == comentario.ComentarioID) || (r.UsuarioID == user)))
                    {
                        db.Respuesta.Remove(respuesta);
                    }
                    db.Comentario.Remove(comentario);
                }
                db.Publicacion.Remove(publicacion);
            }
            db.Usuario.Remove(db.Usuario.Find(user));
            db.SaveChanges();
            return Json(db.Usuario.ToList());
        }
        public JsonResult AgregarSesion(string user)
        {
            Usuario u_sesion = new Usuario
            {
                UsuarioID = user,
            };
            HttpContext.Session.Set<Usuario>("UsuarioLogueado", u_sesion);
            return Json(u_sesion);
        }
        /*  https://localhost:5001/home/agregarsesion?user=coco */
        /*  https://localhost:5001/home/agregarsesion?user=lola */
        /*  https://localhost:5001/home/agregarsesion?user=toby */
        /*  https://localhost:5001/home/agregarsesion?user=mora */
        public IActionResult Seguir (string user)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Seguido seguido = new Seguido
            {
                A_Seguir = user,
                UsuarioID = u_sesion.UsuarioID,
            };
            Seguidor seguidor = new Seguidor
            {
                Un_Seguidor = u_sesion.UsuarioID,
                UsuarioID = user,
            };
            db.Seguido.Add(seguido);
            db.Seguidor.Add(seguidor);
            db.SaveChanges();
            return Json(db.Seguido.ToList());
        }
        public IActionResult DejarSeguir(string user)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            foreach (var seguido in db.Seguido.Where(s => (s.A_Seguir == user) & (s.UsuarioID == u_sesion.UsuarioID)).ToList())
            {
                db.Seguido.Remove(seguido);
            }
            foreach (var seguidor in db.Seguidor.Where(s => (s.Un_Seguidor == u_sesion.UsuarioID) & (s.UsuarioID == user)).ToList())
            {
                db.Seguidor.Remove(seguidor);
            }
            db.SaveChanges();
            return Json(db.Seguido.ToList());
        }



        /****** ACCIONES PUBLICACIONES *****/

        public IActionResult CrearComent (string texto, int ID)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Comentario comentario = new Comentario
            {
                Texto = texto,
                PublicacionID = ID,
                UsuarioID = u_sesion.UsuarioID,
                Fecha = DateTime.Now,
            };
            db.Comentario.Add(comentario);
            db.SaveChanges();
            return Json(db.Comentario.ToList());
        }
        public IActionResult BorrarComent (int ID)
        {
            foreach (var respuesta in db.Respuesta.Where(r => r.ComentarioID == ID).ToList())
            {
                db.Respuesta.Remove(respuesta);
            }
            db.Comentario.Remove(db.Comentario.Find(ID));
            db.SaveChanges();
            return Json(db.Comentario.ToList());
        }
        public IActionResult CrearResp (string texto, int ID)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Respuesta respuesta = new Respuesta
            {
                Texto = texto,
                ComentarioID = ID,
                UsuarioID = u_sesion.UsuarioID,
                Fecha = DateTime.Now,
            };
            db.Respuesta.Add(respuesta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BorrarResp (int ID)
        {
            db.Respuesta.Remove(db.Respuesta.Find(ID));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult CrearPubli(string texto)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if(u_sesion != null)
            {
                Publicacion publicacion = new Publicacion
                {
                    Texto = texto,
                    UsuarioID = u_sesion.UsuarioID,
                    Fecha = DateTime.Now
                };
                db.Publicacion.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Json("Para agregar nota hay que loguear");
            }
        }
        public IActionResult BorrarPubli(int ID)
        {
            foreach (var comentario in db.Comentario.Where(c => c.PublicacionID == ID).ToList())
            {
                foreach (var respuesta in db.Respuesta.Where(r => r.ComentarioID == comentario.ComentarioID).ToList())
                {
                    db.Respuesta.Remove(respuesta);
                }
                db.Comentario.Remove(comentario);
            }
            db.Publicacion.Remove(db.Publicacion.Find(ID));
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Like (int ID, string tipo)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            if (db.Like.Where(l => (l.PubComResID == ID) && (l.Tipo == tipo) && (l.UsuarioID == u_sesion.UsuarioID)).Count() == 0)
            {
                Like like = new Like
                {
                    PubComResID = ID,
                    Tipo = tipo,
                    UsuarioID = u_sesion.UsuarioID,
                };
                db.Like.Add(like);
            }
            else
            {
                foreach (var like in db.Like.Where(l => (l.PubComResID == ID) && (l.Tipo == tipo) && (l.UsuarioID == u_sesion.UsuarioID)))
                {
                    db.Like.Remove(like);
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}