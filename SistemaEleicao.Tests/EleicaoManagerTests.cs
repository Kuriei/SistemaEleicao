
using SistemaEleicao.ConsoleApp;
using Xunit;

namespace SistemaEleicao.Tests;

public class EleicaoManagerTests
{
    [Fact]
    public void DeveCadastrarCandidatoComNumeroValido()
    {
        var eleicao = new EleicaoManager();

        bool resultado = eleicao.AdicionarCandidato("Ana", 10);

        Assert.True(resultado);
        Assert.Single(eleicao.Candidatos);
    }

    [Fact]
    public void NaoDeveCadastrarCandidatosComNumeroDuplicado()
    {
        var eleicao = new EleicaoManager();

        eleicao.AdicionarCandidato("Ana", 10);

        bool resultado = eleicao.AdicionarCandidato("Carlos", 10);

        Assert.False(resultado);
        Assert.Single(eleicao.Candidatos);
    }

    [Fact]
    public void NaoDeveCadastrarCandidatoComDadosInvalidos()
    {
        var eleicao = new EleicaoManager();

        Assert.False(eleicao.AdicionarCandidato("", 10));
        Assert.False(eleicao.AdicionarCandidato("Ana", 0));
    }

    [Fact]
    public void DeveRegistrarEleitor()
    {
        var eleicao = new EleicaoManager();

        bool resultado = eleicao.RegistrarEleitor("123456");

        Assert.True(resultado);
    }

    [Fact]
    public void NaoDeveCadastrarEleitorDuplicado()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarEleitor("123456");

        bool resultado = eleicao.RegistrarEleitor("123456");

        Assert.False(resultado);
    }

    [Fact]
    public void DeveRegistrarVotoParaCandidatoExistente()
    {
        var eleicao = new EleicaoManager();

        eleicao.AdicionarCandidato("Ana", 10);
        eleicao.RegistrarEleitor("123456");

        bool resultado = eleicao.Votar("123456", "10");

        Assert.True(resultado);
        Assert.Equal(1, eleicao.Candidatos[0].Votos);
    }

    [Fact]
    public void NaoDevePermitirQueEleitorVoteDuasVezes()
    {
        var eleicao = new EleicaoManager();

        eleicao.AdicionarCandidato("Ana", 10);
        eleicao.RegistrarEleitor("123456");

        eleicao.Votar("123456", "10");
        bool segundoVoto = eleicao.Votar("123456", "10");

        Assert.False(segundoVoto);
        Assert.Equal(1, eleicao.Candidatos[0].Votos);
    }

    [Fact]
    public void DeveContabilizarVotoEmCandidatoInexistenteComoNulo()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarEleitor("123456");

        bool resultado = eleicao.Votar("123456", "99");

        Assert.True(resultado);
        Assert.Equal(1, eleicao.TotalVotosNulos);
    }

    [Fact]
    public void DeveContabilizarVotoNulo()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarEleitor("123456");

        eleicao.Votar("123456", "NULO");

        Assert.Equal(1, eleicao.TotalVotosNulos);
    }

    [Fact]
    public void DeveContabilizarVotoBranco()
    {
        var eleicao = new EleicaoManager();

        eleicao.RegistrarEleitor("123456");

        eleicao.Votar("123456", "BRANCO");

        Assert.Equal(1, eleicao.TotalVotosBrancos);
    }

    [Fact]
    public void NaoDevePermitirVotoDeEleitorNaoCadastrado()
    {
        var eleicao = new EleicaoManager();

        bool resultado = eleicao.Votar("999999", "10");

        Assert.False(resultado);
    }

    [Fact]
    public void DeveIdentificarCandidatoVencedor()
    {
        var eleicao = new EleicaoManager();

        eleicao.AdicionarCandidato("Ana", 10);
        eleicao.AdicionarCandidato("Carlos", 20);

        eleicao.RegistrarEleitor("111");
        eleicao.RegistrarEleitor("222");
        eleicao.RegistrarEleitor("333");

        eleicao.Votar("111", "10");
        eleicao.Votar("222", "10");
        eleicao.Votar("333", "20");

        var vencedores = eleicao.ObterVencedores();

        Assert.Single(vencedores);
        Assert.Equal("Ana", vencedores[0].Nome);
    }

    [Fact]
    public void DeveIdentificarEmpateEntreCandidatos()
    {
        var eleicao = new EleicaoManager();

        eleicao.AdicionarCandidato("Ana", 10);
        eleicao.AdicionarCandidato("Carlos", 20);

        eleicao.RegistrarEleitor("111");
        eleicao.RegistrarEleitor("222");

        eleicao.Votar("111", "10");
        eleicao.Votar("222", "20");

        var vencedores = eleicao.ObterVencedores();

        Assert.Equal(2, vencedores.Count);
    }
}
