#language:pt

Funcionalidade:  Investimento
Como usuário de investimentos,
Quero Investir, gerenciar e monitorar meus investimentos,
Para que eu possa tomar decisões informadas e otimizar meu retorno financeiro.


Contexto:Acessar a Interface de Investimentos
	Dado Que estou logado na plataforma do Picpay
	E Acesso a Tela De Investimentos

Cenário: Validar Acesso a Tela de Investimentos
	Entao Valido que estou na tela de Investimentos

Cenário: Validar Filtro por Renda Fixa
	Quando Efetuo Busca por Renda Fixa
	Entao Valido que efetuei filtro por renda fixa

Cenário: Validar Mensagem Informativa Perfil de Investidor
	Quando Efetuo Busca por Renda Fixa
	E Seleciono um investimento
	Entao Valido mensagem informativa perfil de investidor

Cenário: Validar Cenario com preenchimento de valor de saldo menor que o limite minimo
	Quando Efetuo Busca por Renda Fixa
	E Seleciono um investimento
	E Acesso tela Valor a investir
	Entao Valido mensagem apresentada com valor investimento menor que o minimo


Cenário: Validar Cenario com preenchimento de valor de saldo maior que o saldo da conta
	Quando Efetuo Busca por Renda Fixa
	E Seleciono um investimento
	E Acesso tela Valor a investir
	Entao Valido mensagem apresentada com valor investimento maior que o saldo

Cenário: Validar info saldo da conta
	Quando Efetuo Busca por Renda Fixa
	E Seleciono um investimento
	E Acesso tela Valor a investir
	Entao Valido info saldo da conta

Cenário: Validar Valor Investido da Conta
	Quando Efetuo Busca por Renda Fixa
	E Efetuo Processo de investimento
	Entao Valido se saldo investido e igual ao saldo apresentado

	Cenário: Validar investimento em Renda Fixa com sucesso
	Quando Efetuo Busca por Renda Fixa
	E Efetuo Processo de investimento
	Entao Valido Investimento efetivado com sucesso

