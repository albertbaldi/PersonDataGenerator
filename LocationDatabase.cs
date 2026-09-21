namespace PersonDataGenerator;

public record CityLocation(
    string City,
    string State,
    string AreaCode,
    int MinCepPrefix,
    int MaxCepPrefix,
    string[] Neighborhoods,
    string[] Streets
);

public static class LocationDatabase
{
    public static readonly CityLocation[] Cities =
    [
        // SP
        new(
            "São Paulo", "SP", "11", 1000, 5999,
            ["Bela Vista", "Pinheiros", "Moema", "Vila Mariana", "Jardim Paulista", "Santana", "Tatuapé", "Ipiranga", "Perdizes"],
            ["Avenida Paulista", "Rua Augusta", "Rua Oscar Freire", "Rua Domingos de Morais", "Avenida Brigadeiro Faria Lima", "Rua Vergueiro", "Rua da Consolação", "Rua Teodoro Sampaio"]
        ),
        new(
            "Campinas", "SP", "19", 13000, 13139,
            ["Cambuí", "Barão Geraldo", "Taquaral", "Centro", "Botafogo", "Nova Campinas", "Castelo"],
            ["Avenida Francisco Glicério", "Rua Barão de Jaguara", "Avenida Brasil", "Avenida Orosimbo Maia", "Rua Coronel Quirino"]
        ),
        new(
            "Santos", "SP", "13", 11000, 11099,
            ["Gonzaga", "Boqueirão", "Ponta da Praia", "Embaré", "Aparecida", "Centro"],
            ["Avenida Ana Costa", "Avenida Vicente de Carvalho", "Avenida Bartolomeu de Gusmão", "Rua Tolentino Filgueiras", "Rua Galeão Carvalhal"]
        ),
        new(
            "Ribeirão Preto", "SP", "16", 14000, 14099,
            ["Jardim Sumaré", "Vila Tibério", "Centro", "Jardim Botânico", "Campos Elíseos", "Ipiranga"],
            ["Avenida Nove de Julho", "Rua General Osório", "Avenida Presidente Vargas", "Avenida Independência"]
        ),
        // RJ
        new(
            "Rio de Janeiro", "RJ", "21", 20000, 23799,
            ["Copacabana", "Ipanema", "Leblon", "Botafogo", "Flamengo", "Tijuca", "Barra da Tijuca", "Laranjeiras", "Méier"],
            ["Avenida Atlântica", "Rua Visconde de Pirajá", "Rua Barata Ribeiro", "Avenida Vieira Souto", "Rua das Laranjeiras", "Rua Conde de Bonfim", "Avenida das Américas"]
        ),
        new(
            "Niterói", "RJ", "21", 24000, 24399,
            ["Icaraí", "Ingá", "Santa Rosa", "Centro", "São Francisco", "Charitas"],
            ["Rua Coronel Moreira César", "Praia de Icaraí", "Rua Gavião Peixoto", "Avenida Roberto Silveira"]
        ),
        // MG
        new(
            "Belo Horizonte", "MG", "31", 30000, 31999,
            ["Savassi", "Funcionários", "Lourdes", "Sion", "Anchieta", "Serra", "Padre Eustáquio", "Buritis", "Centro"],
            ["Avenida Afonso Pena", "Avenida do Contorno", "Rua da Bahia", "Avenida Cristóvão Colombo", "Avenida Amazonas", "Rua Fernandes Tourinho"]
        ),
        new(
            "Betim", "MG", "31", 32500, 32699,
            ["Jardim Casa Branca", "Centro", "Angola", "Brasiléia", "Ingá", "Filadélfia", "Betânia"],
            ["Rua da Colômbia", "Avenida Amazonas", "Avenida Edméia Mattos Lazzarotti", "Rua Rio de Janeiro", "Rua Inspetor Jaime Caldeira"]
        ),
        new(
            "Uberlândia", "MG", "34", 38400, 38419,
            ["Centro", "Santa Mônica", "Tibery", "Martins", "Fundinho", "Saraiva"],
            ["Avenida Rondon Pacheco", "Avenida Afonso Pena", "Avenida João Naves de Ávila", "Avenida Floriano Peixoto"]
        ),
        // PR
        new(
            "Curitiba", "PR", "41", 80000, 82999,
            ["Batel", "Bigorrilho", "Água Verde", "Centro", "Cabral", "Juvevê", "Mercês", "Santa Felicidade"],
            ["Avenida Sete de Setembro", "Rua Visconde de Nácar", "Rua XV de Novembro", "Avenida Batel", "Rua Marechal Deodoro"]
        ),
        new(
            "Londrina", "PR", "43", 86000, 86099,
            ["Gleba Palhano", "Centro", "Jardim Shangri-Lá", "Bandeirantes", "Aeroporto"],
            ["Avenida Higienópolis", "Rua Sergipe", "Avenida Madre Leônia Milito", "Avenida Duque de Caxias"]
        ),
        // RS
        new(
            "Porto Alegre", "RS", "51", 90000, 91999,
            ["Moinhos de Vento", "Bela Vista", "Menino Deus", "Petrópolis", "Cidade Baixa", "Bom Fim", "Centro Histórico"],
            ["Rua dos Andradas", "Avenida Padre Cacique", "Avenida Goethe", "Rua Padre Chagas", "Avenida Ipiranga"]
        ),
        new(
            "Caxias do Sul", "RS", "54", 95000, 95119,
            ["São Pelegrino", "Lourdes", "Panazzolo", "Exposição", "Centro", "Rio Branco"],
            ["Avenida Júlio de Castilhos", "Rua Sinimbu", "Rua Pinheiro Machado", "Rua Alfredo Chaves"]
        ),
        // SC
        new(
            "Florianópolis", "SC", "48", 88000, 88099,
            ["Centro", "Trindade", "Agronômica", "Itacorubi", "Campeche", "Jurerê Internacional", "Lagoa da Conceição"],
            ["Avenida Beira Mar Norte", "Rua Bocaiúva", "Rua Felipe Schmidt", "Avenida Mauro Ramos", "Rua Lauro Linhares"]
        ),
        new(
            "Joinville", "SC", "47", 89200, 89239,
            ["América", "Atiradores", "Centro", "Glória", "Saguaçu", "Anita Garibaldi"],
            ["Rua XV de Novembro", "Rua Visconde de Taunay", "Rua Blumenau", "Rua Ottokar Doerffel"]
        ),
        // BA
        new(
            "Salvador", "BA", "71", 40000, 42599,
            ["Pituba", "Barra", "Graça", "Rio Vermelho", "Ondina", "Caminho das Árvores", "Pelourinho", "Brotas"],
            ["Avenida Oceânica", "Avenida Manoel Dias da Silva", "Avenida Sete de Setembro", "Avenida Tancredo Neves", "Rua da Paciência"]
        ),
        // PE
        new(
            "Recife", "PE", "81", 50000, 52999,
            ["Boa Viagem", "Espinheiro", "Graças", "Casa Forte", "Madalena", "Parnamirim", "Recife Antigo"],
            ["Avenida Boa Viagem", "Avenida Conselheiro Aguiar", "Rua da Aurora", "Avenida Rui Barbosa", "Rua das Pernambucanas"]
        ),
        // CE
        new(
            "Fortaleza", "CE", "85", 60000, 60999,
            ["Meireles", "Aldeota", "Praia de Iracema", "Cocó", "Varjota", "Dionísio Torres", "Papicu"],
            ["Avenida Beira Mar", "Avenida Santos Dumont", "Avenida Dom Luís", "Rua Barão de Studart", "Avenida Abolição"]
        ),
        // DF
        new(
            "Brasília", "DF", "61", 70000, 72799,
            ["Asa Sul", "Asa Norte", "Sudoeste", "Noroeste", "Lago Sul", "Lago Norte", "Águas Claras"],
            ["SQS 308", "SQN 105", "Setor Comercial Sul", "Setor de Clubes Esportivos Sul", "Avenida das Castanheiras", "W3 Sul"]
        ),
        // GO
        new(
            "Goiânia", "GO", "62", 74000, 74899,
            ["Setor Bueno", "Setor Marista", "Setor Oeste", "Jardim Goiás", "Centro", "Setor Sul"],
            ["Avenida 85", "Avenida T-9", "Avenida 136", "Avenida Mutirão", "Avenida Portugal"]
        )
    ];
}
