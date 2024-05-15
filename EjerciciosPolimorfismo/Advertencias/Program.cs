using Advertencias;


class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Ejercicio Sobre-Sobrescrito";
        Sobreescrito objetoSobrescrito = new Sobreescrito();
        Console.WriteLine(objetoSobrescrito.ToString());
        string objeto = "¡Este es mi método ToString sobrescrito!";
        Console.WriteLine("----------------------------------------------");
        Console.Write("Comparación Sobrecargas con String: ");
        Console.WriteLine(objetoSobrescrito.Equals(objeto));
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(objetoSobrescrito.GetHashCode());
        Console.ReadKey();
    }
}

