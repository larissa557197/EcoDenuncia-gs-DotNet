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
| Verbo | Rota                     | Descrição                              |
|-------|--------------------------|----------------------------------------|
| GET   | `/api/OrgaoPublico`      | Lista todos os órgãos públicos         |
| GET   | `/api/OrgaoPublico/{id}` | Detalha um órgão público por ID        |
| POST  | `/api/OrgaoPublico`      | Cadastra um novo órgão público         |
| DELETE| `/api/OrgaoPublico/{id}` | Remove um órgão público                |

### 📍 Localização
| Verbo | Rota                 | Descrição                           |
|-------|----------------------|-------------------------------------|
| GET   | `/api/localizacao`   | Lista todas as localizações         |
| POST  | `/api/localizacao`   | Registra uma nova localização       |

### 🧾 Denúncia
| Verbo | Rota                | Descrição                               |
|-------|---------------------|-----------------------------------------|
| GET   | `/api/denuncia`     | Lista todas as denúncias                |
| GET   | `/api/denuncia/{id}`| Detalha uma denúncia por ID             |
| POST  | `/api/denuncia`     | Registra uma nova denúncia              |
| PUT   | `/api/denuncia/{id}`| Atualiza dados de uma denúncia          |
| DELETE| `/api/denuncia/{id}`| Remove uma denúncia                     |

### 📊 Acompanhamento de Denúncia
| Verbo | Rota                                 | Descrição                           |
|-------|--------------------------------------|-------------------------------------|
| GET   | `/api/acompanhamentodenuncia`        | Lista todos os acompanhamentos      |
| GET   | `/api/acompanhamentodenuncia/{id}`   | Detalha um acompanhamento por ID    |
| POST  | `/api/acompanhamentodenuncia`        | Cria novo acompanhamento            |
| DELETE| `/api/acompanhamentodenuncia/{id}`   | Remove um acompanhamento            |

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
POST /api/usuario
{
  "nome": "João Silva",
  "email": "joao@email.com",
  "senha": "123456",
  "tipoUsuario": "USER"
}
```

### 🔹 Criar Denúncia

```json
POST /api/denuncia
{
  "idUsuario": "GUID_DO_USUARIO",
  "idLocalizacao": "GUID_DA_LOCALIZACAO",
  "idOrgaoPublico": "GUID_DO_ORGAO",
  "dataHora": "2025-06-02T16:03:04.057Z",
  "descricao": "Descarte de resíduos tóxicos próximo ao rio."
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
   git clone https://github.com/seu-usuario/EcoDenuncia.git](https://github.com/larissa557197/EcoDenuncia-gs-DotNet.git
   ```

2. Configure a string de conexão Oracle no `appsettings.json`:
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
   https://localhost:{porta}/swagger
   ```

---

## 🧩 Diagramas do Projeto

O projeto está respaldado por uma estrutura bem definida, com diagramas que facilitam a compreensão:

- 🗺️ **Diagrama Entidade-Relacionamento (DER)**:
        - Representa as relações entre:
           `Denuncia`, `Usuario`, `Localizacao`, `OrgaoPublico`, `Acompanhamento`, `Bairro`, `Cidade` e `Estado`.

- 🎯 **Diagrama de Casos de Uso**:
        Mostra os fluxos principais de uso do sistema (registro de denúncias, criação de usuários, acompanhamento etc.).

- 🧱 **Camadas da Arquitetura**:
  - `Domain` – entidades e regras de negócio
  - `DTOs` – objetos de transporte
  - `Controllers` – endpoints da API
  - `Infrastructure` – mapeamento ORM e contexto

---

## 👥 Integrantes

| Nome             | RM       |
|------------------|----------|
| Larissa Muniz    | RM557197 |
| João V. Michaeli | RM555678 |
| Henrique Garcia  | RM558062 |

---

> Projeto acadêmico desenvolvido na FIAP para a Global Solution 2025 — 1º Semestre
