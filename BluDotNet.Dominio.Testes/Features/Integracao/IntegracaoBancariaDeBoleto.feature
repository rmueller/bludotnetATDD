#language: pt-br
Funcionalidade: IntegracaoBancariaDeBoletos
	A integração bancária serve para
	fazer a conciliação dos boletos em aberto no
	sistema com os boletos que constam como pago no banco

	Contexto: 
		Dado os seguintes boletos em aberto no sistema
		| numero | valor |
		| 1      | 10    |
		| 2      | 20    |
		| 3      | 30    |
		| 4      | 40    |
		E os seguintes boletos fechados no sistema
		| numero | valor |
		| 10     | 100   |
				
Cenario: Integrando com informacoes de todos boletos nos valores corretos
	Dada a entrada
	| numero | valor |
	| 1      | 10    |
	| 2      | 20    |
	| 3      | 30    |
	| 4      | 40    |
	Quando executar a integracao
	Entao deve fechar todos os boletos
	
Cenario: Integrando com informacoes de valor divergente
	Dada a entrada
	| numero | valor |
	| 1      | 15    |
	Quando executar a integracao
	Entao deve notificar valores divergentes (esperado 10, encontrado 15) na importacao do boleto 1

Cenario: Integrando com informacoes de um boleto já fechado
	Dada a entrada
	| numero | valor |
	| 10     | 100   |
	Quando executar a integracao
	Entao deve notificar que o boleto 10 já estava fechado

Cenario: Integrando com informacoes de um boleto já fechado e valores divergentes
	Dada a entrada
	| numero | valor |
	| 10     | 150   |
	Quando executar a integracao
	Entao deve notificar que o boleto 10 já estava fechado







