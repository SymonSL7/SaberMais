# Plano de Testes de Usabilidade

---

## Definição dos objetivos

- Verificar se alunos e instrutores conseguem concluir tarefas principais sem dificuldades.
- Identificar barreiras de navegação na plataforma.
- Avaliar a clareza e eficiência da interface para diferentes perfis de usuários.
- Avaliar a satisfação do usuário ao interagir com cadastro, login, inscrição em curso, criação de curso e emissão de certificado.

---

## Seleção dos participantes

**Critérios de seleção:**
- Perfis variados: alunos e instrutores.
- Diferentes níveis de familiaridade com tecnologia (iniciantes e avançados).
- Idades variadas para verificar acessibilidade e clareza.
- Inclusão, se possível, de pessoas com necessidades especiais.

**Quantidade recomendada:**
- Mínimo: 5 participantes.
- Ideal: entre 8 e 12 participantes.

---

## Definição de cenários de teste

### Cenário 1 – Cadastro de Usuário
- **Objetivo:** Avaliar clareza e facilidade do processo de registro na plataforma.
- **Contexto:** Um novo usuário deseja criar uma conta.
- **Tarefa:** Acessar a página inicial, clicar em "Cadastrar", preencher dados obrigatórios e confirmar.
- **Critério de Sucesso:** Conta criada em menos de 2 minutos, sem ajuda.

### Cenário 2 – Login no Sistema
- **Objetivo:** Avaliar se o usuário entende como realizar login corretamente.
- **Contexto:** Usuário já possui cadastro.
- **Tarefa:** Inserir e-mail e senha, clicar em "Entrar".
- **Critério de Sucesso:** Login realizado sem erros em até 1 minuto.

### Cenário 3 – Recuperação de Senha
- **Objetivo:** Recuperar a senha esquecida do usuário.
- **Contexto:** Usuário deseja recuperar sua senha.
- **Tarefa:** Na tela de login, acessar "Esqueceu a senha?", preencher o e-mail, copiar e colar o link gerado na barra de navegação e preencher nova senha.
- **Critério de Sucesso:** Senha redefinida.

### Cenário 4 – Gerenciamento de Perfil (Editar Informações)
- **Objetivo:** Editar informações pessoais de perfil.
- **Contexto:** Usuário deve editar suas informações de perfil.
- **Tarefa:** Com usuário logado, clica no "nome do usuário" na barra lateral, acessar "Meu Perfil", acessar "Editar Informações", alterar os dados e salvar.
- **Critério de Sucesso:** Dados alterados.
  
### Cenário 5 – Gerenciamento de Perfil (Alterar Senha)
- **Objetivo:** Alterar senha do usuário (logado).
- **Contexto:** Usuário deve alterar a sua senha.
- **Tarefa:** Com usuário logado, clica no "nome do usuário" na barra lateral, acessar "Meu Perfil", acessar "Mudar", preencher os campos e salvar.
- **Critério de Sucesso:** Senha Alterada.
  
### Cenário 6 – Gerenciamento de Perfil (Deletar Conta)
- **Objetivo:** Deletar o perfil do usuário (logado).
- **Contexto:** Usuário deve deletar seu próprio perfil.
- **Tarefa:** Com usuário logado, clica no "nome do usuário" na barra lateral, acessar "Meu Perfil", acessar "Deletar Conta", clicar em "Sim, deletar minha conta" para confirmar.
- **Critério de Sucesso:** Conta Deletada.

### Cenário 7 – Gerenciamento de Perfil (Sair do Usuário)
- **Objetivo:** Sair da conta do usuário.
- **Contexto:** Usuário deve sair da sua conta.
- **Tarefa:** Com usuário logado, clica no "nome do usuário" na barra lateral, clicar em "Sair".
- **Critério de Sucesso:** Usuário deve ser deslogado da conta.

### Cenário 8 – Criar curso
- **Objetivo:** Verificar se o instrutor consegue criar curso.
- **Contexto:** O instrutor deve poder criar curso.
- **Tarefa:** Com o usuário logado, clicar em "Criar Curso", preencher as informações, clicar no botão "Criar Curso".
- **Critério de Sucesso:** O curso deve ser criado.

### Cenário 9 – Editar curso
- **Objetivo:** Verificar se o instrutor consegue editar curso.
- **Contexto:** O instrutor deve poder editar curso.
- **Tarefa:** Com o usuário logado, clicar em "Gerenciar Cursos", clicar no botão "Editar" do curso desejado, alterar as informações, salvar alterações.
- **Critério de Sucesso:** O curso deve ser editado.

### Cenário 10 – Visualizar curso
- **Objetivo:** Verificar se o instrutor consegue visualizar seus cursos criados.
- **Contexto:** O instrutor deve poder visualizar seus cursos criados.
- **Tarefa:** Com o usuário logado, clicar em "Gerenciar Cursos", clicar em "Detalhes" do curso desejado.
- **Critério de Sucesso:** O instrutor deve visualizar informações do curso.

### Cenário 11 – Excluir curso
- **Objetivo:** Verificar se o instrutor consegue excluir seus cursos criados.
- **Contexto:** O instrutor deve poder excluir curso.
- **Tarefa:** Com o usuário logado, clicar em "Gerenciar Cursos", clicar em "Deletar" do curso desejado, confirmar que deseja deletar.
- **Critério de Sucesso:** O curso deve ser deletado.

### Cenário 12 – Criar Aula
- **Objetivo:** Criar aula do curso.
- **Contexto:** O instrutor deve criar aula do curso.
- **Tarefa:** Com usuário logado, clicar em "Gerenciar Curso", clicar em "Detalhes", clicar em "Acessar Aulas", clicar em "Criar Nova Aula", inserir os dados da aula e clicar em "Criar Aula".
- **Critério de Sucesso:** Aula deve ser criada.

### Cenário 13 – Editar Aula
- **Objetivo:** Criar aula do curso.
- **Contexto:** O instrutor deve editar aula do curso.
- **Tarefa:** Com usuário logado, clicar em "Gerenciar Curso", clicar em "Detalhes", clicar em "Acessar Aulas", clicar em "Editar" na aula desejada, editar as informações da aula e clicar em "Salvar".
- **Critério de Sucesso:** Aula deve ser editada.

### Cenário 14 – Visualizar Aula
- **Objetivo:** Visualizar aulas do curso.
- **Contexto:** O instrutor deve visualizar aulas do curso.
- **Tarefa:** Com usuário logado, clicar em "Gerenciar Curso", clicar em "Detalhes", clicar em "Acessar Aulas", clicar em "Detalhes" na aula desejada, navegar pelas aulas.
- **Critério de Sucesso:** Aula deve ser visualizada.
 
### Cenário 15 – Excluir Aula
- **Objetivo:** Excluir aula do curso.
- **Contexto:** O instrutor deve excluir aula do curso.
- **Tarefa:** Com usuário logado, clicar em "Gerenciar Curso", clicar em "Detalhes", clicar em "Acessar Aulas", clicar em "Deletar" na aula desejada, clicar em "Deletar Permanentemente".
- **Critério de Sucesso:** Aula deve ser excluída.

### Cenário 16 – Visualizar Relatório de Progresso
- **Objetivo:** Visualizar relatório de progresso dos inscritos no curso.
- **Contexto:** O instrutor deve visualizar o relatório de progresso dos inscritos em seu curso.
- **Tarefa:** Com usuário logado, clicar em "Relatórios", clicar em "Ver Relatório de Progresso", visualizar o relatório de progresso dos seus curso, caso queira pode filtrar por curso.
- **Critério de Sucesso:** Relatório deve ser exibido.

### Cenário 17 – Visualizar Relatório de Perguntas Não Respondidas
- **Objetivo:** Visualizar relatório de perguntas não respondidas dos inscritos no curso.
- **Contexto:** O instrutor deve visualizar o relatório de perguntas não respondidas dos inscritos em seu curso.
- **Tarefa:** Com usuário logado, clicar em "Relatórios", clicar em "Ver Perguntas sem Respostas", visualizar o relatório de perguntas sem respostas dos seus curso, caso queira pode filtrar por curso.
- **Critério de Sucesso:** Relatório deve ser exibido.

### Cenário 18 – Visualizar cursos disponíveis
- **Objetivo:** Verificar se o aluno consegue visualizar os cursos ativos.
- **Contexto:** O aluno deve poder visualizar todos os cursos ativos.
- **Tarefa:** Com o usuário logado, clicar em "Cursos", clicar em "Visualizar Curso".
- **Critério de Sucesso:** O aluno deve poder visualizar todos os cursos disponíveis.

### Cenário 19 – Fazer matricula no curso
- **Objetivo:** Verificar se o aluno consegue fazer inscrição no curso.
- **Contexto:** O aluno deve poder se inscrever no curso.
- **Tarefa:** Com o usuário logado, clicar em "Cursos", clicar em "Visualizar Curso", clicar em "Inscrever-se".
- **Critério de Sucesso:** O aluno deve conseguir se inscrever no curso.

### Cenário 20 – Visualizar cursos matriculados
- **Objetivo:** Verificar se o aluno consegue visualizar seus cursos inscritos.
- **Contexto:** O aluno deve poder visualizar o painel "Meus Cursos" com seus cursos inscritos.
- **Tarefa:** Com o usuário logado, clicar em "Minhas Inscrições".
- **Critério de Sucesso:** O aluno deve poder visualizar os cursos em que ele está matriculado.

### Cenário 21 – Visualizar aulas do curso
- **Objetivo:** Visualizar aulas dos cursos.
- **Contexto:** O aluno deve visualizar as aulas do curso.
- **Tarefa:** Com usuário logado, clicar em "Cursos", clicar em "Visualizar Curso" no curso desejado, clicar em "Acessar Aula", visualizar as aulas ativas do curso.
- **Critério de Sucesso:** Deve ser exibida as aulas do curso.

### Cenário 22 – Assistir a aulas do curso
- **Objetivo:** Assistir aulas dos curso em que está matriculado.
- **Contexto:** O aluno deve assistir as aulas do curso.
- **Tarefa:** Com usuário logado, clicar em "Minhas Inscrições", clicar em "Acessar Curso" no curso desejado, clicar em "Acessar Aula", clicar em "Detalhes" da aula desejada, visualizar/assistir e navegar nas aulas disponíveis do curso.
- **Critério de Sucesso:** Deve ser visualizada as aulas do curso em que o aluno está inscrito.

### Cenário 23 – Fazer perguntas
- **Objetivo:** Verificar se o aluno consegue fazer perguntas na aulas.
- **Contexto:** O aluno deve poder fazer perguntas em cada aula.
- **Tarefa:** Com o usuário logado, clicar em "Cursos", clicar em "Visualizar Curso", clicar "Acessar Aulas", clicar em "Detalhes", navegar pelas aulas do curso, fazer a pergunta na aula desejada no campo abaixo do conteúdo da aula.
- **Critério de Sucesso:** O aluno deve poder fazer perguntas nas aulas do curso em que está inscrito.

### Cenário 24 – Responder perguntas
- **Objetivo:** Verificar se o aluno consegue responder as perguntas.
- **Contexto:** O aluno deve poder responder perguntas em cada aula.
- **Tarefa:** Com o usuário logado, clicar em "Cursos", clicar em "Visualizar Curso", clicar "Acessar Aulas", clicar em "Detalhes", navegar pelas aulas do curso, responder a pergunta da aula desejada.
- **Critério de Sucesso:** O aluno deve poder responder as perguntas das aulas do curso em que está inscrito.

### Cenário 25 – Visualizar perguntas e respostas
- **Objetivo:** Verificar se o aluno consegue visualizar perguntas e respostas.
- **Contexto:** O aluno deve poder visualizar perguntas e respostas em cada aula.
- **Tarefa:** Com o usuário logado, clicar em "Cursos", clicar em "Visualizar Curso", clicar "Acessar Aulas", clicar em "Detalhes", navegar pelas aulas do curso, visualizar as perguntas e respostas.
- **Critério de Sucesso:** O aluno deve poder visualizar as perguntas e respostas das aulas do curso em que está inscrito.

### Cenário 26 – Marcar Aula como Concluída.
- **Objetivo:** Marca aula como concluída nos cursos matriculados.
- **Contexto:** O aluno deve marcar aula como concluída no curso.
- **Tarefa:** Com usuário logado, clicar em "Minhas Inscrições", clicar em "Acessar Curso" no curso desejado, clicar em "Acessar Aula", clicar em "Detalhes" da aula desejada, visualizar e navegar nas aulas disponíveis do curso, clicar em "Aula Concluída".
- **Critério de Sucesso:** Aula deve ser marcada como concluída.

---

## Métodos de coleta de dados

- **Métricas quantitativas:** tempo gasto em cada tarefa, número de cliques, erros cometidos.
- **Métricas qualitativas:** dificuldades percebidas, comentários espontâneos.
- **Questionário pós-teste:** clareza da interface, facilidade de uso, sugestões de melhoria.

⚠️ De acordo com a LGPD, nenhum dado sensível dos participantes será registrado.
