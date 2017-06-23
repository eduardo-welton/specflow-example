#language: pt-BR
Funcionalidade: Calculadora
	Visando evitar erros bobos ao realizar operações matemáticas
	Como um usuário distraído
	Eu quero realizar operações matemáticas de modo automático

Cenário: Adição
	Dado que eu entre com o valor 50
	E que eu entre com o valor 70
	Quando eu realizar a operação de soma
	Então obterei o resultado 120 da calculadora

Cenário: Adição consecutiva
	Dado que eu tenha realizado a seguinte soma
	| numero1 | numero2 |
	| 50      | 50      |
	Quando que eu adicionar 70 ao meu resultado
	Então obterei o resultado 170 da calculadora

