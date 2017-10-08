# labs

Dois projetos nessa branch:<br><br>

1 - API<br>
  Responsavel pela manipulacao dos dados de empregados (Employee):<BR>
  Lista (paginado), insere e exclui.<br><br>
  
  Solution LlabsAPI.sln<br>
  Está configurado para rodar na porta 8000 (http://localhost:8000/)
   
2 - MVC<br>
  Faz o uso da API para trabalhar com os dados.<br><br>
  
  Solution LlabsMVC.sln<br>
  Se conecta à API pela porta 8000, a configuração da conexão é feita no arquivo web.config<br><br>
  
```c#
   <!-- Configuration for URL API -->
    <add key="urlAPI" value ="http://localhost:8000/"/>
``` 
  Para usar:<br>
  Abra a Solution LlabAPI<br>
  Rode em modo debug. Ele irá iniciar uma api na porta 8000 local.<br>
  Abra a Solution LlabMVC<BR>
  Rode a Solution. Essa aplicacao MVC fará o uso da API.<br><br>
  
3 - Teste Unitário<br>
  Existe um terceiro projeto, UnitTestProject (encontra-se na solution da API), que faz um teste basico nos tres metodos principais da API (insert, delete, list)
  Para roda-lo é necessario alterar a string de conexao da API, deverá colocar o caminho fisico do banco de dados (como é um projeto totalmente local, o Banco de dados é um arquivo MDF local. Para configurar, altere a linha 16 da classe RepositoryEmployee: <br>
  ```c#
  ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\\LlabEmployee.mdf; Integrated Security = True";
  ``` 
  

