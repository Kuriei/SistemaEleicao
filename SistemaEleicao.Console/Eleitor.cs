
namespace SistemaEleicao.ConsoleApp;

public class Eleitor
{
    public string Documento { get; }
    public bool JaVotou { get; private set; }

    public Eleitor(string documento)
    {
        Documento = documento;
        JaVotou = false;
    }

    public void RegistrarVoto()
    {
        JaVotou = true;
    }
}
