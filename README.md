# 🌱 EcoDenuncia API

A **EcoDenuncia** é uma API RESTful desenvolvida para registrar e acompanhar denúncias ambientais. A aplicação organiza usuários, denúncias, localizações e órgãos públicos de forma estruturada, facilitando o monitoramento e fiscalização dos problemas ambientais reportados.

---

## 🔗 Endpoints Disponíveis

### 👤 Usuário
| Verbo | Rota                | Descrição                                |
|-------|---------------------|------------------------------------------|
| GET   | `/api/Usuario`      | Lista todos os usuários                  |
| POST  | `/api/Usuario`      | Cadastra um novo usuário                 |
| GET   | `/api/Usuario/{id}` | Detalha um usuário por ID                |
| PUT   | `/api/Usuario/{id}` | Atualiza dados de um usuário existente   |
| DELETE| `/api/Usuario/{id}` | Remove um usuário do sistema             |

### 🏛️ Órgão Público
| Verbo | Rota                     | Descrição                                      |
|-------|--------------------------|------------------------------------------------|
| GET   | `/api/OrgaoPublico`      | Lista todos os órgãos públicos                 |
| POST  | `/api/OrgaoPublico`      | Cadastra um novo órgão público                 |
| GET   | `/api/OrgaoPublico/{id}` | Detalha um órgão público por ID                |
| PUT   | `/api/OrgaoPublico/{id}` | Atualiza dados de um órgão público existente   |
| DELETE| `/api/OrgaoPublico/{id}` | Remove um órgão público                        |

### 📍 Localização
| Verbo | Rota                     | Descrição                                    |
|-------|--------------------------|----------------------------------------------|
| GET   | `/api/Localizacao`       | Lista todas as localizações                  |
| POST  | `/api/Localizacao`       | Registra uma nova localização                |
| GET   | `/api/Localizacao/{id}`  | Detalha uma localização por ID               |
| PUT   | `/api/Localizacao/{id}` | Atualiza dados de uma localização existente   |
| DELETE| `/api/Localizacao/{id}` | Remove uma localização                        |

### 🗺️ Estados
| Verbo | Rota                     | Descrição                               |
|-------|--------------------------|-----------------------------------------|
| GET   | `/api/Estado`            | Lista todos os estados                  |
| POST  | `/api/Estado`            | Registra um novo estado                 |
| GET   | `/api/Estado/{id}`       | Detalha um estado por ID                |
| PUT   | `/api/Estado/{id}`       | Atualiza dados de um estado existente   |
| DELETE| `/api/Estado/{id}`       | Remove um estado                        |

### 🧾 Denúncia
| Verbo | Rota                | Descrição                                   |
|-------|---------------------|---------------------------------------------|
| GET   | `/api/Denuncia`     | Lista todas as denúncias                    |
| POST  | `/api/Denuncia`     | Registra uma nova denúncia                  |
| GET   | `/api/Denuncia/{id}`| Detalha uma denúncia por ID                 |
| PUT   | `/api/Denuncia/{id}`| Atualiza dados de uma denúncia existente    |
| DELETE| `/api/Denuncia/{id}`| Remove uma denúncia                         |

### 🏙️ Cidades
| Verbo | Rota                | Descrição                                 |
|-------|---------------------|-------------------------------------------|
| GET   | `/api/Cidade`       | Lista todas as cidades                    |
| POST  | `/api/Cidade`       | Registra uma nova cidade                  |
| GET   | `/api/Cidade/{id}`  | Detalha uma cidade por ID                 |
| PUT   | `/api/Cidade/{id}`  | Atualiza dados de uma cidade existente    |
| DELETE| `/api/Cidade/{id}`  | Remove uma cidade                         |

### 🏘️ Bairros
| Verbo | Rota                | Descrição                                |
|-------|---------------------|------------------------------------------|
| GET   | `/api/Bairro`       | Lista todos os bairros                   |
| POST  | `/api/Bairro`       | Registra um novo bairro                  |
| GET   | `/api/Bairro/{id}`  | Detalha um bairro por ID                 |
| PUT   | `/api/Bairro/{id}`  | Atualiza dados de um bairro existente    |
| DELETE| `/api/Bairro/{id}`  | Remove um bairro                         |

### 📊 Acompanhamento de Denúncia
| Verbo | Rota                                 | Descrição                                     |
|-------|--------------------------------------|-----------------------------------------------|
| GET   | `/api/AcompanhamentoDenuncia`        | Lista todos os acompanhamentos                |
| POST  | `/api/AcompanhamentoDenuncia`        | Cria novo acompanhamento                      | 
| GET   | `/api/AcompanhamentoDenuncia/{id}`   | Detalha um acompanhamento por ID              |
| PUT   | `/api/AcompanhamentoDenuncia/{id}`   | Atualiza dados de um acompanhamento por ID    |
| DELETE| `/api/AcompanhamentoDenuncia/{id}`   | Remove um acompanhamento                      |

---

## 🛠 Tecnologias Utilizadas

- ASP.NET Core 8 Web API
- Entity Framework Core
- Banco de Dados Oracle
- Swagger (OpenAPI)
- Serialização JSON com ReferenceHandler.IgnoreCycles

---

## 🧪 Exemplos de Testes

### 🔹 Criar Usuário

```json
POST /api/Usuario
{
  "nome": "João Silva",
  "email": "joao@email.com",
  "senha": "123456",
  "tipoUsuario": "USER"
}
```

### 🔹 Criar Órgão Público

```json
POST /api/OrgaoPublico
{
  "nome": "Secretaria do Meio Ambiente MG",
  "areaAtuacao": "Ambiental"
}
```

### 🔹 Criar Localização

```json
POST /api/Localizacao
{
  "logradouro": "Av Paulista",
  "numero": "1106",
  "complemento": "5º andar",
  "cep": "01311-000",
  "idBairro": "GUID_DO_BAIRRO"
}
```

### 🔹 Criar Estado

```json
POST /api/Estado
{
  "nome": "Santa Catarina",
  "uf": "SC"
}
```

### 🔹 Criar Denúncia

```json
POST /api/Denuncia
{
  "idUsuario": "GUID_DO_USUARIO",
  "idLocalizacao": "GUID_DA_LOCALIZACAO",
  "idOrgaoPublico": "GUID_DO_ORGAO",
  "dataHora": "2025-06-02T16:03:04.057Z",
  "descricao": "Descarte de resíduos tóxicos próximo ao rio."
}
```

### 🔹 Criar Cidade

```json
POST /api/Cidade
{
  "nome": "Campinas",
  "idEstado": "GUID_DO_ESTADO"
}
```

### 🔹 Criar Bairro

```json
POST /api/Bairro
{
  "nome": "Taquaral",
  "idCidade": "GUID_DA_CIDADE"
}
```

### 🔹 Criar Acompanhamento

```json
POST /api/acompanhamentodenuncia
{
  "status": "EmAndamento",
  "dataAtualizacao": "2025-06-02T16:40:00.000Z",
  "observacao": "A prefeitura iniciou a limpeza.",
  "denunciaId": "GUID_DA_DENUNCIA"
}
```

---

## 🚀 Instruções de Execução

1. Clone o repositório:
   ```bash
   git clone 
   ```

2. Configure a string de conexão Oracle no `appsettings.json` e, ou no `appsettings.Development.json` :
   ```json
   "ConnectionStrings": {
    "Oracle": "Data Source=oracle.fiap.com.br:1521/orcl;User ID=RMXXXXXX;Password=XXXXXX;"
   }
   ```

3. Aplique as migrations:
   ```bash
   dotnet ef database update
   ```

4. Execute o projeto:
   ```bash
   dotnet run
   ```

5. Acesse a documentação:
   ```
   http://localhost:{porta}/swagger/index.html
   ```

---

## 🧩 Diagramas do Projeto

O projeto está respaldado por uma estrutura bem definida, com diagramas que facilitam a compreensão:

- 🗺️ **Diagrama Entidade-Relacionamento (DER)**:
        - Representa as relações entre:
           `Denuncia`, `Usuario`, `Localizacao`, `OrgaoPublico`, `Acompanhamento`, `Bairro`, `Cidade` e `Estado`.
        - 📦 Entidades e Relacionamentos
              - 🧾 Denuncia:
                    IdUsuario → 🔗 Usuario.IdUsuario
                    IdLocalizacao → 🔗 Localizacao.IdLocalizacao
                    IdOrgaoPublico → 🔗 OrgaoPublico.IdOrgaoPublico
              - 📍 Localizacao:
                    IdBairro → 🔗 Bairro.IdBairro
              - 🏘️ Bairro:
                    IdCidade → 🔗 Cidade.IdCidade
              - 🏙️ Cidade:
                    IdEstado → 🔗 Estado.IdEstado

###🧩 Relações:

| Entidade     | Relacionamento com           |   Tipo    |
|--------------|------------------------------|-----------|
| Denuncia     |      Usuario                 |    N:1    |
| Denuncia     |      Localizacao             |    N:1    |
| Denuncia     |      OrgaoPublico            |    N:1    |
| Denuncia     |      AcompanhamentoDenuncia  |    1:N    |
| Localizacao  |      Bairro                  |    N:1    |
| Bairro       |      Cidade                  |    N:1    |
| Cidade       |      Estado                  |    N:1    |


- 🧱 **Arquitetura**:
- 📁 Controllers
  Responsabilidade:
  - Expor endpoints da API ([HttpGet], [HttpPost], etc.).
  - Receber e responder requisições HTTP.
  - Chamar métodos do domínio ou persistência para retornar/alterar dados.
    Exemplo: DenunciaController.cs → controla as rotas /api/denuncia.

---

## 👥 Integrantes

| Nome             | RM       |
|------------------|----------|
| Larissa Muniz    | RM557197 |
| João V. Michaeli | RM555678 |
| Henrique Garcia  | RM558062 |

---

> Projeto acadêmico desenvolvido na FIAP para a Global Solution 2025 — 1º Semestre
