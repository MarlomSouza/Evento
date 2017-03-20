using System;
using System.Net;
using System.Net.Mail;
using Zaggie_Festa_.Models;

namespace Zaggie.Utility
{
    public static class  EnviaEmail
    {
        static MailMessage email = new MailMessage();

        static string nomeRemetente = "Zaggie";
        static string emailRemetente = "aliguijulmar@gmail.com";

        /// <summary>
        /// Método responsável por gerar uma senha para o usuário.
        /// </summary>
        /// <param name="usuario">Entidade do usuário</param>
        /// <returns></returns>
        private static string GeraSenha(Usuario usuario)
        {
            usuario.Senha = (usuario.Nome).Replace(" ", "") + DateTime.Now.Day + DateTime.Now.Second;
            return usuario.Senha;
        }

        /// <summary>
        /// Método responsável por criar um e-mail para o usuário
        /// </summary>
        /// <param name="usuario">Entidade do usuário</param>
        /// <param name="assuntoMensagem">Assunto da mensagem</param>
        /// <returns></returns>
        public static bool CriaEmail(Usuario usuario, string assuntoMensagem)
        {

            email.From = new MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            email.To.Add(usuario.Email);

            //Define a prioridade do e-mail.
            email.Priority = System.Net.Mail.MailPriority.High;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            email.IsBodyHtml = true;

            //Define título do e-mail.
            email.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            email.Body = "Sua nova senha é: " + GeraSenha(usuario);
            usuario.Senha = MD5.GerarMD5(usuario.Senha);
            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            email.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            email.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            //Cria objeto com os dados do SMTP
            //SmtpClient objSmtp = new SmtpClient("smtp.mail.yahoo.com", 587);
            SmtpClient objSmtp = new SmtpClient
            {
                Host = "Smtp.Gmail.com",
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                //Credentials = new NetworkCredential("marlom1012@gmail.com", "SENHA")/
                Credentials = new NetworkCredential("aliguijulmar@gmail.com", "$8jXpC8O")
            };

            //Enviamos o e-mail através do método .send()  
            try
            {
                objSmtp.Send(email);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                //excluí o objeto de e-mail da memória
                email.Dispose();
                //anexo.Dispose();
            }
        }

        /// <summary>
        /// Método responsável por validar se o e-mail é válido
        /// </summary>
        /// <param name="emailaddress">E-mail a ser verificado</param>
        /// <returns></returns>
        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}