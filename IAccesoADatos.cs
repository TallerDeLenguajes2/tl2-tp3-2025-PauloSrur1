namespace TP1;

public interface IAccesoADatos
{
    List<Cliente> LeerClientes();
    List<Cadete> LeerCadetes();
    void GuardarClientes(List<Cliente> clientes);
    void GuardarCadetes(List<Cadete> cadetes);
}