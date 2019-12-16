using System;
using System.Threading;
 
 
namespace _50minutos_proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sem proxy\n---------\n");
 
 
            for (int i = 1; i <= 3; i++)
            {
                Usuario usuario = new Usuario();
 
 
                Console.WriteLine(usuario.Consultar());
 
                Console.WriteLine();
            }
 
 
            Console.WriteLine();
            Console.WriteLine();
 
 
            Console.WriteLine("Usando proxy para controlar a criação");
            Console.WriteLine("-------------------------------------");
 
 
            Console.WriteLine();
 
 
            IUsuario proxy;
            proxy = new ProxyUsuario();
 
 
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine(proxy.Consultar());
                Console.WriteLine();
            }
 
 
            Console.ReadKey();
        }
    }
 
 
    //ISubject
 
    public interface IUsuario
    {
        //Request()
        String Consultar();
    }
 
    //Subject
    public class Usuario
    {
        public Usuario()
        {
            Console.WriteLine("criei");
 
 
            Thread.Sleep(2000);
        }
 
 
        //Request()
        public String Consultar()
        {
            return String.Format("consultei");
        }
    }
 
 
    //Proxy
    public class ProxyUsuario : IUsuario
    {
        //ISubject
        Usuario u;
 
 
        //Request
        public String Consultar()
        {
            if (this.u == null)
                this.u = new Usuario();
 
 
            return u.Consultar();
        }
    }
}
