using System;
using System.Text;

// ejercicio 1
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

// exer 4

class Electrodomestico
{
    protected const string ColorDef = "blanco";
    protected const char ConsumoDef = 'F';
    protected const double PrecioBaseDef = 100;
    protected const double PesoPorDef = 5;

    protected double precioBase;
    protected string color;
    protected char consumoEnergetico;
    protected double peso;

    public Electrodomestico()
    {
        precioBase = PrecioBaseDef;
        color = ColorDef;
        consumoEnergetico = ConsumoDef;
        peso = PesoPorDef;
    }

    public Electrodomestico(double precioBase, double peso)
    {
        this.precioBase = precioBase;
        color = ColorDef;
        consumoEnergetico = ConsumoDef;
        this.peso = peso;
    }

    public Electrodomestico(double precioBase, string color, char consumoEnergetico, double peso)
    {
        this.precioBase = precioBase;
        this.color = ComprobarColor(color);
        this.consumoEnergetico = ComprobarConsumoEnergetico(consumoEnergetico);
        this.peso = peso;
    }

    public double PrecioBase
    {
        get { return precioBase; }
    }

    public string Color
    {
        get { return color; }
    }

    public char ConsumoEnergetico
    {
        get { return consumoEnergetico; }
    }

    public double Peso
    {
        get { return peso; }
    }

    protected char ComprobarConsumoEnergetico(char letra)
    {
        //transoformo la letra a mayuscula por si un caso
        if ("ABCDEF".Contains(letra.ToString().ToUpper()))
            return letra;
        else
            return ConsumoDef;
    }

    protected string ComprobarColor(string color)
    {
        string[] coloresDisponibles = { "blanco", "negro", "rojo", "azul", "gris", "BLANCO", "NEGRO", "ROJO", "AZUL", "GRIS" };
        // si en el array (donce c es cada elemento) existe color.
        if (Array.Exists(coloresDisponibles, c => c == color))
            return color;
        else
            return ColorDef;
    }

    public double PrecioFinal()
    {
        double precioConsumo = 0;
        switch (consumoEnergetico)
        {
            case 'A':
                precioConsumo = 100;
                break;
            case 'B':
                precioConsumo = 80;
                break;
            case 'C':
                precioConsumo = 60;
                break;
            case 'D':
                precioConsumo = 50;
                break;
            case 'E':
                precioConsumo = 30;
                break;
            case 'F':
                precioConsumo = 10;
                break;
        }

        double precioPeso = 0;
        if (peso >= 0 && peso < 20)
            precioPeso = 10;
        else if (peso >= 20 && peso < 50)
            precioPeso = 50;
        else if (peso >= 50 && peso < 80)
            precioPeso = 80;
        else if ((peso >= 80))
            precioPeso = 100;

        return precioBase + precioConsumo + precioPeso;
    }
}
class Lavadora : Electrodomestico
{
    private const double CargaDef = 5;
    private double carga;

    public Lavadora()
        : base()
    {
        carga = CargaDef;
    }

    public Lavadora(double precioBase, double peso)
        : base(precioBase, peso)
    {
        carga = CargaDef;
    }

    public Lavadora(double carga) : base()
    {
        this.carga = carga;
    }

    public double Carga
    {
        get { return carga; }
    }

    public new double PrecioFinal()
    {
        double precioFinal = base.PrecioFinal();
        if (carga > 30)
            precioFinal += 50;

        return precioFinal;
    }
}
class Television : Electrodomestico
{
    private const double ResolucionDef = 20;
    private const bool SintonizadorDef = false;

    private double resolucion;
    private bool sintonizadorTDT;

    public Television()
        : base()
    {
        resolucion = ResolucionDef;
        sintonizadorTDT = SintonizadorDef;
    }

    public Television(double precioBase, double peso)
        : base(precioBase, peso)
    {
        resolucion = ResolucionDef;
        sintonizadorTDT = SintonizadorDef;
    }

    public Television(double resolucion, bool sintonizadorTDT, double precioBase, string color, char consumoEnergetico, double peso)
        : base(precioBase, color, consumoEnergetico, peso)
    {
        this.resolucion = resolucion;
        this.sintonizadorTDT = sintonizadorTDT;
    }

    public double Resolucion
    {
        get { return resolucion; }
    }

    public bool SintonizadorTDT
    {
        get { return sintonizadorTDT; }
    }

    public new double PrecioFinal()
    {
        double precioFinal = base.PrecioFinal();

        if (resolucion > 40)
            precioFinal *= 1.30;

        if (sintonizadorTDT)
            precioFinal += 50;

        return precioFinal;
    }
}

//Ejercicio 6
class Libro
{
    private string isbn;
    private string titulo;
    private string autor;
    private int numeroPaginas;

    //los metodos tienen que nombrarse distinto a los atributos de la clase. La primera es mayusucula
    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Autor
    {
        get { return autor; }
        set { autor = value; }
    }

    public int NumeroPaginas
    {
        get { return numeroPaginas; }
        set { numeroPaginas = value; }
    }

    public override string ToString()
    {
        return $"Libro {titulo}, ISBN: {isbn}, creador: {autor}, paginas: {numeroPaginas}";
    }
}

// ejercicio 7
class Raices
{
    private double a;
    private double b;
    private double c;

    public Raices(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public void ObtenerRaices()
    {
        double discriminante = GetDiscriminante();

        if (discriminante >= 0)
        {
            double raiz1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
            double raiz2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
            Console.WriteLine($"solucion +: {raiz1}");
            Console.WriteLine($"solucion -: {raiz2}");
        }
        else
        {
            Console.WriteLine("No existe la raiz");
        }
    }

    public void ObtenerRaiz()
    {
        double discriminante = GetDiscriminante();

        if (discriminante == 0)
        {
            double raiz = -b / (2 * a);
            Console.WriteLine($"Raiz unica: {raiz}");
        }
        else
        {
            Console.WriteLine("No tiene 1 solucion (tiene o 2 o ninguna)");
        }
    }

    public double GetDiscriminante()
    {
        return (b * b) - (4 * a * c);
    }

    public bool TieneRaices()
    {
        return GetDiscriminante() >= 0;
    }

    public bool TieneRaiz()
    {
        return GetDiscriminante() == 0;
    }

    public void Calcular()
    {
        if (TieneRaices())
        {
            ObtenerRaices();
        }
        else if (TieneRaiz())
        {
            ObtenerRaiz();
        }
        else
        {
            Console.WriteLine("No existen raíces reales.");
        }
    }
}

// ejercicio 8
class Persona2
{
    protected string nombre;
    protected int edad;
    protected string sexo;

    public Persona2(string nombre, int edad, string sexo)
    {
        this.nombre = nombre;
        this.edad = edad;
        this.sexo = sexo;
    }

    public string Nombre
    {
        get {return nombre;}
    }

    public int Edad
    {
        get {return edad;}
    }

    public string Sexo
    {
        get {return sexo;}
    }
}

class Estudiante : Persona2
{
    private double calificacion;
    private bool haceNovillos;

    public Estudiante(string nombre, int edad, string sexo, double calificacion)
        : base(nombre, edad, sexo)
    {
        this.calificacion = calificacion;
        this.haceNovillos = new Random().NextDouble() < 0.5;
    }

    public double Calificacion
    {
        get {return calificacion;}
    }

    public bool HaceNovillos
    {
        get {return haceNovillos;}
    }

    public void AsignarCalificacion(double calificacion)
    {
        if (calificacion >= 0 && calificacion <= 10)
            this.calificacion = calificacion;
        else 
            this.calificacion = 0;
    }

    public override string ToString()
    {
        return $"Estudiante: {Nombre}, Edad: {Edad}, Sexo: {Sexo}, Calificación: {Calificacion}";
    }
}

class Profesor : Persona2
{
    private string materia;
    private bool disponible;

    public Profesor(string nombre, int edad, string sexo, string materia)
        : base(nombre, edad, sexo)
    {
        this.materia = materia;
        this.disponible = new Random().NextDouble() >= 0.2;
    }

    public string Materia
    {
        get {return materia;}
    }

    public bool Disponible
    {
        get {return disponible;}
    }

    public override string ToString()
    {
        return $"Profesor: {Nombre}, Edad: {Edad}, Sexo: {Sexo}, Materia: {Materia}";
    }
}

class Aula
{
    private int id;
    private int capacidad;
    private string materia;
    private Profesor? profesor;
    private List<Estudiante> estudiantes;

    public Aula(int id, int capacidad, string materia)
    {
        this.id = id;
        this.capacidad = capacidad;
        this.materia = materia;
        this.profesor = null;
        this.estudiantes = new List<Estudiante>();
    }

    public void AsignarProfesor(Profesor profesor)
    {
        this.profesor = profesor;
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        estudiantes.Add(estudiante);
    }

    public bool PuedeDarClase()
    {
        if (profesor != null && profesor.Disponible && profesor.Materia == materia)
        {
            int aprobados = 0;
         
            foreach (Estudiante estudiante in estudiantes)
            {
                if (!estudiante.HaceNovillos && estudiante.Calificacion >= 5.0)
                    aprobados++;
            }

            double porcentajeAprobados = (double)aprobados / estudiantes.Count * 100;
            return porcentajeAprobados > 50;

        } else
        {
            return false;
        }
        
    }

    public int TotalEstudiantes()
    {
        return estudiantes.Count;
    }

    public int TotalAprobados()
    {
        int aprobados = 0;
        foreach (Estudiante estudiante in estudiantes)
        {
            if (estudiante.Calificacion >= 5.0)
                aprobados++;
        }
        return aprobados;
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

        Console.WriteLine("EJERCICIO 3: CONT5RASEÑAS");  //PRUEBAS EJERCICIO 3

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

        Electrodomestico[] electrodomesticos = new Electrodomestico[10];                //PRUEBAS EJERCICIO 4

        electrodomesticos[0] = new Electrodomestico(200, "negro", 'A', 25);
        electrodomesticos[1] = new Lavadora(300, 20);
        electrodomesticos[2] = new Television(40, true, 500, "gris", 'B', 30);
        electrodomesticos[3] = new Lavadora(250);
        electrodomesticos[4] = new Television(32, false, 400, "azul", 'E', 28);
        electrodomesticos[5] = new Electrodomestico(150, "rojo", 'D', 10);
        electrodomesticos[6] = new Television(50, true, 600, "negro", 'A', 35);
        electrodomesticos[7] = new Lavadora(180);
        electrodomesticos[8] = new Television(20, false, 300, "rojo", 'C', 15);
        electrodomesticos[9] = new Electrodomestico(100, "azul", 'F', 12);

        double precioTotalElectrodomesticos = 0;
        double precioTotalLavadoras = 0;
        double precioTotalTelevisiones = 0;

        foreach (Electrodomestico electrodomestico in electrodomesticos)
        {
            // si es televiison o lavadora se suma por separado pero en electrodomesticos se suma siempre
            if (electrodomestico is Lavadora)
            {
                precioTotalLavadoras += electrodomestico.PrecioFinal();
            }
            else if (electrodomestico is Television)
            {
                precioTotalTelevisiones += electrodomestico.PrecioFinal();
            }

            precioTotalElectrodomesticos += electrodomestico.PrecioFinal();
        }

        Console.WriteLine($"Precio total electrodomsticos: {precioTotalElectrodomesticos}");
        Console.WriteLine($"Precio total lavadoras: {precioTotalLavadoras}");
        Console.WriteLine($"Precio total televisiones: {precioTotalTelevisiones}");

        Console.WriteLine("\n\n");

        Libro libro1 = new Libro();                                                                    //PRUEBAS EJERCICIO 6
        libro1.ISBN = "3252435";
        libro1.Titulo = "La biblia";
        libro1.Autor = "Jesus";
        libro1.NumeroPaginas = 1645;

        Libro libro2 = new Libro();
        libro2.ISBN = "32424asdsf";
        libro2.Titulo = "Nemo";
        libro2.Autor = "Albert";
        libro2.NumeroPaginas = 500;

        Console.WriteLine(libro1.ToString());
        Console.WriteLine(libro2.ToString());

        if (libro1.NumeroPaginas > libro2.NumeroPaginas)
        {
            Console.WriteLine("El primer libro tiene mas paginas.");
        }
        else if (libro2.NumeroPaginas > libro1.NumeroPaginas)
        {
            Console.WriteLine("El segundo libro tiene mas paginas.");
        }
        else
        {
            Console.WriteLine("Tienen las mismas paginas");
        }

        Console.WriteLine("\n\n");

        double a = 1;                                                         // PRUEBA EJERCICIO 7
        double b = -3;
        double c = 2;

        Raices ecuacion = new Raices(a, b, c);
        ecuacion.Calcular();

        Console.WriteLine("\n\n");

        Profesor profesor = new Profesor("Profesor1", 40, "M", "mates");      //PRUEBA EJERCICIO 8
        Aula aula = new Aula(1, 20, "mates");

        aula.AsignarProfesor(profesor);

        for (int i = 0; i < 20; i++)
        {
            string nombre2 = "Estudiante " + i ;
            int edad2 = new Random().Next(18, 25);
            string sexo2 = i % 2 == 0 ? "M" : "F"; //meitat H MEITAT f
            double calificacion = new Random().NextDouble() * 10;
            Estudiante estudiante = new Estudiante(nombre2, edad2, sexo2, calificacion);
            aula.AgregarEstudiante(estudiante);
        }

        if (aula.PuedeDarClase())
        {
            Console.WriteLine("La clase puede ser impartida");
            Console.WriteLine("Total de estudiantes: "+ aula.TotalEstudiantes());
            Console.WriteLine("Estudiantes aprobados: "+ aula.TotalAprobados());
        }
        else
        {
            Console.WriteLine("La clase no puede ser impartida");
        }
    }

    //METODOS PERSONA (EJ 2)
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