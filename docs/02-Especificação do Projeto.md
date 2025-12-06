# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="01-Documentação de Contexto.md"> Documentação de Contexto</a></span>

## Personas

### Persona 1: Carlos Andrade (Aluno Jovem Aprendiz)

* **Perfil:** 22 anos, jovem aprendiz buscando migrar para a área de tecnologia.
* **Motivações:** Precisa aprender habilidades práticas de forma estruturada para conseguir um emprego melhor, mas não tem recursos para pagar por cursos.
* **Frustrações:** Sente-se perdido com a desorganização do conteúdo gratuito disponível online e intimidado pelos altos preços de cursos de qualidade.

### Persona 2: Sofia Martins (Instrutora Sênior)

* **Perfil:** 35 anos, Gerente de Projetos Sênior com vasta experiência.
* **Motivações:** Deseja compartilhar seu conhecimento prático para ajudar iniciantes e retribuir à comunidade.
* **Frustrações:** Acha as plataformas existentes muito complexas ou focadas em monetização, buscando apenas um meio simples de publicar seu conteúdo.

### Persona 3: Ana Lima (Profissional em Transição)

* **Perfil:** 42 anos, ex-gerente administrativa buscando requalificação para a área de análise de dados.
* **Motivações:** Precisa adquirir conhecimentos práticos e rápidos para voltar ao mercado de trabalho em uma nova área.
* **Frustrações:** Os bootcamps são muito caros e exigem dedicação em tempo integral, o que é inviável enquanto procura emprego.

### Persona 4: Roberto Costa (Instrutor Aposentado)

* **Perfil:** 68 anos, engenheiro civil aposentado.
* **Motivações:** Possui um vasto conhecimento prático e deseja se manter ativo, compartilhando sua experiência com as novas gerações de forma voluntária.
* **Frustrações:** Não tem familiaridade com tecnologias complexas de edição de vídeo ou plataformas de ensino pagas. Busca algo simples e direto ao ponto.

### Persona 5: Júlia Ferraz (Estudante Universitária)

* **Perfil:** 20 anos, estudante de Publicidade e Propaganda.
* **Motivações:** Quer aprender ferramentas de design e marketing digital que não são aprofundadas na faculdade para melhorar seu portfólio e conseguir um estágio.
* **Frustrações:** O tempo é limitado entre aulas e trabalhos, e o orçamento de estudante não permite investir em múltiplos cursos pagos.

## Histórias de Usuários

Com base na análise das personas foram identificadas as seguintes histórias de usuários:

| EU COMO... `PERSONA` | QUERO/PRECISO ... `FUNCIONALIDADE`                        | PARA ... `MOTIVO/VALOR`                                      |
| -------------------- | --------------------------------------------------------- | ------------------------------------------------------------ |
| Carlos Andrade       | Ver uma trilha de aprendizado sugerida para iniciantes    | Saber por onde começar meus estudos                          |
| Carlos Andrade       | Acessar os cursos pelo celular                            | Aproveitar o tempo de deslocamento no transporte público     |
| Carlos Andrade       | Receber um certificado de conclusão                       | Adicionar ao meu currículo e perfil no LinkedIn              |
| Sofia Martins        | Uma interface simples para subir meus vídeos e materiais  | Não perder tempo com tecnologia e focar no conteúdo          |
| Sofia Martins        | Ver as avaliações e comentários dos alunos                | Saber como posso melhorar minhas aulas futuras               |
| Sofia Martins        | Responder às dúvidas dos alunos diretamente na plataforma | Criar um canal de comunicação fácil e centralizado           |
| Ana Lima             | Buscar cursos por competências específicas, como "SQL"    | Focar no que é mais importante para minha nova carreira      |
| Ana Lima             | Ver a carga horária estimada de cada curso                | Planejar meus estudos com minha rotina de busca por emprego  |
| Ana Lima             | Interagir com outros alunos na seção de perguntas         | Trocar experiências e fazer networking com pessoas da área   |
| Roberto Costa        | Ter uma página de perfil pública simples                  | Descrever minha trajetória profissional e inspirar os alunos |
| Roberto Costa        | Poder criar questionários simples ao final dos módulos    | Ajudar os alunos a fixarem o conteúdo que ensinei            |
| Roberto Costa        | Ver um relatório de quantos alunos concluíram meu curso   | Sentir o impacto e a relevância da minha contribuição        |
| Júlia Ferraz         | Salvar cursos em uma "lista de desejos"                   | Me organizar para fazê-los quando tiver tempo livre          |
| Júlia Ferraz         | Ver o perfil e a experiência profissional do instrutor    | Ter mais confiança na qualidade do conteúdo oferecido        |
| Júlia Ferraz         | Filtrar cursos por curta duração                          | Encaixá-los nos meus fins de semana e períodos de férias     |

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

#### Requisitos Gerais e de Usuário

| ID     | Descrição do Requisito                                                   | Prioridade |
| ------ | ------------------------------------------------------------------------ | ---------- |
| RF-001 | O usuário deve poder se cadastrar como “Aluno” ou “Instrutor”.           | ALTA       |
| RF-002 | O usuário deve poder se autenticar (Login).                              | ALTA       |
| RF-003 | O usuário deve poder recuperar sua senha.                                | ALTA       |
| RF-004 | O usuário deve poder editar informações pessoais.                        | ALTA       |
| RF-005 | O usuário deve poder alterar senha.                       		    | ALTA       |
| RF-006 | O usuário deve poder excluir sua conta.                      	    | ALTA       |
| RF-007 | O usuário deve poder sair da conta. (Logout)                    	    | ALTA       |


#### Requisitos do Instrutor

| ID     | Descrição do Requisito                                                        | Prioridade |
| ------ | ----------------------------------------------------------------------------- | ---------- |
| RF-008 | O instrutor deve poder criar curso.                 				 | ALTA       |
| RF-009 | O instrutor deve poder editar curso.                 			 | ALTA       |
| RF-010 | O instrutor deve poder visualizar seus cursos criados.                 	 | ALTA       |
| RF-011 | O instrutor deve poder excluir curso.               				 | ALTA       |
| RF-012 | O instrutor deve poder criar aula do curso.               			 | ALTA       |
| RF-013 | O instrutor deve poder editar aula do curso.               			 | ALTA       |
| RF-014 | O instrutor deve poder visualizar as aulas do curso.               		 | ALTA       |
| RF-015 | O instrutor deve poder excluir aula do curso.               			 | ALTA       |
| RF-016 | O instrutor deve poder visualizar um relatório de progresso dos inscritos. 	 | ALTA       |
| RF-017 | O instrutor deve poder visualizar um relatório com perguntas não respondidas. | ALTA       |

#### Requisitos do Aluno

| ID     | Descrição do Requisito                                                  	   | Prioridade |
| ------ | ------------------------------------------------------------------------------- | ---------- |
| RF-018 | O aluno deve poder visualizar todos os cursos ativos. 			   | ALTA       |
| RF-019 | O aluno deve poder se inscrever no curso. 					   | ALTA       |
| RF-020 | O aluno deve poder visualizar o painel “Meus Cursos” com seus cursos inscritos. | ALTA       |
| RF-021 | O aluno deve poder visualizar às aulas ativas.                                  | ALTA       |
| RF-022 | O aluno deve poder assistir às aulas dos cursos que está inscrito.              | ALTA       |
| RF-023 | O aluno deve poder fazer perguntas em cada aula.            			   | MÉDIA      |
| RF-024 | O aluno deve poder responder perguntas em cada aula.            		   | MÉDIA      |
| RF-025 | O aluno deve poder visualizar perguntas e respostas em cada aula.           	   | MÉDIA      |
| RF-026 | O aluno deve poder marcar aulas como concluídas.                        	   | MÉDIA      |
| RF-027 | O aluno deve poder gerar um certificado de conclusão do curso.                        	   | BAIXA     |

#### Requisitos do Administrador

| ID     | Descrição do Requisito                                                            | Prioridade |
| ------ | --------------------------------------------------------------------------------- | ---------- |
| RF-028 | O administrador deve poder visualizar um relatório de desempenho dos instrutores. | BAIXA      |
| RF-029 | O administrador deve poder excluir contas de usuários.              		     | BAIXA      |
| RF-030 | O administrador deve poder remover qualquer curso da plataforma.        	     | BAIXA      |
| RF-031 | O administrador deve poder cadastrar novos administradores.                       | BAIXA      |

### Requisitos Não Funcionais

| ID      | Descrição do Requisito                                        | Prioridade |
| ------- | ------------------------------------------------------------- | ---------- |
| RNF-001 | A interface deve ser intuitiva, limpa e responsiva.           | ALTA       |
| RNF-002 | Senhas devem ser armazenadas de forma criptografada.          | ALTA       |
| RNF-003 | As páginas principais devem carregar em menos de 10 segundos. | MÉDIA      |
| RNF-004 | A plataforma deve estar disponível 99% do tempo.              | MÉDIA      |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| ID | Restrição                                                                            |
| -- | ------------------------------------------------------------------------------------ |
| 01 | O backend da aplicação deve ser desenvolvido em C# com ASP.NET Core.                 |
| 02 | O frontend deve ser desenvolvido com Razor HTML, CSS, Bootstrap, JavaScript e C# .   |
| 03 | Todos os cursos oferecidos na plataforma devem ser gratuitos.                        |
| 04 | Os dados devem ser armazenados em um banco de dados SqlServer                        |

## Diagrama de Casos de Uso

![Diagrama](img/DiagramadeCasosdeUso.png)
 
