# PersonDataGenerator (`gen-person`)

Ferramenta CLI (.NET Global Tool) cross-platform para geração rápida de payloads JSON de dados de pessoas com consistência cadastral brasileira (CPF válido, endereço, CEP, DDD e características faciais).

## Instalação Global

### No macOS / Linux / Windows
```bash
dotnet pack -c Release
dotnet tool install --global --add-source ./bin/Release Albert.PersonDataGenerator
```
> Caso precise atualizar após alterações:
```bash
dotnet tool update --global --add-source ./bin/Release Albert.PersonDataGenerator
```

## Como Usar

1. **Exibir no terminal:**
```bash
gen-person
```

2. **Copiar direto para o Clipboard:**
- **macOS:**
  ```bash
  gen-person | pbcopy
  ```
- **Windows (PowerShell):**
  ```powershell
  gen-person | Set-Clipboard
  # ou
  gen-person | clip
  ```

3. **JSON Minificado (1 linha):**
```bash
gen-person -m
```

4. **Gerar múltiplos registros (Array JSON):**
```bash
gen-person -n 5
```

5. **Salvar em arquivo:**
```bash
gen-person > pessoa.json
```
