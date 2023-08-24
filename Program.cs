using System;
using System.Text;

class Cuenta
{
    private string titular;
    private double cantidad;

    public Cuenta(string titular)
    {
        this.titular = titular;
        this.cantidad = 0;
    }

    public Cuenta(string titular, double cantidad)
    {
        this.titular = titular;
        this.cantidad = cantidad;
    }

    public string Titular
    {
        get {return titular;}
        set {titular = value;}
    }

    public double Cantidad
    {
        get {return cantidad;}
        set {cantidad = value;}
    }

    public override string ToString()
    {
        return $"Titular: {titular}, Cantidad: {cantidad}";
    }

    public void Ingresar(double cantidad)
    {
        if (cantidad > 0)
        {
            this.cantidad += cantidad;
        }
    }

    public void Retirar(double cantidad)
    {
        if (cantidad > 0 && this.cantidad >= cantidad)
        {
            this.cantidad -= cantidad;
        }
        else if (cantidad > 0 && this.cantidad < cantidad)
        {
            this.cantidad = 0;
        }
    }
}

// ejercicio 2

class Persona
{
    private const char SexoDef = 'H';

    private string nombre;
    private int edad;
    private string DNI;
    private char sexo;
    private double peso;
    private double altura;

    public Persona()
    {
        this.nombre = "";
        this.edad = 0;
        this.DNI = GenerarDNI();
        this.sexo = SexoDef;
        this.peso = 0;
        this.altura = 0;
    }

    public Persona(string nombre, int edad, char sexo)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.DNI = GenerarDNI();
        this.sexo = ComprobarSexo(sexo);
        this.peso = 0;
        this.altura = 0;
    }

    public Persona(string nombre, int edad, char sexo, double peso, double altura)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.DNI = GenerarDNI();
        this.sexo = ComprobarSexo(sexo);
        this.peso = peso;
        this.altura = altura;
    }

    public string Nombre
    {
        get {return nombre;}
        set {nombre = value;}
    }

    public int Edad
    {
        get {return edad;}
        set {edad = value;}
    }

    public char Sexo
    {
        get {return sexo;}
        set {sexo = value;}
    }

    public double Peso
    {
        get {return peso;}
        set {peso = value;}
    }

    public double Altura
    {
        get {return altura;}
        set {altura = value;}
    }

    public double CalcularIMC()
    {
        double imc = peso / (altura * altura);
        if (imc < 20)
            return -1;
        else if (imc >= 20 && imc <= 25)
            return 0;
        else
            return 1;
    }

    public bool EsMayorDeEdad()
    {
        return edad >= 18;
    }

    private char ComprobarSexo(char sexo)
    {
        if (sexo == 'H' || sexo == 'M')
            return sexo;
        else
            return SexoDef;
    }

    private string GenerarDNI()
    {
        // numero random de 9 cifras entre 10000000 y 99999999. El primer uno es para asegurar que tendra 8 cifras
        Random random = new Random();
        int numDNI = random.Next(10000000, 99999999);

        string letras = "TRWAGMYFPDXBNJZSQVHLCKE";

        //el resultado del modulo del numero del dni partido entre 23 da como resultado la posicion de la letra que le corresponde
        int pos = numDNI % 23;
        char letra = letras[pos];

        return (numDNI.ToString() + letra);
    }

    public override string ToString()
    {
        return $"Nombre: {nombre}, Edad: {edad}, DNI: {DNI}, Sexo: {sexo}, Peso: {peso}, Altura: {altura}";
    }
}

// exer 3

class Password
{
    private const int LongitudDef = 8;

    private int longitud;
    private string pass;

    public Password()
    {
        longitud = LongitudDef;
        pass = GenerarPassword();
    }

    public Password(int longitud)
    {
        this.longitud = longitud;
        pass = GenerarPassword();
    }

    public bool EsFuerte()
    {
        int mayusculas = 0;
        int minusculas = 0;
        int numeros = 0;

        foreach (char c in pass)
        {
            if (char.IsUpper(c))
                mayusculas++;
            else if (char.IsLower(c))
                minusculas++;
            else if (char.IsDigit(c))
                numeros++;
        }

        return mayusculas >= 2 && minusculas >= 1 && numeros >= 5;
    }

    private string GenerarPassword()
    {
        const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        string contra = "";
        Random random = new Random();


        for (int i = 0; i < longitud; i++)
        {
            //genero un numero que correspondra a un caracter de l'string caracteres
            int pos = random.Next(caracteres.Length);
            //concateno el caracter corresponent a la posicio random generada abans
            contra = contra + caracteres[pos];
        }

        return contra;
    }

    public string Pass
    {
        get {return pass;}
    }

    public int Longitud
    {
        get {return longitud;}
        set
        {
            if (value > 0)
                longitud = value;
            else
                Console.WriteLine("No has insertado ningun caracter");
        }
    }
}


class Programa
{
    static void Main(string[] args)
    {

        Console.WriteLine("EJERCICIO 2: PERSONA \n\n");     //PRUEBAS EJERCICIO 2
        Console.WriteLine("Datos primera persona:");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Edad: ");
        int edad = int.Parse(Console.ReadLine());

        Console.Write("Sexo (H/M): ");
        char sexo = char.Parse(Console.ReadLine());

        Console.Write("Peso: ");
            
            double peso = double.Parse(Console.ReadLine());

        Console.Write("Altura: ");
        double altura = double.Parse(Console.ReadLine());

        Persona persona1 = new Persona(nombre, edad, sexo, peso, altura);

        Console.WriteLine("Datos segunda persona:");
        Console.Write("Nombre: ");
        nombre = Console.ReadLine();

        Console.Write("Edad: ");
        edad = int.Parse(Console.ReadLine());

        Console.Write("Sexo (H/M): ");
        sexo = char.Parse(Console.ReadLine());

        Persona persona2 = new Persona(nombre, edad, sexo);
        Persona persona3 = new Persona();
        persona3.Nombre = "Albert";
        persona3.Edad = 22;
        persona3.Sexo = 'H';
        persona3.Peso = 78;
        persona3.Altura = 1.85;

        MostrarInformacion(persona1);
        MostrarInformacion(persona2);
        MostrarInformacion(persona3);

        Console.WriteLine("\n\n");

        Console.WriteLine("EJERCICIO 3: CONT5RASEÑAS");  //PRUEVAS EJERCICIO 3

        Console.Write("Cuantas contraseñas quieres crear?");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("De que longitud?");
        int longitud = int.Parse(Console.ReadLine());

        Password[] passwords = new Password[cantidad];
        bool[] contraseñasFuertes = new bool[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            passwords[i] = new Password(longitud);
            contraseñasFuertes[i] = passwords[i].EsFuerte();
        }

        Console.WriteLine("Contraseñas:");
        for (int i = 0; i < cantidad; i++)
        {
            if (contraseñasFuertes[i])
                Console.WriteLine($"{passwords[i].Pass} Fuerte");
            else
                Console.WriteLine($"{passwords[i].Pass} Debil");
        }
        Console.WriteLine("\n\n");
    }
    static void MostrarInformacion(Persona persona)
    {
        Console.WriteLine(persona);

        double resultadoIMC = persona.CalcularIMC();
        if (resultadoIMC == -1)
            Console.WriteLine("Esta debajo de su peso ideal");
        else if (resultadoIMC == 0)
            Console.WriteLine("Peso ideal");
        else
            Console.WriteLine("Por encima del peso ideal");

        if (persona.EsMayorDeEdad())
            Console.WriteLine("Mayor de edad");
        else
            Console.WriteLine("Menro de edad");

        Console.WriteLine('\n');
    }
}
