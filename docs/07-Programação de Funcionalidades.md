# Programação de Funcionalidades

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="4-Metodologia.md"> Metodologia</a>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>, <a href="5-Arquitetura da Solução.md"> Arquitetura da Solução</a>

|ID    | Descrição do Requisito  | Artefatos produzidos | Aluno(a) responsável |
|------|-----------------------------------------|----|----|
|RF-001| O usuário deve poder se cadastrar como “Aluno” ou “Instrutor”. | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Views\Usuarios\Create.cshtml</br> Validation\SenhaComplexaAttribute.cs | Symon |
|RF-002| O usuário deve poder se autenticar (login). | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Views\Usuarios\Login.cshtml</br> Validation\SenhaComplexaAttribute.cs | Symon |
|RF-003| O usuário deve poder recuperar sua senha.  | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Models\Views\SolicitarRedefinicaoSenhaViewModel.cs</br> Views\Usuarios\SolicitarRedefinicaoSenha.cshtml</br> Models\Views\RedefinirSenhaViewModel.cs</br> Views\Usuarios\RedefinirSenha.cshtml</br> Validation\SenhaComplexaAttribute.cs  | Symon  |
|RF-004| O usuário deve poder editar informações pessoais.  | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Views\Usuarios\Edit.cshtml</br> Views\Usuarios\Details.cshtml</br> Authorization\RequisitoDeveSerDonoDaConta.cs</br> Authorization\ManipuladorAutorizacaoDonoDaConta.cs | Symon |
|RF-005| O usuário deve poder alterar senha.  | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Models\Views\AlterarSenhaViewModel.cs</br> Views\Usuarios\AlterarSenha.cshtml</br> Views\Usuarios\Details.cshtml</br> Validation\SenhaComplexaAttribute.cs</br> Authorization\RequisitoDeveSerDonoDaConta.cs</br> Authorization\ManipuladorAutorizacaoDonoDaConta.cs | Symon |
|RF-006| O usuário deve poder excluir sua conta.  | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Views\Usuarios\Details.cshtml</br> Views\Usuarios\Delete.cshtml</br> Authorization\RequisitoDeveSerDonoDaConta.cs</br> Authorization\ManipuladorAutorizacaoDonoDaConta.cs | Symon |
|RF-007| O usuário deve poder sair da conta. (Logout)  | Models\Usuario.cs</br> Controllers\UsuariosController.cs</br> Views\Usuarios\Details.cshtml</br> Views\Shared\_Layout.cshtml  | Symon |
|RF-008| O instrutor deve poder criar curso.	 | Models\Curso.cs</br> Controllers\CursosController.cs</br> Views\Cursos\Create.cshtml</br> | José Ricardo |
|RF-009| O instrutor deve poder editar curso.	 | Models\Curso.cs</br> Controllers\CursosController.cs</br> Views\Cursos\Edit.cshtml</br> | José Ricardo |
|RF-010| O instrutor deve poder visualizar seus cursos criados.	 | Models\Curso.cs</br> Controllers\CursosController.cs</br> Views\Cursos\Gerenciar.cshtml</br> | José Ricardo |
|RF-011| O instrutor deve poder excluir curso.	 | Models\Curso.cs</br> Controllers\CursosController.cs</br> Views\Cursos\Delete.cshtml</br> | José Ricardo |
|RF-012| O instrutor deve poder criar aula do curso.  | Models\Aula.cs</br> Controllers\AulasController.cs </br> Views\Aulas\Create.cshtml    | Kauê/Symon |
|RF-013| O instrutor deve poder editar aula do curso.  | Models\Aula.cs</br> Controllers\AulasController.cs </br> Views\Aulas\Edit.cshtml | Kauê/Symon |
|RF-014| O instrutor deve poder visualizar as aulas do curso.  | Models\Aula.cs</br> Controllers\AulasController.cs </br> Views\Aulas\Index.cshtml | Kauê/Symon |
|RF-015| O instrutor deve poder excluir aula do curso.  | Models\Aula.cs</br> Controllers\AulasController.cs </br> Views\Aulas\Delete.cshtml | Kauê/Symon |
|RF-016| O instrutor deve poder visualizar um relatório de progresso dos inscritos.  | Models\Views\RelatorioProgressoViewModel.cs </br>  Controllers\RelatoriosController.cs </br> Views\Relatorios\Index.cshtml </br> Views\Relatorios\ProgressoUsuarios.cshtml  | Luiz/Symon |
|RF-017| O instrutor deve poder visualizar um relatório com perguntas não respondidas.  | Models\Views\RelatorioPerguntasSemRespostaViewModel.cs </br>  Controllers\RelatoriosController.cs </br> Views\Relatorios\Index.cshtml </br> Views\Relatorios\PerguntasSemRespostas.cshtml | Luiz/Symon |
|RF-018| O aluno deve poder visualizar todos os cursos ativos.	 | Models\Curso.cs</br> Controllers\CursosController.cs</br> Views\Cursos\CursosDisponiveis.cshtml</br> | José Ricardo |
|RF-019| O aluno deve poder se inscrever no curso. | Models\Matricula.cs </br> Controllers\MatriculasController.cs </br> Views\Cursos\Details.cs  | Lucas/Symon |
|RF-020| O aluno deve poder visualizar o painel “Meus Cursos” com seus cursos inscritos.	 | Models\Curso.cs</br> Controllers\CursosController.cs</br> Views\Cursos\MinhasInscricoes.cshtml</br> | José Ricardo/ |
|RF-021| O aluno deve poder visualizar às aulas ativas.  | Models\Aula.cs</br> Controllers\AulasController.cs </br> Views\Aulas\Index.cshtml  | Kauê/Symon  |
|RF-022| O aluno deve poder assistir às aulas dos cursos que está inscrito.  | Models\Aula.cs</br> Controllers/AulasController.cs </br> Views\Aulas\Details.cshtml  | Kauê/Symon | 
|RF-023| O aluno deve poder fazer perguntas em cada aula. | Models\ Pergunta.cs</br> Controller/PerguntasController.cs</br>  Viewes\Pergunta\Index.cshtml| Claudia |
|RF-024| O aluno deve poder responder perguntas em cada aula.| Models\Resposta.cs</br> Controller\RespostasController.sc</br> Views\Aulas\Details.cshtml| Claudia|
|RF-025| O aluno deve poder visualizar perguntas e respostas em cada aula. | Models\Perguntas.cs</br>  Controller\PerguntasController.cs</br> Views\Aulas\Details.cshtml |Claudia  |
|RF-026| O aluno deve poder marcar aulas como concluídas.  | Models\AulaConcluida.cs</br> Controllers\AulasConcluidasController.cs </br> Views\Aulas\Details.cshtml  | Kauê/Symon |



# Instruções de acesso

Aplicação foi hospedada no SmartASP.NET link para acesso:

[Saber+](http://symonsl7-001-site1.stempurl.com/)

Credencias para poder acessar a aplicação (Essas crendecias não são funcionalidades da aplicação é somente para poder acessar a hospedagem de teste do SmarterASP.NET, ira abrir uma caixa de diálogo insira as informações abaixo para poder acessar a aplicação. Caso apareça uma tela pedindo para continuar no site, clicar no botão "Continuar no Site")

Usuário: 11277727

Senha: 60-dayfreetrial
