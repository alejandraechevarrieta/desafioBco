using bco;
using bco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace bco.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Password()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Pagina()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }       
        //verifica número de tarjeta
        public bool Verificar(int numeroTarjeta)
        {
            try
            {
                bancoEntities1 db = new bancoEntities1();

                var cliente = db.Clientes.Where(x => x.tarjeta == numeroTarjeta).FirstOrDefault();
               
                if (cliente != null)
                {                   
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                ViewBag.User = e.Message;
                return false;
            }
        }
        //verifica contraseña
        public string VerificarPassword(string password, int numeroTarjeta)
        {
            try
            {
                bancoEntities1 db = new bancoEntities1();

                var unCliente = db.Clientes.Where(x => x.tarjeta == numeroTarjeta).FirstOrDefault();
                var unPassword = db.Clientes.Where(x => x.password == password).FirstOrDefault();
                var unIngreso = db.Ingresos.Where(x => x.idCliente == unCliente.idCliente).FirstOrDefault();
                
                //si la contraseña es correcta y existe un ingreso eliminarlo y entrar
                if (unPassword != null)
                {
                    if (unIngreso != null)
                    {
                        db.Ingresos.Remove(unIngreso);
                    }
                    return "correcto";
                }   ///si la contraseña es incorrecta y existe un ingreso sumar uno, sino agregar uno nuevo
                else
                {
                    if (unIngreso == null)
                    {
                        Ingresos nuevoIngreso = new Ingresos();
                        nuevoIngreso.idCliente = unCliente.idCliente;
                        nuevoIngreso.numeroIngreso = 1;
                        nuevoIngreso.bloqueado = false;
                        nuevoIngreso.FechaRegistro = DateTime.Now;
                        db.Ingresos.Add(nuevoIngreso);
                        db.SaveChanges();
                        return "incorrecto";
                    }
                    else //si exite un ingreso sumar uno
                    {
                        unIngreso.numeroIngreso++;
                        db.SaveChanges();
                        if (unIngreso.numeroIngreso >= 4)     //si el numero de ingreso es mayor a 4 bloquear
                        {      
                            unIngreso.bloqueado = true;
                            db.Ingresos.Remove(unIngreso);      //pongo esto provisorio para luego codear el tiempo de bloqueo
                            db.SaveChanges();
                            return "bloqueado";
                        }
                        else
                        {
                            return "incorrecto";
                        }                        
                    }                    
                }
            }
            catch (UnauthorizedAccessException e)
            {
                ViewBag.User = e.Message;
                return "incorrecto";
            }
        }
    }
}


