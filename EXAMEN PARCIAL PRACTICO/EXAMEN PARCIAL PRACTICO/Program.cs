using System;

namespace SistemaInventario
{
    // Esta ees mi clase base profesor
    class Producto
    {
        private string nombre;
        private string codigo;
        private double precio;
        private int cantidad;

        public Producto(string nombre, string codigo, double precio, int cantidad)
        {
            this.nombre = nombre;
            this.codigo = codigo;
            this.precio = precio;
            this.cantidad = cantidad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }

        public virtual void MostrarProducto()
        {
            Console.WriteLine($"Producto: {Nombre}");
            Console.WriteLine($"Codigo: {Codigo}");
            Console.WriteLine($"Precio: {Precio}");
            Console.WriteLine($"Cantidad: {Cantidad}");
        }

        public virtual double CalcularImpuesto() => 0;
    }

    // Clase esta es mi clase deribada, o sea
    class ProductoElectronico : Producto
    {
        private int garantiaMeses;
        public ProductoElectronico(string nombre, string codigo, double precio, int cantidad, int garantia)
            : base(nombre, codigo, precio, cantidad) => garantiaMeses = garantia;

        public int GarantiaMeses { get => garantiaMeses; set => garantiaMeses = value; }

        public override double CalcularImpuesto() => Precio * 0.18;
    }

    // otraclase deribada
    class ProductoAlimento : Producto
    {
        private string fechaVencimiento;
        public ProductoAlimento(string nombre, string codigo, double precio, int cantidad, string fecha)
            : base(nombre, codigo, precio, cantidad) => fechaVencimiento = fecha;
        public string FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }

        public override double CalcularImpuesto() => Precio * 0.08;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // usé su mismo ejemplo, espero no le molestee

            ProductoElectronico laptop = new ProductoElectronico("Laptop", "P1001", 45000, 5, 12);
            laptop.MostrarProducto();
            Console.WriteLine($"Garantia: {laptop.GarantiaMeses} meses");
            Console.WriteLine($"Impuesto: {laptop.CalcularImpuesto()}");

            ProductoAlimento leche = new ProductoAlimento("Leche", "A2002", 75, 20, "20/12/2025");
            leche.MostrarProducto();
            Console.WriteLine($"Vencimiento: {leche.FechaVencimiento}");
            Console.WriteLine($"Impuesto: {leche.CalcularImpuesto()}");

            Console.ReadKey();
        }
    }
}