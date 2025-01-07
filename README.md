# Gerenciador de Tarefas

## Descrição
Este projeto é uma aplicação de gerenciamento de tarefas construída com .NET para o backend e Vue.js para o frontend, utilizando banco de dados SQLite.

## Pré-requisitos
- Node.js (versão 23.5.0)
- npm (versão 10.9.2)
- .NET SDK (versão 9.0)
- SQLite
- Vue.js (versão 3.5.13)
  
## Dependências
### Backend
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.AspNetCore.OpenApi
- Swashbuckle.AspNetCore
- System.ComponentModel.Annotations

### Frontend
- Axios
- FontAwesome
## Instalação

### Clonando o Repositório (Comandos Windows)
1. Clone o repositório:
    ```bash
    git clone https://github.com/jefisantos/TaskManager.git
    cd TaskManager
    ```

### Backend
1. Navegue até o diretório `TaskManagerAPI`:
    ```bash
    cd TaskManagerAPI
    ```

2. Instale as dependências do .NET:
    ```bash
    dotnet restore
    ```

3. Crie um arquivo `appsettings.json` na raiz do diretório `TaskManagerAPI` com o seguinte conteúdo:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=tasks.db"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```
4. Aplique as migrations para criar ou atualizar o banco de dados:
5. ```bash
   dotnet ef database update
   ```

7. Inicie o servidor backend:
    ```bash
    dotnet run
    ```

### Frontend
1. Navegue até o diretório `task-manager`:
    ```bash
    cd ../task-manager
    ```

2. Instale as dependências:
    ```bash
    npm install
    ```

3. Inicie o servidor frontend:
    ```bash
    npm run serve
    ```

4. Portas usadas no projeto:
    - Frontend: `http://localhost:8080`
    - Backend: `http://localhost:5004`

## Testando as APIs do Backend com Postman

As APIs do backend foram testadas utilizando o Postman. Abaixo estão alguns exemplos de como usá-las com JSON.

### Criar uma Tarefa (POST)
**Endpoint:** `http://localhost:5004/tasks`
**Exemplo de Requisição:**
```json
{
  "titulo": "Nova Tarefa",
  "descricao": "Descrição da tarefa",
  "status": "Pendente"
}
```
### Buscar Tarefas (GET)
**Endpoint:** `http://localhost:5004/tasks`

### Atualizar uma Tarefa (PUT)
**Endpoint:** `http://localhost:5004/tasks/{id}`
**Exemplo de Requisição:**
```json
{
  "id" : 1,  
  "titulo": " Tarefa Atualizada",
  "descricao": "Descrição atualizada",
  "status": "Concluida"
}
```
### Deletar uma Tarefa (DELETE)
**Endpoint:** `http://localhost:5004/tasks/{id}`




