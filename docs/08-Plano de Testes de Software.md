# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="02-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="04-Projeto de Interface.md"> Projeto de Interface</a>

---

# Casos de Teste

| **Caso de Teste** | **CT01 – Cadastrar usuário** |
|:---:|:---|
| Requisito Associado | RF-001 - O usuário deve poder se cadastrar como “Aluno” ou “Instrutor”. |
| Objetivo do Teste | Verificar se o usuário consegue se cadastrar na aplicação. |
| Passos | - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Criar conta" <br> - Preencher os campos obrigatórios (nome, e-mail, senha, tipo de usuário) <br> - Confirmar o cadastro |
| Critério de Êxito | O cadastro foi realizado com sucesso. |

| **Caso de Teste** | **CT02 – Efetuar login** |
|:---:|:---|
| Requisito Associado | RF-002 - O usuário deve poder se autenticar (Login). |
| Objetivo do Teste | Verificar se o usuário consegue realizar login. |
| Passos | - Acessar o navegador <br> - Informar o endereço do site <br> - Clicar em "Entrar" <br> - Preencher o campo de e-mail <br> - Preencher o campo da senha <br> - Clicar em "Login" |
| Critério de Êxito | O login foi realizado com sucesso. |

| **Caso de Teste** | **CT03 – Recuperação de senha** |
|:---:|:---|
| Requisito Associado | RF-003 - O usuário deve poder recuperar sua senha. |
| Objetivo do Teste | Verificar se o usuário consegue recuperar acesso à conta. |
| Passos | - Acessar a página de login <br> - Clicar em "Esqueci minha senha" <br> - Informar e-mail cadastrado <br> - Acessar o e-mail recebido <br> - Clicar no link de redefinição <br> - Inserir nova senha <br> - Confirmar a alteração |
| Critério de Êxito | A senha foi alterada com sucesso e o usuário consegue fazer login com a nova senha. |

| **Caso de Teste** | **CT04 – Editar Informações Pessoais** |
|:---:|:---|
| Requisito Associado | RF-004 - O usuário deve poder editar informações pessoais.  |
| Objetivo do Teste | Verificar se o usuário consegue editar suas informações pessoais. |
| Passos | - Fazer login na aplicação <br> - Clicar sobre o nome  <br> - Acessar "Meu Perfil" <br> - Clicar em "Editar Informações" <br> - Alterar informações (nome, descrição) <br> - Salvar as alterações |
| Critério de Êxito | As informações do perfil foram atualizadas corretamente. |

| **Caso de Teste** | **CT05 – Alterar senha** |
|:---:|:---|
| Requisito Associado | RF-005 - O usuário deve poder alterar senha.   |
| Objetivo do Teste | Verificar se o usuário consegue editar sua senha. |
| Passos | - Fazer login na aplicação <br> - Clicar sobre o nome <br>  - Acessar "Meu Perfil" <br> - Clicar em "Mudar Senha" <br> - Alterar senha (Digitar senha atual e a nova senha) <br> - Salvar as alterações |
| Critério de Êxito | A senha deve ser alterada. |

| **Caso de Teste** | **CT06 – Excluir Conta** |
|:---:|:---|
| Requisito Associado | RF-006 - O usuário deve poder excluir sua conta.  |
| Objetivo do Teste | Verificar se o usuário consegue excluir sua conta. |
| Passos | - Fazer login na aplicação <br> - Clicar sobre o nome <br> - Acessar "Meu Perfil" <br> - Clicar em "Mudar Senha" <br> - Deletar Conta. <br> - Confirmar que deseja deletar |
| Critério de Êxito | A conta deve ser deletada |

| **Caso de Teste** | **CT07 – Sair da Conta** |
|:---:|:---|
| Requisito Associado | RF-007 - O usuário deve poder sair da conta. (Logout)   |
| Objetivo do Teste | Verificar se o usuário consegue sair da conta. |
| Passos | - Fazer login na aplicação <br> - Clicar sobre o nome <br> - Clicar em "Sair |
| Critério de Êxito | O usuário deve ser desconectado. |

| **Caso de Teste** | **CT08 – Criar curso** |
|:---:|:---|
| Requisito Associado | RF-008 - O instrutor deve poder criar curso.   |
| Objetivo do Teste | Verificar se o instrutor consegue criar curso. |
| Passos | - Com o usuário logado <br> - Clicar em "Criar Curso"  <br> - Preenche as informações <br> - Clicar no botão "Criar Curso" |
| Critério de Êxito | O curso deve ser criado. |

| **Caso de Teste** | **CT09 – Editar curso** |
|:---:|:---|
| Requisito Associado | RF-009 - O instrutor deve poder editar curso.   |
| Objetivo do Teste | Verificar se o instrutor consegue editar curso. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar no botão "Editar" do curso desejado. <br> - Alterar as informações <br> Salvar Alterações |
| Critério de Êxito | O curso deve ser editado. |

| **Caso de Teste** | **CT10 – Visualizar curso** |
|:---:|:---|
| Requisito Associado | RF-010 - O instrutor deve poder visualizar seus cursos criados.   |
| Objetivo do Teste | Verificar se o instrutor consegue visualizar seus cursos criados. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar em "Detalhes" do curso desejado |
| Critério de Êxito | O instrutor deve visualizar informações do curso. |

| **Caso de Teste** | **CT11 – Excluir curso** |
|:---:|:---|
| Requisito Associado | RF-011 - O instrutor deve poder excluir curso.    |
| Objetivo do Teste | Verificar se o instrutor consegue excluir seus cursos criados. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar em "Deletar" do curso desejado <br> - Confirmar que deseja deletar |
| Critério de Êxito | O curso deve ser deletado. |

| **Caso de Teste** | **CT12 – Criar aula** |
|:---:|:---|
| Requisito Associado | RF-012 - O instrutor deve poder criar aula do curso.    |
| Objetivo do Teste | Verificar se o instrutor consegue criar aula em seus cursos. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar em "Detalhes" do curso desejado <br> - Clicar em "Acessar Aulas" <br> - Clicar em "Criar Nova Aula" <br> - Inserir as informações da aula (Caso tenha alguma arquivo ou video, anexar) <br> - Clicar em "Criar Aula"  |
| Critério de Êxito | O aula deve ser criada. |

| **Caso de Teste** | **CT13 – Editar aula** |
|:---:|:---|
| Requisito Associado | RF-013 - O instrutor deve poder editar aula do curso.     |
| Objetivo do Teste | Verificar se o instrutor consegue editar aula em seus cursos. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar em "Detalhes" do curso desejado <br> - Clicar em "Acessar Aulas" <br> - Clicar em "Editar" na aula desejada <br> - Editar as informações <br> - Clicar em "Salvar"   |
| Critério de Êxito | O aula deve ser editada. |

| **Caso de Teste** | **CT14 – Visualizar aula** |
|:---:|:---|
| Requisito Associado | RF-014 - O instrutor deve poder visualizar as aulas do curso.      |
| Objetivo do Teste | Verificar se o instrutor consegue visualizar aula em seus cursos. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar em "Detalhes" do curso desejado <br> - Clicar em "Acessar Aulas" <br> - Clicar em "Detalhes" em alguma das aula <br> - Navegar pelas aulas do curso   |
| Critério de Êxito | O instrutor deve visualizar a aula. |

| **Caso de Teste** | **CT15 – Excluir aula** |
|:---:|:---|
| Requisito Associado | RF-015 - O instrutor deve poder excluir aula do curso.        |
| Objetivo do Teste | Verificar se o instrutor consegue excluir aula em seus cursos. |
| Passos | - Com o usuário logado <br> - Clicar em "Gerenciar Cursos"  <br> - Clicar em "Detalhes" do curso desejado <br> - Clicar em "Acessar Aulas" <br> - Clicar em "Deletar" na aula desejada <br> - Confirmar que deseja deletar
| Critério de Êxito | A aula deve ser deletada. |

| **Caso de Teste** | **CT16 – Visualizar Relatório de Progresso** |
|:---:|:---|
| Requisito Associado | RF-016 - O instrutor deve poder visualizar um relatório de progresso dos inscritos.        |
| Objetivo do Teste | Verificar se o instrutor consegue visualizar o relatório. |
| Passos | - Com o usuário logado <br> - Clicar em "Relatórios"  <br> Clicar em "Ver Relatório de Progresso " 
| Critério de Êxito | O instrutor deve visualizar o relatório com o progresso de alunos inscritos nos seus cursos. |

| **Caso de Teste** | **CT17 – Visualizar Relatório de Perguntas Não Respondidas** |
|:---:|:---|
| Requisito Associado | RF-017 - O instrutor deve poder visualizar um relatório com perguntas não respondidas.        |
| Objetivo do Teste | Verificar se o instrutor consegue visualizar o relatório.  |
| Passos | - Com o usuário logado <br> - Clicar em "Relatórios"  <br> Clicar em "Ver Perguntas sem Respostas" 
| Critério de Êxito | O instrutor deve visualizar o relatório com as perguntas não respondidas de seus cursos. |

| **Caso de Teste** | **CT18 – Visualizar cursos disponíveis** |
|:---:|:---|
| Requisito Associado | RF-018 - O aluno deve poder visualizar todos os cursos ativos.         |
| Objetivo do Teste | Verificar se o aluno consegue visualizar os cursos ativos.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos"  <br> - Clica em "Visualizar Curso"
| Critério de Êxito | O aluno deve poder visualizar todos os cursos disponíveis |

| **Caso de Teste** | **CT19 – Fazer matricula no curso.** |
|:---:|:---|
| Requisito Associado | RF-019 - O aluno deve poder se inscrever no curso.          |
| Objetivo do Teste | Verificar se o aluno consegue fazer inscrição no curso.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos"  <br>  - Clica em "Visualizar Curso" <br> - Clicar em "Inscrever-se"
| Critério de Êxito | O aluno deve poder visualizar todos os cursos disponíveis |

| **Caso de Teste** | **CT20 – Visualizar cursos matriculados** |
|:---:|:---|
| Requisito Associado | RF-020 - O aluno deve poder visualizar o painel “Meus Cursos” com seus cursos inscritos.          |
| Objetivo do Teste | Verificar se o aluno consegue visualizar seus cursos inscritos.  |
| Passos | - Com o usuário logado <br> - Clicar em "Minhas Inscrições"
| Critério de Êxito | O aluno deve poder visualizar os cursos em que ele está matriculado. |

| **Caso de Teste** | **CT21 – Visualizar aulas do curso.** |
|:---:|:---|
| Requisito Associado | RF-021 - O aluno deve poder visualizar às aulas ativas.  seus cursos inscritos.          |
| Objetivo do Teste | Verificar se o aluno consegue visualizar aulas do curso.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos" <br> - Clicar em "Visualizar Curso <br> - Clicar "Acessar Aulas"
| Critério de Êxito | O aluno deve poder visualizar as aulas do curso. |

| **Caso de Teste** | **CT22 – Assistir a aulas do curso.** |
|:---:|:---|
| Requisito Associado | RF-022 - O aluno deve poder assistir às aulas dos cursos que está inscrito.          |
| Objetivo do Teste | Verificar se o aluno consegue assistir as aulas dos cursos em que está inscrito.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos" <br> - Clicar em "Visualizar Curso <br> - Clicar "Acessar Aulas" <br> - Clicar em "Detalhes" <br> - Navegar pelas aulas do curso
| Critério de Êxito | O aluno deve poder assistir as aulas do curso em que está inscrito. |

| **Caso de Teste** | **CT23 – Fazer perguntas.** |
|:---:|:---|
| Requisito Associado | RF-023 - O aluno deve poder fazer perguntas em cada aula.           |
| Objetivo do Teste | Verificar se o aluno consegue fazer perguntas na aulas.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos" <br> - Clicar em "Visualizar Curso <br> - Clicar "Acessar Aulas" <br> - Clicar em "Detalhes" <br> - Navegar pelas aulas do curso <br> - Fazer a pergunta na aula desejada, no campo abaixo do conteúdo da aula.
| Critério de Êxito | O aluno deve poder fazer perguntas nas aulas do curso em que está inscrito. |

| **Caso de Teste** | **CT24 – Responder perguntas.** |
|:---:|:---|
| Requisito Associado | RF-024 - O aluno deve poder responder perguntas em cada aula.             |
| Objetivo do Teste | Verificar se o aluno consegue responder as perguntas.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos" <br> - Clicar em "Visualizar Curso <br> - Clicar "Acessar Aulas" <br> - Clicar em "Detalhes" <br> - Navegar pelas aulas do curso <br> - Responder a pergunta da aula desejada.
| Critério de Êxito | O aluno deve poder responder as perguntas das aulas do curso em que está inscrito. |

| **Caso de Teste** | **CT25 – Visualizar perguntas e respostas.** |
|:---:|:---|
| Requisito Associado | RF-025 - O aluno deve poder visualizar perguntas e respostas em cada aula.             |
| Objetivo do Teste | Verificar se o aluno consegue responder as perguntas.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos" <br> - Clicar em "Visualizar Curso <br> - Clicar "Acessar Aulas" <br> - Clicar em "Detalhes" <br> - Navegar pelas aulas do curso <br> - Visualizar as perguntas e respostas
| Critério de Êxito | O aluno deve poder visualizar as perguntas e respostas das aulas do curso em que está inscrito. |

| **Caso de Teste** | **CT26 – Marcar Aula como Concluída.** |
|:---:|:---|
| Requisito Associado | RF-026 - O aluno deve poder marcar aulas como concluídas.              |
| Objetivo do Teste | Verificar se o aluno consegue responder as perguntas.  |
| Passos | - Com o usuário logado <br> - Clicar em "Cursos" <br> - Clicar em "Visualizar Curso <br> - Clicar "Acessar Aulas" <br> - Clicar em "Detalhes" <br> - Navegar pelas aulas do curso <br> - Clica em concluir aula
| Critério de Êxito | O aluno deve marcar como concluída a aula. |

