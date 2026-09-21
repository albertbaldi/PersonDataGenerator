using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Json;
using Bogus;
using Bogus.Extensions.Brazil;

namespace PersonDataGenerator;

public static class PersonGenerator
{
    private static readonly string[] BloodTypes = ["A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"];
    private static readonly string[] Colors =
    [
        "azul", "vermelho", "verde", "amarelo", "preto", "branco", "roxo", 
        "laranja", "cinza", "rosa", "marrom", "violeta"
    ];

    private static readonly string[] Ethnicities =
    [
        "caucasiana", "afro-descendente", "asiática", "latina", "indígena", "outra"
    ];

    private static readonly string[] EyeColors = ["castanhos", "castanhos escuros", "pretos", "verdes", "azuis", "avelã"];
    private static readonly string[] HairColors = ["preto", "castanho escuro", "castanho claro", "loiro", "grisalho", "ruivo"];
    private static readonly string[] HairStylesFemale =
    [
        "longo, liso, solto", "médio, ondulado com franja", "curto, cacheado, volumoso", 
        "longo, crespo, tranças", "médio, liso, repartido ao meio", "curto, corte pixie", 
        "longo, cacheado com mechas"
    ];
    private static readonly string[] HairStylesMale =
    [
        "curto, liso, repartido de lado", "curto, degradê nas laterais", "médio, ondulado, penteado para trás", 
        "curto, crespo, estilo fade", "raspado", "médio, liso e desfiado", "curto, cacheado volumoso"
    ];
    private static readonly string[] FacialBeardOptions =
    [
        "sem barba", "barba por fazer", "barba cheia bem aparada", "cavanhaque", "bigode fino", "barba rala"
    ];
    private static readonly string[] OtherFacialFeatures =
    [
        "marcas de expressão leves", "sardas", "óculos de grau", "nenhum detalhe adicional", 
        "pequena cicatriz na sobrancelha", "sardas sutis e covinhas", "óculos de armação fina"
    ];

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public static PersonPayload Generate()
    {
        var faker = new Faker("pt_BR");
        var gender = faker.PickRandom<Bogus.DataSets.Name.Gender>();
        var isFemale = gender == Bogus.DataSets.Name.Gender.Female;

        var birthDate = faker.Date.Between(DateTime.Today.AddYears(-80), DateTime.Today.AddYears(-18));
        var age = CalculateAge(birthDate);

        var firstName = faker.Name.FirstName(gender);
        var middleName = faker.Name.FirstName();
        var lastName = faker.Name.LastName();
        var fullName = $"{firstName} {middleName} {lastName}";

        var mother = $"{faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female)} {faker.Name.LastName()} {lastName}";
        var father = $"{faker.Name.FirstName(Bogus.DataSets.Name.Gender.Male)} {faker.Name.LastName()} {lastName}";

        var location = faker.PickRandom(LocationDatabase.Cities);
        var state = location.State;
        var city = location.City;
        var street = faker.PickRandom(location.Streets);
        var neighborhood = faker.PickRandom(location.Neighborhoods);
        var number = faker.Random.Number(10, 1999);

        var cepPrefix = faker.Random.Number(location.MinCepPrefix, location.MaxCepPrefix);
        var cepSuffix = faker.Random.Number(0, 999);
        var cep = $"{cepPrefix:D5}-{cepSuffix:D3}";

        var areaCode = location.AreaCode;
        var landline = $"({areaCode}) {faker.Random.Number(2000, 3999)}-{faker.Random.Number(1000, 9999)}";
        var mobile = $"({areaCode}) 9{faker.Random.Number(8000, 9999)}-{faker.Random.Number(1000, 9999)}";

        var height = (faker.Random.Double(1.50, 1.98)).ToString("0.00", CultureInfo.InvariantCulture).Replace('.', ',');
        var weight = faker.Random.Number(50, 110);

        var ethnicity = faker.PickRandom(Ethnicities);
        var eyeColor = faker.PickRandom(EyeColors);
        var hairColor = faker.PickRandom(HairColors);
        var hairStyle = isFemale ? faker.PickRandom(HairStylesFemale) : faker.PickRandom(HairStylesMale);
        var facialHair = isFemale ? "sem barba" : faker.PickRandom(FacialBeardOptions);
        var otherDetails = faker.PickRandom(OtherFacialFeatures);

        var facialFeatures = new FacialFeatures(
            CorDosOlhos: eyeColor,
            CorDoCabelo: hairColor,
            EstiloCabelo: hairStyle,
            BarbaBigode: facialHair,
            Outros: otherDetails
        );

        return new PersonPayload(
            Nome: fullName,
            Idade: age,
            Cpf: faker.Person.Cpf(true),
            Rg: GenerateRg(faker),
            DataNasc: birthDate.ToString("dd/MM/yyyy"),
            Sexo: isFemale ? "Feminino" : "Masculino",
            Signo: GetZodiacSign(birthDate),
            Mae: mother,
            Pai: father,
            Email: faker.Internet.Email(firstName.ToLowerInvariant(), lastName.ToLowerInvariant()),
            Senha: faker.Internet.Password(10),
            Cep: cep,
            Endereco: street,
            Numero: number,
            Bairro: neighborhood,
            Cidade: city,
            Estado: state,
            TelefoneFixo: landline,
            Celular: mobile,
            Altura: height,
            Peso: weight,
            TipoSanguineo: faker.PickRandom(BloodTypes),
            Cor: faker.PickRandom(Colors),
            EtniaAparencia: ethnicity,
            CaracteristicasFaciais: facialFeatures
        );
    }

    public static string ToJson(PersonPayload payload) => JsonSerializer.Serialize(payload, JsonOptions);

    private static int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;
        if (birthDate.Date > today.AddYears(-age)) age--;
        return age;
    }

    private static string GenerateRg(Faker faker)
    {
        return $"{faker.Random.Number(10, 99)}.{faker.Random.Number(100, 999)}.{faker.Random.Number(100, 999)}-{faker.Random.Number(0, 9)}";
    }

    private static string GetZodiacSign(DateTime date)
    {
        var (month, day) = (date.Month, date.Day);
        return (month, day) switch
        {
            (1, <= 20) => "Capricórnio",
            (1, >= 21) => "Aquário",
            (2, <= 18) => "Aquário",
            (2, >= 19) => "Peixes",
            (3, <= 20) => "Peixes",
            (3, >= 21) => "Áries",
            (4, <= 20) => "Áries",
            (4, >= 21) => "Touro",
            (5, <= 20) => "Touro",
            (5, >= 21) => "Gêmeos",
            (6, <= 20) => "Gêmeos",
            (6, >= 21) => "Câncer",
            (7, <= 22) => "Câncer",
            (7, >= 23) => "Leão",
            (8, <= 22) => "Leão",
            (8, >= 23) => "Virgem",
            (9, <= 22) => "Virgem",
            (9, >= 23) => "Libra",
            (10, <= 22) => "Libra",
            (10, >= 23) => "Escorpião",
            (11, <= 21) => "Escorpião",
            (11, >= 22) => "Sagitário",
            (12, <= 21) => "Sagitário",
            _ => "Capricórnio"
        };
    }
}
