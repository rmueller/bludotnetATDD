#language: pt-br

Funcionalidade: Frete grátis para clientes VIP na compra de 5 ou mais livros
	Para aumentar a fidelização dos nossos clientes, oferecemos frete grátis
	nas compras de 5 ou mais livros para nossos clientes VIP

Esquema do Cenario: Realizando compra de somente livros
	Dado Uma compra de um cliente <tipoCliente> com <quantidade> livros
	Quando Eu finalizar a compra
	Entao Devo ter a opção de frete <tipoFrete>
	
	Exemplos: 
	| tipoCliente | quantidade | tipoFrete      |
	| Normal      | 5          | Sedex          |
	| Normal      | 10         | Sedex          |
	| VIP         | 5          | Sedex,Gratuito |
	| VIP         | 4          | Sedex          |

Esquema do Cenario: Realizando uma compra de livros junto com outros produtos
	Dado Uma compra de um cliente <tipoCliente> com <quantidade> livros e qualquer outro produto
	Quando Eu finalizar a compra
	Entao Não devo ter a opção de frete gratuito

	Exemplos: 
	| tipoCliente | quantidade |
	| Normal      | 10         |
	| VIP         | 10         |






