using System.Data;
using System.Linq;
using System.Web.Http;
using Zaggie.Utility;
using Zaggie_Festa_.Contexto;
using Zaggie_Festa_.Models;

namespace Zaggie.Controllers
{
    public class LoginController : ApiController
    {
        private DataContext db = new DataContext();

        public IHttpActionResult GetLogin(string email, string senha)
        {
            Usuario usuario;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
                return BadRequest();

            if (!EnviaEmail.IsValidEmail(email))
                return BadRequest("Email inválido!");

            usuario = db.Usuarios.Where(u => u.Email.Equals(email)).FirstOrDefault();

            if (usuario == null || !usuario.Senha.Equals(MD5.GerarMD5(senha)))
                return Unauthorized();

            return Ok(usuario);
        }


        // POST: api/Login
        public IHttpActionResult PostForgot_password([FromBody]Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Email))
                return BadRequest("Email não preenchido!");

            if (!EnviaEmail.IsValidEmail(usuario.Email))
                return BadRequest("Email inválido!");

            var usuarioBanco = db.Usuarios.Where(u => u.Email.Equals(usuario.Email)).FirstOrDefault();
            if (usuarioBanco != null)
            {
                if (EnviaEmail.CriaEmail(usuarioBanco, "Renovação de senha"))
                {
                    db.SaveChanges();
                    return Ok("Senha Alterada");
                }
            }
            return BadRequest("Email não existe na base!");
        }


        ///// <summary>
        ///// Método responsável pela recuperação de senhas
        ///// </summary>
        ///// <returns></returns>
        //// POST: Authenticate/forgot_password
        //[ActionName("Forgot_password")]
        //[ResponseType(typeof(Pessoa))]
        //public IHttpActionResult PostForgot_password(string email)
        //{
        //    if (string.IsNullOrEmpty(email))
        //        return BadRequest("Email não preenchido!");

        //    if (!EnviaEmail.IsValidEmail(email))
        //        return BadRequest("Email inválido!");

        //    var existeUsuario = db.Pessoas.Where(u => u.Email.Equals(email)).FirstOrDefault();
        //    if (existeUsuario != null)
        //    {
        //        Pessoa pessoa = existeUsuario;
        //        if (EnviaEmail.CriaEmail(pessoa, "Renovação de senha"))
        //        {
        //            db.SaveChanges();
        //            return Ok("Senha Alterada");
        //        }
        //    }
        //    return BadRequest("Email não existe na base!");
        //}


    }
}