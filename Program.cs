using TP1;

class Program
{
    static void Main(string[] args)
    {
        // Selección de tipo de acceso a datos
        Console.WriteLine("Seleccione el tipo de acceso a datos: 1-CSV, 2-JSON");
        var opcion = Console.ReadLine();

        IAccesoADatos accesoADatos;
        if (opcion == "2")
        {
            accesoADatos = new AccesoADatosJSON("clientes.json", "cadetes.json");
        }
        else
        {
            accesoADatos = new AccesoADatosCSV("clientes.csv", "cadetes.csv");
        }

        // Cargar datos
        var clientes = accesoADatos.LeerClientes();
        var cadetes = accesoADatos.LeerCadetes();

        // Crear la cadetería
        var cadeteria = new Cadeteria("Cadetería Ejemplo", "3815555555", cadetes);

        int idPedido = 1;

        while (true)
        {
            Console.WriteLine("\n--- Menú Cadetería ---");
            Console.WriteLine("1. Dar de alta pedido");
            Console.WriteLine("2. Asignar pedido a cadete");
            Console.WriteLine("3. Cambiar estado de pedido");
            Console.WriteLine("4. Mostrar informe de cadetes");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            var menu = Console.ReadLine();

            if (menu == "0") break;

            switch (menu)
            {
                case "1":
                    // Alta de pedido
                  

                    Console.WriteLine("Seleccione cliente por ID:");
                    foreach (var cliente in clientes)
                        Console.WriteLine($"{cliente.Id}: {cliente.Nombre}");
                    int idCliente = int.Parse(Console.ReadLine() ?? "0");
                    var clienteSel = clientes.Find(c => c.Id == idCliente);
                    if (clienteSel == null)
                    {
                        Console.WriteLine("Cliente no encontrado.");
                        break;
                    }
                    var pedido = new Pedido(idPedido++, clienteSel);
                    cadeteria.AgregarPedido(pedido);
                    Console.WriteLine("Pedido agregado.");
                    break;

                case "2":
                    // Asignar pedido a cadete
                    Console.WriteLine("Seleccione pedido por ID:");
                    foreach (var p in cadeteria.Pedidos)
                        Console.WriteLine($"{p.Id}:  (Estado: {p.Estado})");
                    int idPed = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Seleccione cadete por ID:");
                    foreach (var cad in cadetes)
                        Console.WriteLine($"{cad.Id}: {cad.Nombre}");
                    int idCad = int.Parse(Console.ReadLine() ?? "0");
                    bool asignado = cadeteria.AsignarCadeteAPedido(idCad, idPed);
                    Console.WriteLine(asignado ? "Pedido asignado." : "No se pudo asignar.");
                    break;

                case "3":
                    // Cambiar estado de pedido
                    Console.WriteLine("Seleccione pedido por ID:");
                    foreach (var p in cadeteria.Pedidos)
                        Console.WriteLine($"{p.Id}: (Estado: {p.Estado})");
                    int idPedEstado = int.Parse(Console.ReadLine() ?? "0");
                    var pedidoEstado = cadeteria.Pedidos.Find(p => p.Id == idPedEstado);
                    if (pedidoEstado == null)
                    {
                        Console.WriteLine("Pedido no encontrado.");
                        break;
                    }
                    Console.WriteLine("Seleccione nuevo estado: 1-Pendiente, 2-Entregado, 3-Cancelado");
                    var est = Console.ReadLine();
                    switch (est)
                    {
                        case "1": pedidoEstado.Estado = EstadoPedido.Pendiente; break;
                        case "2": pedidoEstado.Estado = EstadoPedido.Entregado; break;
                        case "3": pedidoEstado.Estado = EstadoPedido.Cancelado; break;
                        default: Console.WriteLine("Estado inválido."); break;
                    }
                    Console.WriteLine("Estado actualizado.");
                    break;

                case "4":
                    // Informe de cadetes
                    var informe = cadeteria.ObtenerInformeCadetes();
                    Console.WriteLine("\n--- Informe de Cadetes ---");
                    foreach (var item in informe)
                    {
                        Console.WriteLine($"Cadete: {item.NombreCadete} | Pedidos entregados: {item.CantidadPedidos} | Monto ganado: ${item.MontoGanado}");
                    }
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }

        Console.WriteLine("Programa finalizado.");
    }
}