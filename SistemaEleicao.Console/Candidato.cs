
namespace SistemaEleicao.ConsoleApp;

public class Candidato
{
    public string Nome { get; }
    public int Numero { get; }
    public int Votos { get; private set; }

    public Candidato(string nome, int numero)
    {
        Nome = nome;
        Numero = numero;
        Votos = 0;
    }

    public void RegistrarVoto()
    {
        Votos++;
    }
}
