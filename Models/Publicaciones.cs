using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Publicaciones.Models
{
    public class Usuario
    {   
        [Key] public string UsuarioID {get;set;}
        public string ImgPerfil {get;set;}
        public string Descripcion {get;set;}
        public string Email {get;set;}
    }
    public class Seguido
    {
        public string A_Seguir {get;set;}
        public string UsuarioID {get;set;}
    }
    public class Seguidor
    {
        public string Un_Seguidor {get;set;}
        public string UsuarioID {get;set;}
    }
    public class Publicacion
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int PublicacionID {get;set;}
        public string Texto {get;set;}
        public string UsuarioID {get;set;} 
        public DateTime Fecha {get;set;}
    }
    public class Comentario
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ComentarioID {get;set;}
        public int PublicacionID {get;set;}
        public string Texto {get;set;}
        public string UsuarioID {get;set;}
        public DateTime Fecha {get;set;}
    }
    public class Respuesta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int RespuestaID {get;set;}
        public int ComentarioID {get;set;}
        public string Texto {get;set;}
        public string UsuarioID {get;set;}
        public DateTime Fecha {get;set;}
    }
    public class Like
    {
        public int PubComResID {get;set;}
        public string Tipo {get;set;}
        public string UsuarioID {get;set;}
    }
    public class PubliViewModel
    {
        public Publicacion Publicacion {get;set;}
        public Comentario ComentResp {get;set;}
        public List<Comentario> Comentario {get;set;}
        public IEnumerable<Respuesta> Respuesta {get;set;}
        public IEnumerable<Like> Like {get;set;}
    }
    public class IndexViewModel
    {
        public IEnumerable<Publicacion> Publicacion {get;set;}
        public IEnumerable<Seguido> Seguido {get;set;}
        public IEnumerable<Seguidor> Seguidor {get;set;}
        public IEnumerable<Comentario> Comentario {get;set;}
        public IEnumerable<Like> Like {get;set;}
    }
}