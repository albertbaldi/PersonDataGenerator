using System.Text.Json.Serialization;

namespace PersonDataGenerator;

public record FacialFeatures(
    [property: JsonPropertyName("cor_dos_olhos")] string CorDosOlhos,
    [property: JsonPropertyName("cor_do_cabelo")] string CorDoCabelo,
    [property: JsonPropertyName("estilo_cabelo")] string EstiloCabelo,
    [property: JsonPropertyName("barba_bigode")] string BarbaBigode,
    [property: JsonPropertyName("outros")] string Outros
);

public record PersonPayload(
    [property: JsonPropertyName("nome")] string Nome,
    [property: JsonPropertyName("idade")] int Idade,
    [property: JsonPropertyName("cpf")] string Cpf,
    [property: JsonPropertyName("rg")] string Rg,
    [property: JsonPropertyName("data_nasc")] string DataNasc,
    [property: JsonPropertyName("sexo")] string Sexo,
    [property: JsonPropertyName("signo")] string Signo,
    [property: JsonPropertyName("mae")] string Mae,
    [property: JsonPropertyName("pai")] string Pai,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("senha")] string Senha,
    [property: JsonPropertyName("cep")] string Cep,
    [property: JsonPropertyName("endereco")] string Endereco,
    [property: JsonPropertyName("numero")] int Numero,
    [property: JsonPropertyName("bairro")] string Bairro,
    [property: JsonPropertyName("cidade")] string Cidade,
    [property: JsonPropertyName("estado")] string Estado,
    [property: JsonPropertyName("telefone_fixo")] string TelefoneFixo,
    [property: JsonPropertyName("celular")] string Celular,
    [property: JsonPropertyName("altura")] string Altura,
    [property: JsonPropertyName("peso")] int Peso,
    [property: JsonPropertyName("tipo_sanguineo")] string TipoSanguineo,
    [property: JsonPropertyName("cor")] string Cor,
    [property: JsonPropertyName("etnia_aparencia")] string EtniaAparencia,
    [property: JsonPropertyName("caracteristicas_faciais")] FacialFeatures CaracteristicasFaciais
);
