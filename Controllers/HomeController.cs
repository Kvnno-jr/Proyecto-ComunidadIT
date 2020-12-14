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
        public IActionResult Index()
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            var publicaciones = new List<Publicacion>();
            foreach (var seguido in db.Seguido.ToList())
            {
                if (seguido.UsuarioID == u_sesion.UsuarioID)
                {
                    foreach (var publicacion in db.Publicacion.ToList())
                    {
                        if ( (publicacion.UsuarioID == seguido.A_Seguir) )
                        {
                            publicaciones.Add(publicacion);
                        }
                    } 
                }
            }
            foreach (var publicacion in db.Publicacion.ToList())
            {
                if (( publicacion.UsuarioID == u_sesion.UsuarioID ))
                {
                    publicaciones.Add(publicacion);
                }
            }
            return View(publicaciones.OrderByDescending(t => t.Fecha));
        }
        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Publicacion()
        {
            var modelo = new PubliViewModel();
            modelo.Publicacion = db.Publicacion.ToList();
            /*modelo.Comentario = db.Comentario.ToList();
            modelo.Respuesta = db.Respuesta.ToList();
            modelo.Like = db.Like.ToList();*/
            return View(modelo);
        }


        /****** ACCIONES USUARIOS *****/


        public JsonResult CrearUsuario(string nickname)
        {
            Usuario usuario = new Usuario
            {
                UsuarioID = nickname,
            };
            db.Usuario.Add(usuario);
            db.SaveChanges();
            return Json(usuario);
        }
        public JsonResult BorrarUsuario(string nickname)
        {
            Usuario usuario = db.Usuario.Find(nickname);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return Json(usuario);
        }
        public JsonResult AgregarSesion(string nickname)
        {
        /*  https://localhost:5001/home/agregarsesion?nickname=kevinojea    */
        /*  https://localhost:5001/home/agregarsesion?nickname=pablomota    */
        /*  https://localhost:5001/home/agregarsesion?nickname=enriquekike  */
            Usuario u_sesion = new Usuario
            {
                UsuarioID = nickname,
            };
            HttpContext.Session.Set<Usuario>("UsuarioLogueado", u_sesion);
            return Json(u_sesion);
        }
        public JsonResult ConsultarSesion()
        /*  https://localhost:5001/home/consultarsesion */
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            return Json(u_sesion);
        }
        public JsonResult Seguir (string usuario)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Seguido seguido = new Seguido
            {
                A_Seguir = usuario,
                UsuarioID = u_sesion.UsuarioID,
            };
            Seguidor seguidor = new Seguidor
            {
                Un_Seguidor = u_sesion.UsuarioID,
                UsuarioID = usuario,
            };
            db.Seguido.Add(seguido);
            db.Seguidor.Add(seguidor);
            db.SaveChanges();
            return Json(db.Seguido.ToList());
        }
        public JsonResult DejarSeguir(string usuario)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            foreach (var seguido in db.Seguido.ToList())
            {
                if ( (seguido.A_Seguir == usuario) && (seguido.UsuarioID == u_sesion.UsuarioID) )
                {
                    db.Seguido.Remove(seguido);
                }
            }
            foreach (var seguidor in db.Seguidor.ToList())
            {
                if ( (seguidor.Un_Seguidor == u_sesion.UsuarioID) && (seguidor.UsuarioID == usuario) )
                {
                    db.Seguidor.Remove(seguidor);
                }
            }
            db.SaveChanges();
            return Json(db.Seguido.ToList());
        }


        /****** ACCIONES PUBLICACIONES *****/


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
            Publicacion publicacion = db.Publicacion.Find(ID);
            db.Publicacion.Remove(publicacion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /*public JsonResult VerPublis()
        {
            return Json(db.Publicacion.ToList());
        }*/
        /*public IActionResult CrearComent (string texto, int publicacion)
        {
            Usuario u_sesion = HttpContext.Session.Get<Usuario>("UsuarioLogueado");
            Comentario comentario = new Comentario
            {
                PublicacionID = publicacion,
                Texto = texto,
                UsuarioID = u_sesion.UsuarioID,
                Fecha = DateTime.Now,
            };

        }*/
    }
}