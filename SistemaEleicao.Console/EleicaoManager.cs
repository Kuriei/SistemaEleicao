
namespace SistemaEleicao.ConsoleApp;

public class EleicaoManager
{
    private readonly List<Candidato> _candidatos = new();
    private readonly List<Eleitor> _eleitores = new();

    public IReadOnlyList<Candidato> Candidatos => _candidatos.AsReadOnly();

    public int TotalVotosNulos { get; private set; }
    public int TotalVotosBrancos { get; private set; }

    public bool AdicionarCandidato(string nome, int numero)
    {
        if (string.IsNullOrWhiteSpace(nome) || numero <= 0)
            return false;

        if (_candidatos.Any(c => c.Numero == numero))
            return false;

        _candidatos.Add(new Candidato(nome.Trim(), numero));
        return true;
    }

    public bool RegistrarEleitor(string documento)
    {
        if (string.IsNullOrWhiteSpace(documento))
            return false;

        documento = documento.Trim();

        if (_eleitores.Any(e =>
            e.Documento.Equals(documento, StringComparison.OrdinalIgnoreCase)))
            return false;

        _eleitores.Add(new Eleitor(documento));
        return true;
    }

    public bool Votar(string documentoEleitor, string escolha)
    {
        if (string.IsNullOrWhiteSpace(documentoEleitor) ||
            string.IsNullOrWhiteSpace(escolha))
            return false;

        Eleitor? eleitor = _eleitores.FirstOrDefault(e =>
            e.Documento.Equals(
                documentoEleitor.Trim(),
                StringComparison.OrdinalIgnoreCase));

        if (eleitor == null || eleitor.JaVotou)
            return false;

        eleitor.RegistrarVoto();
        escolha = escolha.Trim();

        if (escolha.Equals("BRANCO", StringComparison.OrdinalIgnoreCase))
        {
            TotalVotosBrancos++;
            return true;
        }

        if (escolha.Equals("NULO", StringComparison.OrdinalIgnoreCase))
        {
            TotalVotosNulos++;
            return true;
        }

        if (int.TryParse(escolha, out int numero))
        {
            Candidato? candidato = _candidatos.FirstOrDefault(
                c => c.Numero == numero);

            if (candidato != null)
            {
                candidato.RegistrarVoto();
                return true;
            }
        }

        TotalVotosNulos++;
        return true;
    }

    public IReadOnlyList<Candidato> ObterVencedores()
    {
        if (_candidatos.Count == 0)
            return Array.Empty<Candidato>();

        int maiorNumeroDeVotos = _candidatos.Max(c => c.Votos);

        if (maiorNumeroDeVotos == 0)
            return Array.Empty<Candidato>();

        return _candidatos
            .Where(c => c.Votos == maiorNumeroDeVotos)
            .ToList()
            .AsReadOnly();
    }
}
