using TP1;

class Program
{
    static void Main()
    {
        Console.WriteLine("¿Qué formato de datos desea usar?");
        Console.WriteLine("1. CSV");
        Console.WriteLine("2. JSON");
        Console.Write("Opción: ");
        var formato = Console.ReadLine();

        IAccesoADatos accesoADatos;
        if (formato == "2")
            accesoADatos = new AccesoADatosJSON("clientes.json", "cadetes.json");
        else
            accesoADatos = new AccesoADatosCSV("clientes.csv", "cadetes.csv");

        var clientes = accesoADatos.LeerClientes();
        var cadetes = accesoADatos.LeerCadetes();
        Cadeteria cadeteria = new Cadeteria("Cadetería Express", "3814440000", cadetes);

        while (true)
        {
            Console.WriteLine("\n1. Alta pedido");
            Console.WriteLine("2. Asignar pedido a cadete");
            Console.WriteLine("3. Cambiar estado de pedido");
            Console.WriteLine("4. Reasignar pedido");
            Console.WriteLine("5. Jornal a cobrar por cadete");
            Console.WriteLine("6. Listar clientes");
            Console.WriteLine("7. Listar cadetes");
            Console.WriteLine("8. Listar pedidos");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
            var op = Console.ReadLine();

            if (op == "0") break;

            switch (op)
            {
                case "1":
                    Console.Write("Id pedido: ");
                    int idPedido = int.Parse(Console.ReadLine()!);
                    Console.Write("Observación: ");
                    string obs = Console.ReadLine()!;
                    Console.WriteLine("Clientes:");
                    foreach (var c in clientes) Console.WriteLine($"{c.Id}: {c.Nombre}");
                    Console.Write("Id cliente: ");
                    int idCliente = int.Parse(Console.ReadLine()!);
                    var cliente = clientes.FirstOrDefault(c => c.Id == idCliente);
                    if (cliente != null)
                    {
                        cadeteria.AgregarPedido(new Pedido(idPedido, obs, cliente));
                        Console.WriteLine("Pedido agregado.");
                    }
                    else Console.WriteLine("Cliente no encontrado.");
                    break;
                case "2":
                    Console.Write("Id pedido: ");
                    int idP = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Cadetes:");
                    foreach (var cad in cadetes) Console.WriteLine($"{cad.Id}: {cad.Nombre}");
                    Console.Write("Id cadete: ");
                    int idC = int.Parse(Console.ReadLine()!);
                    if (cadeteria.AsignarCadeteAPedido(idC, idP))
                        Console.WriteLine("Pedido asignado.");
                    else
                        Console.WriteLine("Error al asignar pedido.");
                    break;
                case "3":
                    Console.Write("Id pedido: ");
                    int idPC = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Estados: 0-Pendiente 1-Entregado 2-Cancelado");
                    int est = int.Parse(Console.ReadLine()!);
                    var pedido = cadeteria.Pedidos.FirstOrDefault(p => p.Id == idPC);
                    if (pedido != null)
                    {
                        pedido.Estado = (EstadoPedido)est;
                        Console.WriteLine("Estado cambiado.");
                    }
                    else
                        Console.WriteLine("Pedido no encontrado.");
                    break;
                case "4":
                    Console.Write("Id pedido: ");
                    int idPR = int.Parse(Console.ReadLine()!);
                    Console.WriteLine("Cadetes:");
                    foreach (var cad in cadetes) Console.WriteLine($"{cad.Id}: {cad.Nombre}");
                    Console.Write("Nuevo id cadete: ");
                    int idCN = int.Parse(Console.ReadLine()!);
                    if (cadeteria.AsignarCadeteAPedido(idCN, idPR))
                        Console.WriteLine("Pedido reasignado.");
                    else
                        Console.WriteLine("Error al reasignar pedido.");
                    break;
                case "5":
                    Console.WriteLine("Cadetes:");
                    foreach (var cad in cadetes) Console.WriteLine($"{cad.Id}: {cad.Nombre}");
                    Console.Write("Id cadete para calcular jornal: ");
                    int idJC = int.Parse(Console.ReadLine()!);
                    double jornal = cadeteria.JornalACobrar(idJC);
                    Console.WriteLine($"Jornal a cobrar: ${jornal}");
                    break;
                case "6":
                    Console.WriteLine("=== LISTA DE CLIENTES ===");
                    foreach (var clienteL in clientes)
                        Console.WriteLine($"{clienteL.Id}: {clienteL.Nombre} - {clienteL.Direccion} - {clienteL.Telefono}");
                    break;
                case "7":
                    Console.WriteLine("=== LISTA DE CADETES ===");
                    foreach (var cadeteL in cadetes)
                        Console.WriteLine($"{cadeteL.Id}: {cadeteL.Nombre} - {cadeteL.Direccion} - {cadeteL.Telefono}");
                    break;
                case "8":
                    Console.WriteLine("=== LISTA DE PEDIDOS ===");
                    foreach (var p in cadeteria.Pedidos)
                    {
                        Console.WriteLine($"Id: {p.Id}, Cliente: {p.Cliente.Nombre}, Estado: {p.Estado}, Cadete: {(p.CadeteAsignado != null ? p.CadeteAsignado.Nombre : "Sin asignar")}");
                    }
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}
